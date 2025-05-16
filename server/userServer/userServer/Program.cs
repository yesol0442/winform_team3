using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using server;
using System.IO;

namespace server
{
    class Server
    {
        private TcpListener listener;
        private const int PORT = 5000;

        private readonly string connectionString = @"Server=localhost\WINFORM_DB;Database=Winform_DB;Trusted_Connection=True;";

        public Server()
        {
            listener = new TcpListener(IPAddress.Any, PORT);
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine($"[서버 시작] 포트 {PORT}에서 클라이언트 대기 중...");
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("[클라이언트 연결됨]");
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    // 바이트 배열을 문자열로 변환
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    Console.WriteLine($"[요청] {message}");

                    string response = "UNKNOWN_COMMAND";

                    // 명령어 처리
                    if (message.StartsWith("LOGIN:"))
                    {
                        string userId = message.Substring(6).Trim();  // 정수형 인덱스 사용
                        response = ValidateUser(userId) ? "LOGIN_SUCCESS" : "LOGIN_FAIL";
                    }
                    else if (message.StartsWith("REGISTER:"))
                    {
                        string userId = message.Substring(9).Trim();
                        response = AddNewUserToDatabase(userId) ? "REGISTER_SUCCESS" : "REGISTER_FAIL";
                    }
                    else if (message.StartsWith("LOAD_PROFILE:"))
                    {
                        string userId = message.Substring(13).Trim();
                        response = GetUserProfile(userId);
                    }
                    else if (message.StartsWith("UPDATE_PROFILE_IMAGE:"))
                    {
                        string[] parts = message.Split(new[] { ':' }, 3);

                        if (parts.Length == 3)
                        {
                            string userId = parts[1].Trim();
                            string relativeImagePath = parts[2].Trim();
                            response = UpdateProfileImage(userId, relativeImagePath) ? "OK" : "IMAGE_UPDATE_FAIL";
                        }
                    }
                    else if (message.StartsWith("UPDATE_NICKNAME:"))
                    {
                        string[] parts = message.Split(new[] { ':' }, 3);

                        if (parts.Length == 3)
                        {
                            string userId = parts[1].Trim();
                            string newNickname = parts[2].Trim();
                            response = UpdateNickname(userId, newNickname) ? "OK" : "NICKNAME_UPDATE_FAIL";
                        }
                    }
                    else if (message.StartsWith("DELETE_ACCOUNT:"))
                    {
                        string userId = message.Substring(16).Trim();
                        response = DeleteAccount(userId) ? "OK" : "DELETE_FAIL";
                    }

                    // 응답 메시지 전송
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);  // byte[]와 길이를 전달
                    Console.WriteLine($"[응답 전송] {response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[서버 오류] {ex.Message}");
            }
            finally
            {
                client.Close();
                Console.WriteLine("[클라이언트 연결 종료]");
            }
        }

        private bool ValidateUser(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 아이디가 존재하는지 확인
                    string query = "SELECT COUNT(*) FROM Users WHERE userId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
                return false;
            }
        }

        private bool AddNewUserToDatabase(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 이미 존재하는 아이디 체크
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE userId = @userId";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@userId", userId);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            Console.WriteLine("[알림] 이미 존재하는 아이디입니다.");
                            return false;
                        }
                    }

                    // 기본 프로필 이미지 로드
                    byte[] profileImageBytes;
                    try
                    {
                        // 실행 파일 기준으로 Resources 폴더 접근
                        string projectRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Resources\신지.jpeg");
                        projectRoot = Path.GetFullPath(projectRoot);

                        if (!File.Exists(projectRoot))
                        {
                            Console.WriteLine("[오류] 기본 프로필 이미지가 존재하지 않습니다.");
                            return false;
                        }

                        profileImageBytes = File.ReadAllBytes(projectRoot);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[오류] 기본 프로필 이미지 로드 중 오류 발생: {ex.Message}");
                        return false;
                    }

                    // DB에 사용자 정보 저장
                    string insertQuery = "INSERT INTO Users (userId, nickName, profilePic) VALUES (@userId, @nickName, @profilePic)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@nickName", "홍길동");
                        cmd.Parameters.AddWithValue("@profilePic", profileImageBytes);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
                return false;
            }
        }

        private string GetUserProfile(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT nickName, profilePic FROM Users WHERE userId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nickname = reader.GetString(0);
                                byte[] profilePicBytes = (byte[])reader.GetValue(1);

                                // 이미지 데이터를 base64 문자열로 변환
                                string base64Image = Convert.ToBase64String(profilePicBytes);

                                // 닉네임과 base64 인코딩된 이미지 데이터를 : 로 구분하여 반환
                                return $"PROFILE:{nickname}:{base64Image}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
            }
            return "PROFILE_LOAD_FAIL";
        }

        private bool UpdateProfileImage(string userId, string relativeImagePath)
        {
            try
            {
                // 이미지 파일 경로 변환
                string fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..", relativeImagePath));

                // 파일이 존재하는지 확인
                if (!File.Exists(fullPath))
                {
                    Console.WriteLine($"[이미지 오류] 파일을 찾을 수 없습니다: {fullPath}");
                    return false;
                }

                // 이미지 파일을 바이트 배열로 읽기
                byte[] imageBytes = File.ReadAllBytes(fullPath);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET profilePic = @profilePic WHERE userId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@profilePic", imageBytes);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
                return false;
            }
        }
        private bool UpdateNickname(string userId, string newNickname)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET nickName = @nickName WHERE userId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nickName", newNickname);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
                return false;
            }
        }


        private bool DeleteAccount(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 프로필 이미지 삭제
                    string selectQuery = "SELECT profilePic FROM Users WHERE userId = @userId";
                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@userId", userId);
                        string profilePicPath = (string)selectCmd.ExecuteScalar();

                        if (!string.IsNullOrEmpty(profilePicPath))
                        {
                            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, profilePicPath);
                            if (File.Exists(fullPath))
                            {
                                File.Delete(fullPath);
                            }
                        }
                    }

                    // 계정 삭제
                    string deleteQuery = "DELETE FROM Users WHERE userId = @userId";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@userId", userId);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
                return false;
            }
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        Server server = new Server();
        server.Start();
    }
}