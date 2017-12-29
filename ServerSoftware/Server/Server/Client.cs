using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Server
{
    class Client
    {
        //makes getters and setters for the ID, EndPoint and Sockket
        public string ID
        {
            get;
            private set;
        }
        public IPEndPoint EndPoint
        {
            get;
            private set;
        }

        public Socket sck
        {
            get;
            private set;
        }

        // public Method that with a socket variable called accepted
        public Client(Socket accepted)
        {
            // inesilaiser the variables 
            sck = accepted;
            ID = Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
            sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }
        // this function handles the receiving of data and the Disconnection of a Client 
        void callback(IAsyncResult ar)
        {
            try
            {
                sck.EndReceive(ar);

                byte[] buf = new byte[8192];

                int rec = sck.Receive(buf, buf.Length, 0);

                if (rec < buf.Length)
                {
                    Array.Resize<byte>(ref buf, rec);
                }
                if (Received != null)
                {
                    Received(this, buf);
                }
                sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Close();

                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }
        }

        // Closes the socket and Disposes of the data.
        public void Close()
        {
            sck.Close();
            sck.Dispose();
        }
        public delegate void ClientRecivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);

        public event ClientRecivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;
    }
}
