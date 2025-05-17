using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using server;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Net.NetworkInformation;

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

        private async Task HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[4096];

                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    Console.WriteLine($"[요청] {message}");

                    // 클라이언트 인스턴스를 전달하여 메시지 처리
                    string response = ProcessRequest(client, message);

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
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

        private string ProcessRequest(TcpClient client, string message)
        {
            if (message.StartsWith("LOGIN:"))
            {
                string userId = message.Substring(6).Trim();
                return ValidateUser(userId) ? "LOGIN_SUCCESS" : "LOGIN_FAIL";
            }
            else if (message.StartsWith("REGISTER:"))
            {
                string userId = message.Substring(9).Trim();
                return AddNewUserToDatabase(userId) ? "REGISTER_SUCCESS" : "REGISTER_FAIL";
            }
            else if (message.StartsWith("LOAD_PROFILE:"))
            {
                string userId = message.Substring(13).Trim();
                Console.WriteLine($"LOAD_PROFILE 요청: {userId}");

                var profile = GetUserProfile(userId);
                if (profile == null)
                {
                    Console.WriteLine("프로필을 찾을 수 없습니다.");
                    return "PROFILE_LOAD_FAIL";
                }

                string nickname = profile.Nickname;
                byte[] imageBytes = profile.ProfilePicBytes ?? Array.Empty<byte>();

                // 닉네임 전송
                string header = $"PROFILE:{nickname}::END_HEADER::";
                NetworkStream stream = client.GetStream();
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                stream.Write(headerBytes, 0, headerBytes.Length);
                Console.WriteLine($"프로필 닉네임 전송 완료: {nickname}");

                // 프로필 이미지가 없으면 바로 종료
                if (imageBytes.Length == 0)
                {
                    Console.WriteLine("프로필 이미지 없음");
                    byte[] endBytes = Encoding.UTF8.GetBytes("::END::");
                    stream.Write(endBytes, 0, endBytes.Length);
                    return "";
                }

                // 이미지 Base64 변환 후 청크 단위 전송
                string base64Image = Convert.ToBase64String(imageBytes);
                int chunkSize = 1024;
                for (int i = 0; i < base64Image.Length; i += chunkSize)
                {
                    int length = Math.Min(chunkSize, base64Image.Length - i);
                    string chunk = base64Image.Substring(i, length);

                    byte[] chunkBytes = Encoding.UTF8.GetBytes(chunk);
                    stream.Write(chunkBytes, 0, chunkBytes.Length);
                }

                // 청크 전송 완료 표시
                byte[] endBytesFinal = Encoding.UTF8.GetBytes("::END::");
                stream.Write(endBytesFinal, 0, endBytesFinal.Length);
                Console.WriteLine($"프로필 이미지 전송 완료: {base64Image}");

                return "";
            }

            else if (message.StartsWith("UPDATE_PROFILE_IMAGE:"))
            {
                string[] parts = message.Split(new[] { ':' }, 3);
                if (parts.Length == 3)
                {
                    string userId = parts[1].Trim();
                    string base64Image = parts[2].Trim();

                    // 긴 Base64 문자열 수신
                    StringBuilder imageDataBuilder = new StringBuilder();
                    imageDataBuilder.Append(base64Image);

                    // 추가 청크 받기
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    NetworkStream stream = client.GetStream();

                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        if (chunk.EndsWith("::END::"))
                        {
                            imageDataBuilder.Append(chunk.Replace("::END::", ""));
                            break;
                        }
                        imageDataBuilder.Append(chunk);
                    }

                    string fullBase64Image = imageDataBuilder.ToString();

                    return UpdateProfileImage(userId, fullBase64Image) ? "OK" : "IMAGE_UPDATE_FAIL";
                }
            }
            else if (message.StartsWith("UPDATE_NICKNAME:"))
            {
                string[] parts = message.Split(new[] { ':' }, 3);
                if (parts.Length == 3)
                {
                    string userId = parts[1].Trim();
                    string newNickname = parts[2].Trim();
                    return UpdateNickname(userId, newNickname) ? "OK" : "NICKNAME_UPDATE_FAIL";
                }
            }
            else if (message.StartsWith("DELETE_ACCOUNT:"))
            {
                string userId = message.Substring(15).Trim();
                return DeleteAccount(userId) ? "OK" : "DELETE_FAIL";
            }
            else if (message.StartsWith("LOAD_STATS:"))
            {
                string userId = message.Substring(11).Trim();
                Console.WriteLine($"LOAD_STATS 요청: {userId}");

                var stats = GetUserStats(userId);
                if (stats == null)
                {
                    Console.WriteLine("유저 통계 정보를 찾을 수 없습니다.");
                    return "STATS_LOAD_FAIL";
                }

                // 헤더: 모든 통계 데이터 문자열 (프로필 사진 제외) + 구분자
                string header = $"{stats.NickName}|{stats.StrokeNumber}|{stats.Accurancy}|{stats.MainLanguage}|" +
                                $"{stats.RainMaxScore}|{stats.RainMaxLevel}|{stats.BlockRecord}|" +
                                $"{stats.QuizMaxScore}|{stats.QuizWinRate}|{stats.FoundWinRate}::END_HEADER::";

                NetworkStream stream = client.GetStream();

                // 1. 헤더 전송
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                stream.Write(headerBytes, 0, headerBytes.Length);
                Console.WriteLine("유저 통계 데이터 헤더 전송 완료");

                // 2. 프로필 이미지 Base64 변환 후 청크 단위 전송
                byte[] imageBytes = stats.ProfilePicBytes ?? Array.Empty<byte>();
                if (imageBytes.Length == 0)
                {
                    Console.WriteLine("프로필 이미지 없음");
                    byte[] endBytes = Encoding.UTF8.GetBytes("::END::");
                    stream.Write(endBytes, 0, endBytes.Length);
                    return "";
                }

                string base64Image = Convert.ToBase64String(imageBytes);
                int chunkSize = 1024;
                for (int i = 0; i < base64Image.Length; i += chunkSize)
                {
                    int length = Math.Min(chunkSize, base64Image.Length - i);
                    string chunk = base64Image.Substring(i, length);

                    byte[] chunkBytes = Encoding.UTF8.GetBytes(chunk);
                    stream.Write(chunkBytes, 0, chunkBytes.Length);
                }

                // 3. 청크 전송 완료 표시
                byte[] endBytesFinal = Encoding.UTF8.GetBytes("::END::");
                stream.Write(endBytesFinal, 0, endBytesFinal.Length);
                Console.WriteLine("프로필 이미지 전송 완료");

                return "";
            }


            return "UNKNOWN_COMMAND";
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
                    byte[] profileImageBytes = null;

                    string exePath = AppDomain.CurrentDomain.BaseDirectory;
                    string defaultImagePath = Path.Combine(exePath, "..", "..", "Resources", "sky.jpg");
                    defaultImagePath = Path.GetFullPath(defaultImagePath);

                    try
                    {
                        if (File.Exists(defaultImagePath))
                        {
                            profileImageBytes = File.ReadAllBytes(defaultImagePath);
                            Console.WriteLine("[알림] 기본 프로필 이미지 로드 완료");
                        }
                        else
                        {
                            Console.WriteLine($"[경고] 기본 프로필 이미지가 존재하지 않습니다: {defaultImagePath}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[경고] 기본 프로필 이미지 로드 중 오류 발생: {ex.Message} - null로 저장합니다.");
                    }

                    // DB에 사용자 정보 저장 (profilePic이 없으면 null 저장)
                    string insertQuery = "INSERT INTO Users (userId, nickName, profilePic) VALUES (@userId, @nickName, @profilePic)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@nickName", "홍길동");

                        // 프로필 이미지 설정 (없으면 NULL 저장)
                        var profilePicParam = cmd.Parameters.Add("@profilePic", System.Data.SqlDbType.VarBinary, -1);
                        profilePicParam.Value = profileImageBytes ?? (object)DBNull.Value;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("[알림] 사용자 등록 완료.");
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


        public class UserProfile
        {
            public string Nickname { get; set; }
            public byte[] ProfilePicBytes { get; set; }
        }

        private UserProfile GetUserProfile(string userId)
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

                                byte[] profilePicBytes = null;
                                if (!reader.IsDBNull(1))
                                {
                                    profilePicBytes = (byte[])reader.GetValue(1);
                                }

                                return new UserProfile
                                {
                                    Nickname = nickname,
                                    ProfilePicBytes = profilePicBytes
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
            }
            return null; // 실패 시 null 반환
        }


        private bool UpdateProfileImage(string userId, string base64Image)
        {
            try
            {
                // Base64 문자열을 바이너리 데이터로 변환
                byte[] imageBytes = Convert.FromBase64String(base64Image);

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

                    // 계정 삭제
                    string deleteQuery = "DELETE FROM Users WHERE userId = @userId";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@userId", userId);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            Console.WriteLine($"[삭제 실패] userId '{userId}'가 존재하지 않습니다.");
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
                return false;
            }
        }

        public class UserStats
        {
            public string NickName { get; set; }
            public int StrokeNumber { get; set; }
            public int Accurancy { get; set; }
            public string MainLanguage { get; set; }
            public int RainMaxScore { get; set; }
            public int RainMaxLevel { get; set; }
            public float BlockRecord { get; set; }
            public int QuizMaxScore { get; set; }
            public float QuizWinRate { get; set; }
            public float FoundWinRate { get; set; }
            public byte[] ProfilePicBytes { get; set; } = Array.Empty<byte>(); // 빈 배열로 초기화
        }

        private UserStats GetUserStats(string userId)
        {
            string query = @"
SELECT U.nickName, S.strokeNumber, S.accurancy, S.mainLanguage, 
       S.rainMaxScore, S.rainMaxLevel, S.blockRecord, 
       S.quizMaxScore, S.quizWinRate, S.foundWinRate, U.profilePic
FROM Users U
LEFT JOIN UserStats S ON U.userId = S.userId
WHERE U.userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 프로필 사진만 별도 NULL 체크해서 빈 배열로 처리
                                byte[] profilePicBytes = reader.IsDBNull(reader.GetOrdinal("profilePic"))
                                    ? Array.Empty<byte>()
                                    : (byte[])reader["profilePic"];

                                return new UserStats
                                {
                                    NickName = reader["nickName"]?.ToString().Trim() ?? string.Empty,
                                    StrokeNumber = reader.IsDBNull(reader.GetOrdinal("strokeNumber")) ? 0 : Convert.ToInt32(reader["strokeNumber"]),
                                    Accurancy = reader.IsDBNull(reader.GetOrdinal("accurancy")) ? 0 : Convert.ToInt32(reader["accurancy"]),
                                    MainLanguage = reader["mainLanguage"]?.ToString().Trim() ?? string.Empty,
                                    RainMaxScore = reader.IsDBNull(reader.GetOrdinal("rainMaxScore")) ? 0 : Convert.ToInt32(reader["rainMaxScore"]),
                                    RainMaxLevel = reader.IsDBNull(reader.GetOrdinal("rainMaxLevel")) ? 0 : Convert.ToInt32(reader["rainMaxLevel"]),
                                    BlockRecord = reader.IsDBNull(reader.GetOrdinal("blockRecord")) ? 0f : Convert.ToSingle(reader["blockRecord"]),
                                    QuizMaxScore = reader.IsDBNull(reader.GetOrdinal("quizMaxScore")) ? 0 : Convert.ToInt32(reader["quizMaxScore"]),
                                    QuizWinRate = reader.IsDBNull(reader.GetOrdinal("quizWinRate")) ? 0f : Convert.ToSingle(reader["quizWinRate"]),
                                    FoundWinRate = reader.IsDBNull(reader.GetOrdinal("foundWinRate")) ? 0f : Convert.ToSingle(reader["foundWinRate"]),
                                    ProfilePicBytes = profilePicBytes
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
            }

            return null;
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