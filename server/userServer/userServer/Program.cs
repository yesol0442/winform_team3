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

        private string ProcessRequest(TcpClient client, string message) // 여기에 else if문을 추가해서 각 요청에 대한 처리를 추가
        {
            if (message.StartsWith("LOGIN:"))
            {
                string prefix = "LOGIN:";
                string userId = message.Substring(prefix.Length).Trim();
                return ValidateUser(userId) ? "LOGIN_SUCCESS" : "LOGIN_FAIL";
            }
            else if (message.StartsWith("REGISTER:"))
            {
                string prefix = "REGISTER:";
                string userId = message.Substring(prefix.Length).Trim();
                return AddNewUserToDatabase(userId) ? "REGISTER_SUCCESS" : "REGISTER_FAIL";
            }
            else if (message.StartsWith("LOAD_PROFILE:"))
            {
                string prefix = "LOAD_PROFILE:";
                string userId = message.Substring(prefix.Length).Trim();
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
                Console.WriteLine($"프로필 이미지 전송 완료");

                return "";
            }
            else if (message.StartsWith("UPDATE_PROFILE_IMAGE:"))
            {
                string prefix = "UPDATE_PROFILE_IMAGE:";
                string[] parts = message.Substring(prefix.Length).Split(':');
                if (parts.Length >= 2)
                {
                    string userId = parts[0].Trim();
                    // base64Image는 :로 분리되면서 조각날 수 있으니 다시 합쳐야 함
                    string base64ImageStart = string.Join(":", parts, 1, parts.Length - 1).Trim();

                    StringBuilder imageDataBuilder = new StringBuilder();
                    imageDataBuilder.Append(base64ImageStart);

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
                else
                {
                    return "INVALID_UPDATE_PROFILE_IMAGE_COMMAND";
                }
            }
            else if (message.StartsWith("UPDATE_NICKNAME:"))
            {
                string prefix = "UPDATE_NICKNAME:";
                string[] parts = message.Substring(prefix.Length).Split(':');
                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    string newNickname = parts[1].Trim();
                    return UpdateNickname(userId, newNickname) ? "OK" : "NICKNAME_UPDATE_FAIL";
                }
                else
                {
                    return "INVALID_UPDATE_NICKNAME_COMMAND";
                }
            }
            else if (message.StartsWith("DELETE_ACCOUNT:"))
            {
                string prefix = "DELETE_ACCOUNT:";
                string userId = message.Substring(prefix.Length).Trim();
                return DeleteAccount(userId) ? "OK" : "DELETE_FAIL";
            }

            // --------------------------------------- 환경설정 용 ------------------------------------ //

            else if (message.StartsWith("LOAD_STATS:"))
            {
                string prefix = "LOAD_STATS:";
                string userId = message.Substring(prefix.Length).Trim();
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
            else if (message.StartsWith("UPDATE_STROKE_NUMBER:"))
            {
                string prefix = "UPDATE_STROKE_NUMBER:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int newStrokeNumber))
                    {
                        bool result = UpdateStrokeNumber(userId, newStrokeNumber);
                        return result ? "OK" : "FAIL";
                    }
                }
            }
            else if (message.StartsWith("UPDATE_ACCURANCY:"))
            {
                string prefix = "UPDATE_ACCURANCY:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int newAccurancy))
                    {
                        bool result = UpdateAccurancy(userId, newAccurancy);
                        return result ? "OK" : "FAIL";
                    }
                }
            }
            else if (message.StartsWith("UPDATE_RAINMAXSCORE:"))
            {
                string prefix = "UPDATE_RAINMAXSCORE:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int newRainMaxScore))
                    {
                        bool result = UpdateRainMaxScore(userId, newRainMaxScore);
                        return result ? "OK" : "FAIL";
                    }
                }
            }
            else if (message.StartsWith("UPDATE_RAINMAXLEVEL:"))
            {
                string prefix = "UPDATE_RAINMAXLEVEL:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int newRainMaxLevel))
                    {
                        bool result = UpdateRainMaxLevel(userId, newRainMaxLevel);
                        return result ? "OK" : "FAIL";
                    }
                }
            }
            else if (message.StartsWith("UPDATE_BLOCKRECORD:"))
            {
                string prefix = "UPDATE_BLOCKRECORD:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (float.TryParse(parts[1].Trim(), out float newBlockRecord))
                    {
                        bool result = UpdateBlockRecord(userId, newBlockRecord);
                        return result ? "OK" : "FAIL";
                    }
                }
            }
            else if (message.StartsWith("UPDATE_QUIZMAXSCORE:"))
            {
                string prefix = "UPDATE_QUIZMAXSCORE:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (int.TryParse(parts[1].Trim(), out int newQuizMaxScore))
                    {
                        bool result = UpdateQuizMaxScore(userId, newQuizMaxScore);
                        return result ? "OK" : "FAIL";
                    }
                }
            }
            else if (message.StartsWith("UPDATE_QUIZWINRATE:"))
            {
                string prefix = "UPDATE_QUIZWINRATE:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (float.TryParse(parts[1].Trim(), out float newQuizWinRate))
                    {
                        bool result = UpdateQuizWinRate(userId, newQuizWinRate);
                        return result ? "OK" : "FAIL";
                    }
                }
            }
            else if (message.StartsWith("UPDATE_FOUNDWINRATE:"))
            {
                string prefix = "UPDATE_FOUNDWINRATE:";
                string[] parts = message.Substring(prefix.Length).Split(':');

                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    if (float.TryParse(parts[1].Trim(), out float newFoundWinRate))
                    {
                        bool result = UpdateFoundWinRate(userId, newFoundWinRate);
                        return result ? "OK" : "FAIL";
                    }
                }
            }

            // --------------------------------------- 홈 용 ------------------------------------ //

            else if (message.StartsWith("GET_CODE_TITLES:"))
            {
                string prefix = "GET_CODE_TITLES:";
                string userId = message.Substring(prefix.Length).Trim();

                return GetCodeBriefInfo(userId);
            }
            else if (message.StartsWith("GET_USER_CODE_LIST:"))
            {
                string prefix = "GET_USER_CODE_LIST:";
                string userId = message.Substring(prefix.Length).Trim();
                return GetUserCodeList(userId);
            }
            else if (message.StartsWith("GET_OTHER_USER_CODE_LIST:"))
            {
                string prefix = "GET_OTHER_USER_CODE_LIST:";
                string userId = message.Substring(prefix.Length).Trim();
                return GetOtherUserCodeList(userId);
            }
            else if (message.StartsWith("GET_CODE_PRACTICE:"))
            {
                string prefix = "GET_CODE_PRACTICE:";
                string[] parts = message.Substring(prefix.Length).Split(':');
                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    int codeId = int.Parse(parts[1].Trim());
                    CodePractice code = GetCodePractice(userId, codeId);
                    if (code == null)
                        return "코드 정보를 찾을 수 없습니다";

                    // 헤더: 모든 통계 데이터 문자열 (프로필 사진 제외) + 구분자
                    string header = $"{code.NickName}|{code.CodeTitle}|{code.CodeLevel}|" +
                                    $"{code.CodeDescription}|{code.CodeContent}::END_HEADER::";

                    NetworkStream stream = client.GetStream();

                    byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                    stream.Write(headerBytes, 0, headerBytes.Length);
                    Console.WriteLine("코드 정보 헤더 전송 완료");

                    // 프로필 이미지 전송 (Base64로 변환하여 청크 전송)
                    byte[] imageBytes = code.ProfilePicBytes;
                    if (imageBytes.Length == 0)
                    {
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

                    // 프로필 이미지 전송 완료
                    byte[] endBytesFinal = Encoding.UTF8.GetBytes("::END::");
                    stream.Write(endBytesFinal, 0, endBytesFinal.Length);
                    Console.WriteLine("프로필 이미지 전송 완료");

                    return "";
                }
            }
            else if (message.StartsWith("GET_SHARE_CODE_SAVE:"))
            {
                string prefix = "GET_SHARE_CODE_SAVE:";
                string[] parts = message.Substring(prefix.Length).Split(':');
                if (parts.Length == 2)
                {
                    string userId = parts[0].Trim();
                    int codeId = int.Parse(parts[1].Trim());
                    return GetShareCodeSave(userId, codeId);
                }
            }
            else if (message.StartsWith("INSERT_CODE_POST:"))
            {
                string prefix = "INSERT_CODE_POST:";
                string[] parts = message.Substring(prefix.Length).Split(':');
                if (parts.Length == 7)
                {
                    string userId = Uri.UnescapeDataString(parts[0].Trim());
                    string title = Uri.UnescapeDataString(parts[1].Trim());
                    if (!int.TryParse(parts[2].Trim(), out int level))
                        return "레벨 형식이 올바르지 않습니다";
                    string source = Uri.UnescapeDataString(parts[3].Trim());
                    string desc = Uri.UnescapeDataString(parts[4].Trim());
                    string content = Uri.UnescapeDataString(parts[5].Trim());
                    if (!bool.TryParse(parts[6].Trim(), out bool status))
                        return "공유 여부 형식이 올바르지 않습니다 (true/false)";

                    bool success = InsertCodePost(userId, title, level, source, desc, content, status);
                    return success ? "CODE_INSERT_SUCCESS" : "CODE_INSERT_FAIL";
                }
                else
                {
                    return "CODE_INSERT_FORMAT_ERROR";
                }
            }
            else if (message.StartsWith("UPDATE_CODE_POST:"))
            {
                string prefix = "UPDATE_CODE_POST:";
                string[] parts = message.Substring(prefix.Length).Split(':');
                if (parts.Length == 8)
                {
                    if (!int.TryParse(Uri.UnescapeDataString(parts[0]).Trim(), out int codeId))
                        return "코드 ID 형식 오류";
                    string userId = Uri.UnescapeDataString(parts[1].Trim());
                    string newTitle = Uri.UnescapeDataString(parts[2]).Trim();
                    if (!int.TryParse(parts[3].Trim(), out int newLevel))
                        return "레벨 형식 오류";
                    string newSource = Uri.UnescapeDataString(parts[4].Trim());
                    string newDesc = Uri.UnescapeDataString(parts[5]).Trim();
                    string newContent = Uri.UnescapeDataString(parts[6].Trim());
                    if (!bool.TryParse(parts[7].Trim(), out bool newStatus))
                        return "공유 여부 형식 오류 (true/false)";

                    bool success = UpdateCodePost(codeId, userId, newTitle, newLevel, newSource, newDesc, newContent, newStatus);
                    return success ? "CODE_UPDATE_SUCCESS" : "CODE_UPDATE_FAIL";
                }
                else
                {
                    return "CODE_UPDATE_FORMAT_ERROR";
                }
            }
            else if (message.StartsWith("DELETE_CODE_POST:"))
            {
                string prefix = "DELETE_CODE_POST:";
                string[] parts = message.Substring(prefix.Length).Split(':');
                if (parts.Length == 2)
                {
                    if (!int.TryParse(parts[0].Trim(), out int codeId))
                        return "코드 ID 형식 오류";
                    string userId = parts[1].Trim();

                    bool success = DeleteCodePost(codeId, userId);
                    return success ? "CODE_DELETE_SUCCESS" : "CODE_DELETE_FAIL";
                }
                else
                {
                    return "CODE_DELETE_FORMAT_ERROR";
                }
            }
            
            // --------------------------------------- 공유함 용 ------------------------------------ //


            return "UNKNOWN_COMMAND";
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------ //

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

        // --------------------------------------- 환경설정 용 ------------------------------------ //

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
            string query = @"SELECT U.nickName, S.strokeNumber, S.accurancy, S.mainLanguage, 
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

        private bool UpdateStrokeNumber(string userId, int newStrokeNumber)
        {
            string query = @"UPDATE UserStats SET strokeNumber = @strokeNumber WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@strokeNumber", newStrokeNumber);
                        command.Parameters.AddWithValue("@userId", userId);
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE StrokeNumber] " + ex.Message);
                return false;
            }
        }

        private bool UpdateAccurancy(string userId, int newAccurancy)
        {
            string query = @"UPDATE UserStats SET accurancy = @accurancy WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@accurancy", newAccurancy);
                        command.Parameters.AddWithValue("@userId", userId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE Accurancy] " + ex.Message);
                return false;
            }
        }

        private bool UpdateRainMaxScore(string userId, int newScore)
        {
            string query = @"UPDATE UserStats SET rainMaxScore = @score WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@score", newScore);
                        command.Parameters.AddWithValue("@userId", userId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE RainMaxScore] " + ex.Message);
                return false;
            }
        }

        private bool UpdateRainMaxLevel(string userId, int newLevel)
        {
            string query = @"UPDATE UserStats SET rainMaxLevel = @level WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@level", newLevel);
                        command.Parameters.AddWithValue("@userId", userId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE RainMaxLevel] " + ex.Message);
                return false;
            }
        }

        private bool UpdateBlockRecord(string userId, float newRecord)
        {
            string query = @"UPDATE UserStats SET blockRecord = @record WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@record", newRecord);
                        command.Parameters.AddWithValue("@userId", userId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE BlockRecord] " + ex.Message);
                return false;
            }
        }

        private bool UpdateQuizMaxScore(string userId, int newScore)
        {
            string query = @"UPDATE UserStats SET quizMaxScore = @score WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@score", newScore);
                        command.Parameters.AddWithValue("@userId", userId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE QuizMaxScore] " + ex.Message);
                return false;
            }
        }

        private bool UpdateQuizWinRate(string userId, float newRate)
        {
            string query = @"UPDATE UserStats SET quizWinRate = @rate WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@rate", newRate);
                        command.Parameters.AddWithValue("@userId", userId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE QuizWinRate] " + ex.Message);
                return false;
            }
        }

        private bool UpdateFoundWinRate(string userId, float newRate)
        {
            string query = @"UPDATE UserStats SET foundWinRate = @rate WHERE userId = @userId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@rate", newRate);
                        command.Parameters.AddWithValue("@userId", userId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE FoundWinRate] " + ex.Message);
                return false;
            }
        }

        // --------------------------------------- 홈 용 ------------------------------------ //

        private string GetCodeBriefInfo(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT codeTitle, codeId, userId FROM CodePost WHERE shareStatus = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder result = new StringBuilder();
                            while (reader.Read())
                            {
                                string title = reader.GetString(0);
                                int codeId = reader.GetInt32(1);
                                string ownerId = reader.GetString(2);

                                result.Append($"{title}|{codeId}|{ownerId}, ");
                            }

                            // 마지막 쉼표 제거
                            return result.Length > 0 ? result.ToString().TrimEnd(',', ' ') : "공유된 코드가 없습니다";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
            }
            return "공유된 코드가 없습니다";
        }

        private string GetUserCodeList(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT codeTitle, codeId, shareStatus FROM CodePost WHERE userId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder codeList = new StringBuilder();
                            while (reader.Read())
                            {
                                string title = reader.GetString(0);
                                int codeId = reader.GetInt32(1);
                                bool shareStatus = reader.GetBoolean(2);

                                // 예: 버블정렬 : 3 : 공유
                                codeList.Append(title)
                                        .Append(" : ")
                                        .Append(codeId)
                                        .Append(" : ")
                                        .Append(shareStatus ? "공유" : "비공유")
                                        .Append(", ");
                            }

                            // 마지막 쉼표와 공백 제거
                            return codeList.Length > 0 ? codeList.ToString().TrimEnd(',', ' ') : "코드가 없습니다";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
            }
            return "코드가 없습니다";
        }

        private string GetOtherUserCodeList(string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT codeTitle, codeId FROM CodePost WHERE userId = @userId AND shareStatus = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder codeList = new StringBuilder();
                            while (reader.Read())
                            {
                                string title = reader.GetString(0);
                                int codeId = reader.GetInt32(1);
                                codeList.Append($"{title}|{codeId}, ");
                            }

                            // 마지막 쉼표 제거
                            return codeList.Length > 0 ? codeList.ToString().TrimEnd(',', ' ') : "코드가 없습니다";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
            }
            return "코드가 없습니다";
        }

        public class CodePractice
        {
            public string NickName { get; set; }
            public string CodeTitle { get; set; }
            public int CodeLevel { get; set; }
            public string CodeSource { get; set; }
            public string CodeDescription { get; set; }
            public string CodeContent { get; set; }
            public byte[] ProfilePicBytes { get; set; } = Array.Empty<byte>();

        }

        private CodePractice GetCodePractice(string userId, int codeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT u.nickName, c.codeTitle, c.codeLevel, c.codeSource, c.codeDescription, c.codeContent, u.profilePic
                                  FROM Users u
                                  JOIN CodePost c ON u.userId = c.userId
                                  WHERE u.userId = @userId AND c.codeId = @codeId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@codeId", codeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 프로필 사진만 별도 NULL 체크해서 빈 배열로 처리
                                byte[] profilePicBytes = reader.IsDBNull(reader.GetOrdinal("profilePic"))
                                    ? Array.Empty<byte>()
                                    : (byte[])reader["profilePic"];

                                return new CodePractice
                                {
                                    NickName = reader.GetString(0),
                                    CodeTitle = reader.GetString(1),
                                    CodeLevel = reader.GetInt32(2),
                                    CodeSource = reader.GetString(3),
                                    CodeDescription = reader.GetString(4),
                                    CodeContent = reader.GetString(5),
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

        private string GetShareCodeSave(string userId, int codeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT u.nickName, c.codeTitle, c.codeLevel, c.codeDescription, c.codeContent
                                  FROM Users u
                                  JOIN CodePost c ON u.userId = c.userId
                                  WHERE u.userId = @userId AND c.codeId = @codeId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@codeId", codeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return $"{reader.GetString(0)}|{reader.GetString(1)}|{reader.GetInt32(2)}|{reader.GetString(3)}|{reader.GetString(4)}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB 오류] {ex.Message}");
            }
            return "코드 정보를 찾을 수 없습니다";
        }

        public bool InsertCodePost(string userId, string codeTitle, int codeLevel, string codeSource, string codeDescription, string codeContent, bool shareStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO CodePost 
                (userId, codeTitle, codeLevel, codeSource, codeDescription, codeContent, shareStatus)
                VALUES (@userId, @title, @level, @source, @desc, @content, @status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@title", codeTitle);
                        cmd.Parameters.AddWithValue("@level", codeLevel);
                        cmd.Parameters.AddWithValue("@source", codeSource);
                        cmd.Parameters.AddWithValue("@desc", codeDescription);
                        cmd.Parameters.AddWithValue("@content", codeContent);
                        cmd.Parameters.AddWithValue("@status", shareStatus);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - INSERT] " + ex.Message);
                return false;
            }
        }

        public bool UpdateCodePost(int codeId, string userId, string newTitle, int newLevel, string newSource, string newDesc, string newContent, bool newStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE CodePost
                SET codeTitle = @title, codeLevel = @level, codeSource = @source,
                    codeDescription = @desc, codeContent = @content, shareStatus = @status
                WHERE codeId = @codeId AND userId = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codeId", codeId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@title", newTitle);
                        cmd.Parameters.AddWithValue("@level", newLevel);
                        cmd.Parameters.AddWithValue("@source", newSource);
                        cmd.Parameters.AddWithValue("@desc", newDesc);
                        cmd.Parameters.AddWithValue("@content", newContent);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - UPDATE] " + ex.Message);
                return false;
            }
        }

        public bool DeleteCodePost(int codeId, string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM CodePost WHERE codeId = @codeId AND userId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codeId", codeId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB 오류 - DELETE] " + ex.Message);
                return false;
            }
        }

        // --------------------------------------- 공유함 용 ------------------------------------ //

        // 여기에 게임용 DB 관련 메서드 추가

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
