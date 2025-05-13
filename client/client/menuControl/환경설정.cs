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

namespace client.menuControl
{
    public partial class 환경설정 : UserControl
    {
        public 환경설정()
        {
            InitializeComponent();
            txtId.Visible = false;
            lblId.Visible = false;
            txtNickname.Visible = false;
        }

        public void SaveImageToDatabase(string filePath, int userId)
        {
            // 이미지 파일을 바이너리 배열로 읽기
            byte[] imageBytes = File.ReadAllBytes(filePath);

            // SQL 연결 문자열
            string connectionString = @"Server=localhost\WINFORM_DB;Database=Winform_DB;Trusted_Connection=True;";

            // SQL 쿼리 실행
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO UserProfiles (UserID, UserName, ProfilePicture) VALUES (@UserID, @UserName, @ProfilePicture)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@UserName", "John Doe");  // 예시 사용자 이름
                    command.Parameters.AddWithValue("@ProfilePicture", imageBytes);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetImageFromDatabase(int userId)
        {
            string connectionString = @"Server=localhost\WINFORM_DB;Database=Winform_DB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProfilePicture FROM UserProfiles WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    byte[] imageBytes = command.ExecuteScalar() as byte[];

                    if (imageBytes != null)
                    {
                        File.WriteAllBytes("retrieved_image.jpg", imageBytes);
                        Console.WriteLine("Image retrieved and saved as 'retrieved_image.jpg'");
                    }
                    else
                    {
                        Console.WriteLine("No image found for this user.");
                    }
                }
            }
        }

        private void btn_modNickname_Click(object sender, EventArgs e)
        {
            txtNickname.Visible = true;
        }

        private void btn_modPicture_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtId.Visible = true;
            lblId.Visible = true;
        }

        private void chkGuide_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void togSound_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
