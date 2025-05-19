using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

public class CodeGameServer
{
    public static async Task Main(string[] args)
    {
        // 서버 시작 (포트 9000 사용)
        TcpListener server = new TcpListener(IPAddress.Any, 9000);
        server.Start();
        Console.WriteLine("서버가 시작되었습니다. 클라이언트 2명을 기다리는 중...");

        // 첫 번째 클라이언트 연결 대기
        TcpClient client1 = await server.AcceptTcpClientAsync();
        Console.WriteLine("클라이언트 1 연결됨");

        // 두 번째 클라이언트 연결 대기
        TcpClient client2 = await server.AcceptTcpClientAsync();
        Console.WriteLine("클라이언트 2 연결됨");

        // 각 클라이언트의 읽기/쓰기 스트림 준비
        var reader1 = new StreamReader(client1.GetStream());
        var writer1 = new StreamWriter(client1.GetStream()) { AutoFlush = true };

        var reader2 = new StreamReader(client2.GetStream());
        var writer2 = new StreamWriter(client2.GetStream()) { AutoFlush = true };

        // 클라이언트 1 → 2 메시지 전달
        _ = Task.Run(async () =>
        {
            while (true)
            {
                string message = await reader1.ReadLineAsync();
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine($"1 → 2 : {message}");
                    await writer2.WriteLineAsync(message);
                }
            }
        });

        // 클라이언트 2 → 1 메시지 전달
        _ = Task.Run(async () =>
        {
            while (true)
            {
                string message = await reader2.ReadLineAsync();
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine($"2 → 1 : {message}");
                    await writer1.WriteLineAsync(message);
                }
            }
        });

        Console.WriteLine("두 명 연결 완료! 게임을 시작하세요.");
        Console.ReadLine(); // 서버 꺼지지 않도록 유지
    }
}

