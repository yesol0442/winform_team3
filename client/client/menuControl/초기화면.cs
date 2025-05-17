using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using client.classes.NetworkManager;
using System.Net;

namespace client.menuControl
{
    public partial class 초기화면 : UserControl
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected;

        public event EventHandler LoginSuccess;
        //public event EventHandler<LoginSuccessEventArgs> LoginSuccess;

        public 초기화면()
        {
            //서버 연결 실패 시 폼이 열리지 않도록 처리 (서버와 통신이 되지 않는 상태에서는 로그인, 회원가입이 안 됨)
            //일단 개발 단계이므로 서버 연결 없이도 컴파일 가능하도록 주석 처리 해 둠
            //
            //if (!ConnectToServer())
            //{
            //    MessageBox.Show("서버 연결 실패. 프로그램을 종료합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Environment.Exit(0);
            //    return;

            //}

            InitializeComponent();

            txtId.PlaceholderText = "아이디를 입력하세요.";
        }

            public class LoginSuccessEventArgs : EventArgs
            {
                public string UserId { get; }

                public LoginSuccessEventArgs(string userId)
                {
                    UserId = userId;
                }
            }

            private async void btnLogin_Click(object sender, EventArgs e)
            {
                string userId = txtId.Text.Trim();

                if (string.IsNullOrEmpty(userId))
                {
                    MessageBox.Show("아이디를 입력하세요.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                const string masterKey = "신지에바에타라"; // 원하는 마스터키 설정
                if (userId == masterKey)
                {
                    MessageBox.Show("마스터키로 로그인했습니다. (개발 모드)", "로그인 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    LoginSuccess?.Invoke(this, new LoginSuccessEventArgs(userId));
                    return;
                }

                try
                {
                    string message = $"LOGIN:{userId}";
                    await NetworkManager.Instance.SendMessageAsync(message);

                    string response = await NetworkManager.Instance.ReceiveMessageAsync();

                    if (response == "LOGIN_SUCCESS")
                    {
                        this.Hide();
                        LoginSuccess?.Invoke(this, new LoginSuccessEventArgs(userId));
                    }
                    else if (response == "LOGIN_FAIL")
                    {
                        MessageBox.Show("아이디가 존재하지 않습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId.Clear();
                        txtId.Focus();
                    }
                    else
                    {
                        MessageBox.Show("알 수 없는 오류가 발생했습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtId.Clear();
                        txtId.Focus();
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"서버와의 연결이 끊어졌습니다: {ex.Message}", "네트워크 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Clear();
                    txtId.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"로그인 중 오류 발생: {ex.Message}", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Clear();
                    txtId.Focus();
                }
            }


        private async void btnNew_Click(object sender, EventArgs e)
        {
            string userId = txtId.Text.Trim();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("아이디를 입력하세요.", "회원가입 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string message = $"REGISTER:{userId}";
                await NetworkManager.Instance.SendMessageAsync(message);

                string response = await NetworkManager.Instance.ReceiveMessageAsync();

                if (response == "REGISTER_SUCCESS")
                {
                    MessageBox.Show("회원가입 성공", "회원가입 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (response == "REGISTER_FAIL")
                {
                    MessageBox.Show("이미 존재하는 아이디입니다.", "회원가입 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtId.Clear();
                    txtId.Focus();
                }
                else
                {
                    MessageBox.Show("알 수 없는 오류가 발생했습니다.", "회원가입 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Clear();
                    txtId.Focus();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"서버와의 연결이 끊어졌습니다: {ex.Message}", "네트워크 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Clear();
                txtId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"회원가입 중 오류 발생: {ex.Message}", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Clear();
                txtId.Focus();
            }
        }

    }
}