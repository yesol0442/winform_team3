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

namespace client.menuControl
{
    public partial class 환경설정 : UserControl
    {
        private string userId;
        private NetworkStream stream;
        private TcpClient client;

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

        public void SetConnection(string userId, TcpClient client, NetworkStream stream)
        {
            try
            {
                // 서버 연결이 끊어졌다면 재연결 시도
                if (client == null || !client.Connected)
                {
                    client = new TcpClient("127.0.0.1", 5000);
                    stream = client.GetStream();
                    Console.WriteLine("[클라이언트] 서버와 재연결 성공");
                }

                this.userId = userId;
                this.client = client;
                this.stream = stream;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"서버 연결 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
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

                try
                {
                    client = new TcpClient("127.0.0.1", 5000);
                    stream = client.GetStream();

                    userId = inputId;
                    LoadUserProfile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"서버 연결 실패: {ex.Message}");
                    return;
                }

            }
        }

        private void LoadUserProfile()
        {
            try
            {
                string message = $"LOAD_PROFILE:{userId}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[40960];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                if (response.StartsWith("PROFILE:"))
                {
                    string[] parts = response.Split(new char[] { ':' }, 3);

                    string nickname = parts.Length > 1 ? parts[1] : "";
                    string base64Image = parts.Length > 2 ? parts[2] : "";

                    txtNickname.Text = nickname;
                    lblNickname.Text = nickname;

                    if (!string.IsNullOrEmpty(base64Image))
                    {
                        // base64 -> 이미지 변환
                        byte[] imageBytes = Convert.FromBase64String(base64Image);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            picProfile.Image = Image.FromStream(ms);
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
                else
                {
                    MessageBox.Show("프로필 로드 실패", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"프로필 로드 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_modPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "이미지 파일 (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;

                    try
                    {
                        // 이미지 파일을 바이트 배열로 읽기
                        byte[] imageBytes = File.ReadAllBytes(imagePath);

                        // 메시지 앞부분: userId와 명령어
                        string header = $"UPDATE_PROFILE_IMAGE:{userId}:";
                        byte[] headerBytes = Encoding.UTF8.GetBytes(header);

                        // header + 이미지 바이트 합치기
                        byte[] dataToSend = new byte[headerBytes.Length + imageBytes.Length];
                        Buffer.BlockCopy(headerBytes, 0, dataToSend, 0, headerBytes.Length);
                        Buffer.BlockCopy(imageBytes, 0, dataToSend, headerBytes.Length, imageBytes.Length);

                        // 서버에 전송
                        stream.Write(dataToSend, 0, dataToSend.Length);

                        // 서버 응답 받기
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

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

        private void txtNickname_KeyDown(object sender, KeyEventArgs e)
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

                lblNickname.Visible = true;
                txtNickname.Visible = false;

                // 서버에 닉네임 변경 요청
                try
                {
                    string message = $"UPDATE_NICKNAME:{userId}:{newNickname}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    if (response == "OK")
                    {
                        lblNickname.Text = newNickname;
                        txtNickname.Visible = false;
                        MessageBox.Show("닉네임이 변경되었습니다.", "변경 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblNickname.Visible = true;
                        txtNickname.Visible = false;
                        MessageBox.Show("닉네임 변경 실패: " + response);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"닉네임 변경 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("정말로 계정을 삭제하시겠습니까?", "계정 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string message = $"DELETE_ACCOUNT:{userId}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    if (response == "OK")
                    {
                        MessageBox.Show("계정이 성공적으로 삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stream?.Close();
                        client?.Close();
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
