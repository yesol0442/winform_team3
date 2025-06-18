using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

class GameState
{
    public string endMsg1 = null;
    public string endMsg2 = null;
    public bool resultSent = false;
}

public class CodeGameServer
{
    public static async Task Main(string[] args)
    {
        TcpListener server = new TcpListener(IPAddress.Any, 9000);
        server.Start();
        Console.WriteLine("서버 실행 중...");

        while (true)
        {
            Console.WriteLine("\n[서버] 새 게임 대기 중...");
            TcpClient client1 = await server.AcceptTcpClientAsync();
            Console.WriteLine("클라이언트 1 연결됨");
            TcpClient client2 = await server.AcceptTcpClientAsync();
            Console.WriteLine("클라이언트 2 연결됨");

            _ = Task.Run(() => RunGame(client1, client2));
        }
    }

    private static async Task RunGame(TcpClient client1, TcpClient client2)
    {
        var writer1 = new StreamWriter(client1.GetStream()) { AutoFlush = true };
        var writer2 = new StreamWriter(client2.GetStream()) { AutoFlush = true };
        var reader1 = new StreamReader(client1.GetStream());
        var reader2 = new StreamReader(client2.GetStream());

        await writer1.WriteLineAsync("ID A");
        await writer2.WriteLineAsync("ID B");
        await writer1.WriteLineAsync("OTHER_CONNECTED");
        await writer2.WriteLineAsync("OTHER_CONNECTED");
        await writer1.WriteLineAsync("START");
        await writer2.WriteLineAsync("START");

        var state = new GameState();

        var task1 = Task.Run(async () =>
        {
            try
            {
                while (true)
                {
                    string msg = await reader1.ReadLineAsync();
                    if (msg == null) break;

                    Console.WriteLine("[서버] 클라1 → " + msg);

                    if (msg.StartsWith("END"))
                    {
                        await Task.Delay(50);
                        state.endMsg1 = msg;

                        if (!state.resultSent)
                        {
                            state.resultSent = true;
                            string fallback = state.endMsg2 ?? "END 0 B";
                            await BroadcastResult(writer1, writer2, state.endMsg1, fallback);
                        }
                    }
                    else
                    {
                        await writer2.WriteLineAsync(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[서버] 클라1 예외: {ex.Message}");
            }
        });

        var task2 = Task.Run(async () =>
        {
            try
            {
                while (true)
                {
                    string msg = await reader2.ReadLineAsync();
                    if (msg == null) break;

                    Console.WriteLine("[서버] 클라2 → " + msg);

                    if (msg.StartsWith("END"))
                    {
                        await Task.Delay(50);
                        state.endMsg2 = msg;

                        if (!state.resultSent)
                        {
                            state.resultSent = true;
                            string fallback = state.endMsg1 ?? "END 0 A";
                            await BroadcastResult(writer1, writer2, fallback, state.endMsg2);
                        }
                    }
                    else
                    {
                        await writer1.WriteLineAsync(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[서버] 클라2 예외: {ex.Message}");
            }
        });

        await Task.WhenAll(task1, task2); // 둘 다 종료되면 다음 게임 대기

        client1.Close();
        client2.Close();
        Console.WriteLine("[서버] 게임 종료됨. 다음 게임 대기...");
    }

    private static async Task BroadcastResult(StreamWriter w1, StreamWriter w2, string end1, string end2)
    {
        try
        {
            var tokens1 = end1.Split(' ');
            var tokens2 = end2.Split(' ');

            int score1 = int.Parse(tokens1[1]);
            int score2 = int.Parse(tokens2[1]);

            string result1, result2;

            if (score1 > score2)
            {
                result1 = $"RESULT 🎉 승리!\\n 내 점수: {score1}\\n상대 점수: {score2}";
                result2 = $"RESULT 😢 패배...\\n 내 점수: {score2}\\n상대 점수: {score1}";
            }
            else if (score1 < score2)
            {
                result1 = $"RESULT 😢 패배...\\n 내 점수: {score1}\\n상대 점수: {score2}";
                result2 = $"RESULT 🎉 승리!\\n 내 점수: {score2}\\n상대 점수: {score1}";
            }
            else
            {
                result1 = result2 = $"RESULT 🤝 무승부!\\n 점수: {score1}";
            }

            Console.WriteLine("[서버] 결과 전송 중...");
            await w1.WriteLineAsync(result1);
            await w2.WriteLineAsync(result2);
            Console.WriteLine("[서버] 결과 전송 완료!");

            await Task.Delay(500); // 클라이언트가 읽을 시간 확보
        }
        catch (Exception ex)
        {
            Console.WriteLine("[서버] 결과 전송 오류: " + ex.Message);
        }
    }
}
