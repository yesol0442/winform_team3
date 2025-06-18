using client.classes;
using client.classes.NetworkManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.menuControl
{
    public partial class 홈 : UserControl
    {

        public 홈()
        {   
            InitializeComponent();
        }

        public async Task LoadUserStats(string currentUserId)
        {
            if (string.IsNullOrEmpty(currentUserId))
                return;

            try
            {
                string request = $"LOAD_STATS:{currentUserId}";
                await NetworkManager.Instance.SendMessageAsync(request);

                // 1. 헤더(통계 데이터) 수신 (끝에 ::END_HEADER:: 포함)
                string header = await NetworkManager.Instance.ReceiveHeaderAsync();
                Console.WriteLine($"서버에서 받은 헤더: '{header}'");

                if (string.IsNullOrEmpty(header) || header == "STATS_LOAD_FAIL")
                {
                    MessageBox.Show("유저 통계 정보를 불러오지 못했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] stats = header.Split('|');
                if (stats.Length < 10)
                {
                    MessageBox.Show("유효하지 않은 데이터 형식입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // UI에 데이터 설정
                lblNickname.Text = stats[0];
                lblStrokeNumber.Text = stats[1] + "타";
                lblAccurancy.Text = stats[2] + "%";
                lblMainLanguage.Text = stats[3];
                lblRainMaxScore.Text = stats[4] + "점";
                lblRainMaxLevel.Text = stats[5];
                lblBlockRecord.Text = stats[6] + "초";
                lblQuizMaxScore.Text = stats[7] + "점";
                lblQuizWinRate.Text = stats[8] + "등";
                //lblFoundWinRate.Text = stats[9] + "%";

                
                if (stats[9]=="1")
                {
                    lblQuizWinRate.Text = "승리";
                }else if(stats[9] == "0")
                {
                    lblQuizWinRate.Text = "패배";
                }
                else
                {
                    lblQuizWinRate.Text = "무승부";
                }

                    // 2. 이미지 데이터 수신 (Base64 문자열, 끝에 ::END::)
                    string base64Image = await NetworkManager.Instance.ReceiveFullMessageUntilEndAsync("");
                Console.WriteLine($"서버에서 받은 이미지 Base64 길이: {base64Image?.Length ?? 0}");

                if (!string.IsNullOrWhiteSpace(base64Image))
                {
                    try
                    {
                        byte[] imgBytes = Convert.FromBase64String(base64Image);
                        using (var ms = new MemoryStream(imgBytes))
                        {
                            picProfile.Image?.Dispose(); // 기존 이미지가 있으면 메모리 해제
                            picProfile.Image = Image.FromStream(ms);
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"[프로필 이미지 오류] {ex.Message}");
                        MessageBox.Show("프로필 이미지 데이터가 손상되었습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        picProfile.Image?.Dispose();
                        picProfile.Image = null;
                    }
                }
                else
                {
                    // 이미지 없으면 기본 이미지(또는 null) 설정
                    picProfile.Image?.Dispose();
                    picProfile.Image = null;
                }

                Console.WriteLine("[클라이언트] 유저 통계 및 프로필 사진 로드 완료");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[클라이언트] 유저 통계 로드 중 오류 발생: {ex}");
                MessageBox.Show("유저 통계 로드 중 오류가 발생했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
