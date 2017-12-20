using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ClientSoftware
{
    public partial class StartScreen : Form
    {

       // TcpClient socketForServer;
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //IPAddress IPADDRESS = IPAddress.Parse("80.62.117.169");

        int portNumber = 8888;

        public StartScreen()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Form1 startGame = new Form1();
            Form1_Load(sender, e);
            connectInfoLabel.Text += ipInput.Text;
            //connectInfoLabel.Text += portInput.Text;
            startGame.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Connecting...");
            try
            {
                socket.Connect(ipInput.Text, portNumber);
                Console.WriteLine("Connected");
            }
            //BTW sand made this
            catch
            {
                Console.WriteLine("Failed to connect");

            }
        }



    }
}
