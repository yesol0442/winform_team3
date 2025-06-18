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
using client.classes;


namespace client.menuControl
{
    public partial class 환경설정 : UserControl
    {
        public event EventHandler CheckBoxChecked;
        //public event EventHandler<LanguageChangedEventArgs> LanguageChanged;

        private bool soundEnabled = true;
        public static string currentUserId;

        public 환경설정()
        {
            InitializeComponent();
            txtNickname.Visible = false;
        }


        public async Task SetCurrentUserIdAsync(string userId)
        {
            currentUserId = userId;
            await LoadUserProfileAsync(currentUserId);
        }

        public async Task LoadUserProfileAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("사용자 ID가 유효하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 서버에 프로필 로드 요청
                string message = $"LOAD_PROFILE:{userId}";
                await NetworkManager.Instance.SendMessageAsync(message);
                MessageBox.Show("서버에 프로필 로드 요청 전송 완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 헤더 수신
                string headerResponse = await NetworkManager.Instance.ReceiveHeaderAsync();

                if (headerResponse == null)
                {
                    MessageBox.Show("프로필 로드 실패", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                headerResponse = headerResponse.Replace("::END_HEADER::", "");

                // 닉네임 및 이미지 데이터 분리
                string[] parts = headerResponse.Split(new char[] { ':' }, 3);
                if (parts.Length < 2)
                {
                    MessageBox.Show("프로필 데이터가 잘못되었습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nickname = parts[1];
                string base64ImageStart = parts.Length == 3 ? parts[2] : "";

                // UI 업데이트
                if (txtNickname.InvokeRequired)
                {
                    txtNickname.Invoke(new Action(() =>
                    {
                        txtNickname.Text = nickname;
                        lblNickname.Text = nickname;
                    }));
                }
                else
                {
                    txtNickname.Text = nickname;
                    lblNickname.Text = nickname;
                }

                MessageBox.Show($"닉네임 설정 완료: {nickname}", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 이미지 수신
                string fullBase64Image = await NetworkManager.Instance.ReceiveFullMessageUntilEndAsync(base64ImageStart);
                MessageBox.Show($"최종 이미지 데이터 길이: {fullBase64Image?.Length}", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (string.IsNullOrEmpty(fullBase64Image))
                {
                    MessageBox.Show("프로필 이미지 데이터가 비어 있습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetProfileImage(null);
                    return;
                }

                try
                {
                    byte[] imageBytes = Convert.FromBase64String(fullBase64Image);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image img = Image.FromStream(ms);
                        SetProfileImage(img);
                    }
                    MessageBox.Show("프로필 이미지 설정 완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"프로필 이미지 데이터가 손상되었습니다.\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetProfileImage(null);
                }

                MessageBox.Show("유저 프로필 로드 완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"프로필 로드 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetProfileImage(Image img)
        {
            if (picProfile.InvokeRequired)
            {
                picProfile.Invoke(new Action(() =>
                {
                    picProfile.Image = img;
                }));
            }
            else
            {
                picProfile.Image = img;
            }
        }

        private async void btn_modPicture_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentUserId))
            {
                MessageBox.Show("사용자 ID가 설정되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                        int chunkSize = 1024;
                        int i = 0;

                        int remaining = base64Image.Length - i;
                        string firstChunk = base64Image.Substring(i, Math.Min(chunkSize, remaining));
                        string firstMessage = $"UPDATE_PROFILE_IMAGE:{currentUserId}:{firstChunk}";
                        await NetworkManager.Instance.SendMessageAsync(firstMessage);
                        i += chunkSize;

                        for (; i < base64Image.Length; i += chunkSize)
                        {
                            remaining = base64Image.Length - i;
                            string chunk = base64Image.Substring(i, Math.Min(chunkSize, remaining));
                            await NetworkManager.Instance.SendMessageAsync(chunk);
                        }

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

                if (string.IsNullOrEmpty(currentUserId))
                {
                    MessageBox.Show("사용자 ID가 설정되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string newNickname = txtNickname.Text.Trim();

                if (string.IsNullOrEmpty(newNickname) || newNickname.Length > 10)
                {
                    MessageBox.Show("닉네임은 1자 이상 10자 이하여야 합니다.");
                    return;
                }

                try
                {
                    string message = $"UPDATE_NICKNAME:{currentUserId}:{newNickname}";
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
            if (string.IsNullOrEmpty(currentUserId))
            {
                MessageBox.Show("사용자 ID가 설정되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("정말로 계정을 삭제하시겠습니까?", "계정 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string message = $"DELETE_ACCOUNT:{currentUserId}";
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
            if (chkGuide.Checked)
            {
                CheckBoxChecked?.Invoke(this, EventArgs.Empty);
            }
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
            string selected = cmbLanguage.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selected))
            {
                //LanguageChanged?.Invoke(this, new LanguageChangedEventArgs(selected));
            }
        }


    }
}
