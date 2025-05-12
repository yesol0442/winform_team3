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

namespace client.menuControl
{
    public partial class 초기화면 : UserControl
    {
        public event EventHandler LoginSuccess;
        public 초기화면()
        {
            InitializeComponent();
            txtId.PlaceholderText = "아이디를 입력하세요.";
        }

        // 로그인 버튼
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtId.Text;

            if (userId == "id")  // 검증
            {
                // 사용자 데이터 가져오기



                this.Hide();
                LoginSuccess?.Invoke(this, EventArgs.Empty);

            }
            else
            {
                MessageBox.Show("아이디가 틀렸습니다.", "로그인 실패",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtId.Clear();
                txtId.Focus();
            }

        }

        // 새로 만들기 버튼
        private void btnNew_Click(object sender, EventArgs e)
        {
            // RegisterUser();

        }


        // 새 아이디 부여하는 함수
        private void RegisterUser()
        {
            string connStr = "Server=서버이름;Database=DB이름;Integrated Security=true;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 먼저 임시로 ID만 넣어서 INSERT하고, ID 값 받아오기
                string insertQuery = "INSERT INTO Users (Username, Password) VALUES ('temp', ''); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    // ID 받아오기
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());

                    // ID를 Username으로 업데이트
                    string updateQuery = "UPDATE Users SET Username = @username WHERE Id = @id";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@username", newId.ToString());
                        updateCmd.Parameters.AddWithValue("@id", newId);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"회원가입 성공! ID: {newId}, Username: {newId}");
                }
            }

        }
    }
}
