using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OnlineBlackGack
{
    public partial class Form1 : Form
    {
        Server server;
        TcpClient client;
        Player player;
        public Form1()
        {
            InitializeComponent();
            player = new Player
            {
                Name = "Kirill",
                Bank = 1000,
                Hand = new List<Card>()
            };
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            client = new TcpClient(textBox1.Text, 8888);
            NetworkStream strem = client.GetStream();
            StreamWriter writer = new StreamWriter(strem);
            string message = JsonConvert.SerializeObject(player);

            writer.WriteLine(message+"\n");
            writer.Flush();
            writer.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            server = new Server();
            button2.Enabled = false;
            MessageBox.Show("Server Start");
        }
    }
}
