using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    class Room
    {
        public int RoomId;
        public List<TcpClient> Players = new List<TcpClient>();
    }

    public partial class Form1 : Form
    {
        // 서버 구조
        //List<Room> rooms = new List<Room>();

        TcpListener server;
        List<TcpClient> clients = new List<TcpClient>();
        bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
        }


        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 9000);
            server.Start();
            isRunning = true;
            AddLog("서버 시작됨");


            while (isRunning)
            {
                if (clients.Count < 4)
                {
                    TcpClient client = server.AcceptTcpClient();
                    clients.Add(client);
                    AddLog($"클라이언트 접속: {clients.Count}명");

                    // 접속 인원 수 전송
                    BroadcastPlayerCount();
                }
            }

        }
        
        private void BroadcastPlayerCount()
        {
            foreach (var client in clients)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    byte[] data = BitConverter.GetBytes(clients.Count);
                    stream.Write(data, 0, data.Length);
                }
                catch { /* 예외 무시 또는 로그 */ }
            }
        }
        

        /*
        private void HandleNewClient(TcpClient client)
        {
            Room assignedRoom = null;

            // 빈자리가 있는 방 찾기
            foreach (var room in rooms)
            {
                if (room.Players.Count < 4)
                {
                    assignedRoom = room;
                    break;
                }
            }

            // 없으면 새 방 생성
            if (assignedRoom == null)
            {
                assignedRoom = new Room
                {
                    RoomId = rooms.Count + 1
                };
                rooms.Add(assignedRoom);
            }

            // 방에 클라이언트 추가
            assignedRoom.Players.Add(client);
            AddLog($"클라이언트가 방 {assignedRoom.RoomId}에 배정됨 ({assignedRoom.Players.Count}/4)");

            // 현재 방의 플레이어 수를 해당 방 모든 클라이언트에 전송
            BroadcastRoomInfo(assignedRoom);
        }
       

        private void BroadcastRoomInfo(Room room)
        {
            foreach (var client in room.Players)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    string msg = $"ROOM:{room.RoomId}|COUNT:{room.Players.Count}";
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    stream.Write(data, 0, data.Length);
                }
                catch { /* 생략 가능 / }
            }
        }
        */

        private void AddLog(string msg)
        {
            if (lstLog.InvokeRequired)
                lstLog.Invoke(new Action(() => lstLog.Items.Add(msg)));
            else
                lstLog.Items.Add(msg);
        }
    }
}
