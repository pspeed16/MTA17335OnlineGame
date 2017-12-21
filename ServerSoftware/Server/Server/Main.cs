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

namespace Server
{
    public partial class Main : Form
    {
        int clientCounter = 0;
        Listener listener;
        private static byte[] buffer = new byte[4096];
        public Main()
        {
            InitializeComponent();
            listener = new Listener(8888);
            listener.SocketAccepted += new Listener.SocketAcceptedhandler(listener_SocketAccepted);
            Load += new EventHandler(Main_load);
        }
        void Main_load(Object sender, EventArgs e)
        {
            listener.Start();
        }
        void listener_SocketAccepted(System.Net.Sockets.Socket e)
        {
            Client client = new Client(e);
            client.Received += new Client.ClientRecivedHandler(client_Received);
            client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);
            e.Send(BitConverter.GetBytes(10 + clientCounter));
            clientCounter++;
            Invoke((MethodInvoker)delegate
            {
                ListViewItem i = new ListViewItem();
                i.Text = client.EndPoint.ToString();
                i.SubItems.Add(client.ID);
                i.SubItems.Add("XX");
                i.SubItems.Add("XX");
                i.Tag = client;
                lstClient.Items.Add(i);
            });
        }
        void client_Disconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < lstClient.Items.Count; i++)
                {
                    Client client = lstClient.Items[i].Tag as Client;

                    if (client.ID == sender.ID)
                    {
                        clientCounter--;
                        lstClient.Items.RemoveAt(i);
                        break;
                    }
                }
            });
        }
        void client_Received(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < lstClient.Items.Count; i++)
                {
                    Client client = lstClient.Items[i].Tag as Client;

                    if (client.ID == sender.ID)
                    {
                        client.sck.Send(data);
                        int realData = BitConverter.ToInt16(data, 0);
                        lstClient.Items[i].SubItems[2].Text = realData.ToString();
                        lstClient.Items[i].SubItems[3].Text = DateTime.Now.ToString();
                        
                        break;
                    }
                }
            });
        }
    }
}
