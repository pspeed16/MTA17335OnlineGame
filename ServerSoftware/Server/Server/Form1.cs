using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public string textToSend;

        public Form1()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipLabel2.Text = address.ToString();
                }
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e) //connect client
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(clientIP.Text), int.Parse(clientPort.Text));

            try
            {
                client.Connect(IpEnd);
                if (client.Connected)
                {
                    textChat.AppendText("Connected to server :D" + "\n");
                    STR = new StreamReader(client.GetStream());
                    STW = new StreamWriter(client.GetStream());
                    STW.AutoFlush = true;

                    threadReceiver.RunWorkerAsync();
                    threadSender.WorkerSupportsCancellation = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }

        private void StartButton_Click(object sender, EventArgs e) //start server
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(portLabel2.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            threadReceiver.RunWorkerAsync();
            threadSender.WorkerSupportsCancellation = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void threadReceiver_DoWork(object sender, DoWorkEventArgs e) //client and server message reciever
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    this.textChat.Invoke(new MethodInvoker(delegate () { textChat.AppendText("Client:" + recieve + "\n"); }));
                    recieve = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        private void threadSender_DoWork(object sender, DoWorkEventArgs e) //client and server message sender
        {
            if (client.Connected)
            {
                STW.WriteLine(textToSend);
                this.textChat.Invoke(new MethodInvoker(delegate () { textChat.AppendText("Server:" + textToSend + "\n"); }));
            }
            else
            {
                MessageBox.Show("Send failed");
            }
            threadSender.CancelAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e) //send button
        {
            if (textMessage.Text != "")
            {
                textToSend = textMessage.Text;
                threadSender.RunWorkerAsync();
            }
            textMessage.Text = "";
        }
    }
}