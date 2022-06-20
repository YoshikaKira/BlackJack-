using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OnlineBlackGack
{
    class Server
    {
        List<TcpClient> clients;
        TcpListener tcpListener;
        BlackJack blackJack;
        List<Player> players;
        public Server()
        {
            tcpListener = new TcpListener(IPAddress.Any, 8888);
            clients = new List<TcpClient>();
            players = new List<Player>();
            Task task = new Task(new Action(() =>
            {
                WaitPlayers(2);
            }));
        }
        void GetInfo(TcpClient client)
        {
            while (client.Connected)
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                string message = reader.ReadToEnd();
                if (message != "")
                {
                    Player pl = (Player)JsonConvert.DeserializeObject(message);
                    if (clients.Count > players.Count)
                    {
                        players.Add(pl);
                    }
                    else
                    {
                        int i = clients.FindIndex((x)=>x==client);
                        players[i] = pl;
                    }
                    MessageBox.Show(message);
                }
            }
        }
        void WaitPlayers(int count)
        {
            tcpListener.Start();
            for (int i = 0; i < count; i++)
            {
                clients.Add(tcpListener.AcceptTcpClient());
                Task task = new Task(new Action(() =>
                {
                    GetInfo(clients[clients.Count - 1]);
                }));
                task.Start();
            }
            tcpListener.Stop();
            blackJack = new BlackJack(players);
        }
    }
}
