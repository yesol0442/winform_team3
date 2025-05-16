using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Net.Sockets;
using client.classes.NetworkManager;


namespace client.menuControl
{
    public partial class 환경설정 : UserControl
    {
        private string userId;
        private bool soundEnabled = true;

        public 환경설정()
        {
            InitializeComponent();

            picProfile.Visible = false;
            btn_modPicture.Visible = false;
            txtNickname.Visible = false;
            lblNickname.Visible = false;
            btn_modNickname.Visible = false;
            lblLanguage.Visible = false;
            cmbLanguage.Visible = false;
            lblSound.Visible = false;
            togSound.Visible = false;
            chkGuide.Visible = false;
            btnDelete.Visible = false;
        }

        public async Task SetConnection(string userId)
        {
            try
            {
                // 서버와 연결 시도
                await NetworkManager.Instance.ConnectAsync("127.0.0.1", 5000);

                // 연결 성공 시 사용자 ID 설정
                this.userId = userId;
                MessageBox.Show("서버 연결 성공", "연결 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 프로필 로드 시도
                await LoadUserProfileAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"서버 연결 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string inputId = txtId.Text.Trim();

                if (string.IsNullOrEmpty(inputId))
                {
                    MessageBox.Show("아이디를 입력하세요.");
                    return;
                }

                await SetConnection(inputId);
            }
        }

        private async Task LoadUserProfileAsync()
        {
            try
            {
                string message = $"LOAD_PROFILE:{userId}";
                await NetworkManager.Instance.SendMessageAsync(message);

                // 서버가 먼저 PROFILE:{nickname}: 보내고 이미지 청크를 여러번 보내는 상황 가정
                string headerResponse = await NetworkManager.Instance.ReceiveMessageAsync();

                if (headerResponse == null || !headerResponse.StartsWith("PROFILE:"))
                {
                    MessageBox.Show("프로필 로드 실패", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 닉네임과 첫 부분 분리
                string[] parts = headerResponse.Split(new char[] { ':' }, 3);
                string nickname = parts.Length > 1 ? parts[1] : "";
                string base64Image = parts.Length > 2 ? parts[2] : "";

                StringBuilder base64ImageBuilder = new StringBuilder(base64Image);

                // 이미지 청크를 반복해서 받기 (::END:: 만날 때까지)
                while (true)
                {
                    string chunk = await NetworkManager.Instance.ReceiveMessageAsync();
                    if (chunk == null)
                    {
                        MessageBox.Show("프로필 이미지 수신 중 오류 발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (chunk.EndsWith("::END::"))
                    {
                        base64ImageBuilder.Append(chunk.Replace("::END::", ""));
                        break;
                    }
                    base64ImageBuilder.Append(chunk);
                }

                txtNickname.Text = nickname;
                lblNickname.Text = nickname;

                if (base64ImageBuilder.Length > 0)
                {
                    try
                    {
                        string cleanedBase64 = base64ImageBuilder.ToString().Replace("\r", "").Replace("\n", "").Trim();
                        byte[] imageBytes = Convert.FromBase64String(cleanedBase64);

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            picProfile.Image = Image.FromStream(ms);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("프로필 이미지 데이터가 손상되었습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                picProfile.Visible = true;
                btn_modPicture.Visible = true;
                txtNickname.Visible = false;
                lblNickname.Visible = true;
                btn_modNickname.Visible = true;
                lblLanguage.Visible = true;
                cmbLanguage.Visible = true;
                lblSound.Visible = true;
                togSound.Visible = true;
                chkGuide.Visible = true;
                btnDelete.Visible = true;

                txtId.Visible = false;
                lblId.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"프로필 로드 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btn_modPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "이미지 파일 (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        string base64Image = Convert.ToBase64String(imageBytes);

                        // 데이터를 청크 단위로 나눠서 전송
                        int chunkSize = 1024; // 1KB 단위로 전송
                        int i = 0;

                        int remaining = base64Image.Length - i;
                        string firstChunk = base64Image.Substring(i, Math.Min(chunkSize, remaining));
                        string firstMessage = $"UPDATE_PROFILE_IMAGE:{userId}:{firstChunk}";
                        await NetworkManager.Instance.SendMessageAsync(firstMessage);
                        i += chunkSize;

                        // 이후 청크는 Base64 문자열만 전송
                        for (; i < base64Image.Length; i += chunkSize)
                        {
                            remaining = base64Image.Length - i;
                            string chunk = base64Image.Substring(i, Math.Min(chunkSize, remaining));
                            await NetworkManager.Instance.SendMessageAsync(chunk);
                        }

                        // 전송 종료 표시
                        await NetworkManager.Instance.SendMessageAsync("::END::");

                        string response = await NetworkManager.Instance.ReceiveMessageAsync();
                        if (response == "OK")
                        {
                            picProfile.Image = Image.FromFile(imagePath);
                            MessageBox.Show("프로필 사진이 변경되었습니다.", "변경 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("프로필 사진 변경 실패: " + response);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"프로필 사진 변경 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void btn_modNickname_Click(object sender, EventArgs e)
        {
            lblNickname.Visible = false;
            txtNickname.Visible = true;
            txtNickname.Focus();
        }

        private async void txtNickname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string newNickname = txtNickname.Text.Trim();

                if (string.IsNullOrEmpty(newNickname) || newNickname.Length > 10)
                {
                    MessageBox.Show("닉네임은 1자 이상 10자 이하여야 합니다.");
                    return;
                }

                try
                {
                    string message = $"UPDATE_NICKNAME:{userId}:{newNickname}";
                    await NetworkManager.Instance.SendMessageAsync(message);
                    string response = await NetworkManager.Instance.ReceiveMessageAsync();

                    if (response == "OK")
                    {
                        lblNickname.Text = newNickname;
                        txtNickname.Visible = false;
                        lblNickname.Visible = true;
                        MessageBox.Show("닉네임이 변경되었습니다.", "변경 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("닉네임 변경 실패: " + response);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"닉네임 변경 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("정말로 계정을 삭제하시겠습니까?", "계정 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string message = $"DELETE_ACCOUNT:{userId}";
                    await NetworkManager.Instance.SendMessageAsync(message);
                    string response = await NetworkManager.Instance.ReceiveMessageAsync();

                    if (response == "OK")
                    {
                        MessageBox.Show("계정이 성공적으로 삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("계정 삭제 실패: " + response);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"계정 삭제 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkGuide_CheckedChanged(object sender, EventArgs e)
        {
            //타자 가이드를 어떤 식으로 집어넣을지 모르겠으니 일단 보류
        }


        private void togSound_CheckedChanged(object sender, EventArgs e)
        {
            soundEnabled = togSound.Checked;

            //사운드 집어 넣게 되면 soundFilePath에 사운드 파일 경로 입력해서 소리 안 나도록 설정
            //if (soundEnabled)
            //{
            //    try
            //    {
            //        SoundPlayer player = new SoundPlayer(soundFilePath);
            //        player.Play();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"사운드 재생 오류: {ex.Message}");
            //    }
            //}
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //로컬 DB 만드는 게 우선이기 때문에 일단 보류
        }


    }
}
