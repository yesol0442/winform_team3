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

namespace client.menuControl
{
    public partial class 초기화면 : UserControl
    {
        string connectionString = @"Server=localhost\WINFORM_DB;Database=Winform_DB;Trusted_Connection=True;";

        private TcpClient client;
        private NetworkStream stream;

        public event EventHandler LoginSuccess;


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
            ConnectToServer();
            txtId.PlaceholderText = "아이디를 입력하세요.";
        }

        private bool ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5000);
                stream = client.GetStream();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"서버 연결 실패: {ex.Message}");
                return false;
            }
        }

        private void ReconnectToServer()
        {
            try
            {
                stream?.Close();
                client?.Close();
                ConnectToServer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"재연결 실패: {ex.Message}", "네트워크 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ReconnectToServer();
            string userId = txtId.Text.Trim();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("아이디를 입력하세요.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string message = $"LOGIN:{userId}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    if (response == "LOGIN_SUCCESS")
                    {
                        MessageBox.Show("로그인 성공");
                        this.Hide();
                        LoginSuccess?.Invoke(this, EventArgs.Empty);
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
            }
            catch (IOException ex)
            {
                MessageBox.Show($"서버와의 연결이 끊어졌습니다: {ex.Message}", "네트워크 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReconnectToServer();
                txtId.Clear();
                txtId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 중 오류 발생: {ex.Message}", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReconnectToServer();
                txtId.Clear();
                txtId.Focus();
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            ReconnectToServer();
            string userId = txtId.Text.Trim();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("아이디를 입력하세요.", "회원가입 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string message = $"REGISTER:{userId}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    if (response == "REGISTER_SUCCESS")
                    {
                        MessageBox.Show("회원가입 성공");
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
            }
            catch (IOException ex)
            {
                MessageBox.Show($"서버와의 연결이 끊어졌습니다: {ex.Message}", "네트워크 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReconnectToServer();
                txtId.Clear();
                txtId.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"회원가입 중 오류 발생: {ex.Message}", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReconnectToServer();
                txtId.Clear();
                txtId.Focus();
            }
        }

    }
}