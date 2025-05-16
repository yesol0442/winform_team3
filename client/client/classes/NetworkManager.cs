using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client.classes.NetworkManager
{
    public class NetworkManager
    {
        private static NetworkManager instance;
        private TcpClient client;
        private NetworkStream stream;

        private NetworkManager() { }

        public static NetworkManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NetworkManager();
                }
                return instance;
            }
        }

        public async Task ConnectAsync(string serverAddress, int port)
        {
            if (client != null && client.Connected)
            {
                Console.WriteLine("[클라이언트] 이미 서버와 연결된 상태입니다.");
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(serverAddress, port);
                stream = client.GetStream();
                Console.WriteLine("[클라이언트] 서버와 연결되었습니다.");
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"[클라이언트] 서버 연결 실패: {ex.Message}");
                Disconnect();
                throw; // 상위에서 처리할 수 있도록 예외 던짐
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[클라이언트] 서버 연결 중 오류 발생: {ex.Message}");
                Disconnect();
                throw;
            }
        }

        public void Disconnect()
        {
            try
            {
                stream?.Close();
                client?.Close();
                client = null;
                stream = null;
                Console.WriteLine("[클라이언트] 서버와의 연결이 종료되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[클라이언트] 연결 종료 중 오류 발생: {ex.Message}");
            }
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                if (stream != null && client != null && client.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    Console.WriteLine($"[클라이언트] 메시지 전송: {message}");
                }
                else
                {
                    Console.WriteLine("[클라이언트] 연결이 끊어졌거나 초기화되지 않았습니다.");
                    throw new InvalidOperationException("서버와의 연결이 끊어졌습니다.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[클라이언트] 연결 상태 오류: {ex.Message}");
                // 연결이 끊어졌을 때는 재연결 시도
                await ReconnectAsync();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[클라이언트] 메시지 전송 중 오류 발생: {ex.Message}");
                // 연결이 끊어졌을 때는 재연결 시도
                await ReconnectAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[클라이언트] 메시지 전송 중 알 수 없는 오류 발생: {ex.Message}");
                throw;
            }
        }

        public async Task<string> ReceiveMessageAsync()
        {
            try
            {
                if (stream != null && client.Connected)
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                        Console.WriteLine($"[서버 응답] {response}");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[클라이언트] 메시지 수신 중 오류 발생: {ex.Message}");
            }
            return null;
        }

        private async Task ReconnectAsync()
        {
            try
            {
                Console.WriteLine("[클라이언트] 서버와의 연결 복구 시도 중...");
                Disconnect();  // 기존 연결 정리
                await ConnectAsync("127.0.0.1", 5000);  // 서버 주소와 포트를 수정하세요
                Console.WriteLine("[클라이언트] 서버와의 연결이 복구되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[클라이언트] 서버와의 연결 복구 실패: {ex.Message}");
            }
        }

        public bool IsConnected()
        {
            return client != null && client.Connected;
        }
    }
}
