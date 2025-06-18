using client.quizForm;
using client.FindDifferForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.classes;
using client.classes.NetworkManager;

namespace client.menuControl
{
    public partial class PVP : UserControl
    {
        Form1 parentForm;

        quizStart quizstart;

        FindStart findStart;

        private string userNickname;
        private string user64Image;

        public PVP(Form1 main)
        {
            InitializeComponent();
            parentForm = main;
        }

        private void btnQuizStart_Click(object sender, EventArgs e)
        {
            quizstart = new quizStart(userNickname, user64Image, parentForm);
            quizstart.Show();
        }


        private void btnFindDiff_Click(object sender, EventArgs e)
        {
            findStart = new FindStart();
            findStart.Show();
        }

        public async Task LoadUserInfos(string currentUserId)
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
                userNickname = stats[0];

                // 2. 이미지 데이터 수신 (Base64 문자열, 끝에 ::END::)
                string base64Image = await NetworkManager.Instance.ReceiveFullMessageUntilEndAsync("");
                Console.WriteLine($"서버에서 받은 이미지 Base64 길이: {base64Image?.Length ?? 0}");

                if (!string.IsNullOrWhiteSpace(base64Image))
                {
                    try
                    {
                        user64Image = base64Image;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"[프로필 이미지 오류] {ex.Message}");
                        MessageBox.Show("프로필 이미지 데이터가 손상되었습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    user64Image = null;
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
