using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Server
{
    class Listener
    {
        //First the class initializes a socket interface called s, with two public booleans, both including a  public getter method, and a private setter method.
        Socket s;

        public bool Listening
        {
            get;
            private set;
        }
        public int Port
        {
            get;
            private set;
        }

        //Here a method is created, which instanciates a new object called s, of type Socket class, which takes 3 parameters.
        //The 3 parameters are used to specify the type of address the socket uses, the type of the socket, and which protocol the socket uses.
        public Listener(int port)
        {
            Port = port;
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        //The next two public voids are also methods created, called Start and Stop.
        //These decide what the server should do when the server is Listening (Start) and when it's not listening (Stop).
        public void Start()
        {
            //The start method uses a listener to search for new connections to the server, and if one is found.
            //It's accepted using a callback method and bound to a local Endpoint, and the server is set to be listening for new sockets afterwards.
            if (Listening)
                return;
            s.Bind(new IPEndPoint(IPAddress.Any, Port));
            s.Listen(0);

            s.BeginAccept(callback, null);
        }
        public void Stop()
        {
            //Once the server stops listening, it means it has found a new connection, and therefore disposes any sockets accosiated with it, and instanciates a new Socket for that connection.

            if (!Listening)
                return;
            s.Close();
            s.Dispose();
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        void callback(IAsyncResult ar)
        {
            //The callback method is a try catch block, used to asynchronously accept an incomming connection and create a new socket for it.
            try
            {
                Socket s = this.s.EndAccept(ar);

                if (SocketAccepted != null)
                {
                    SocketAccepted(s);
                }
                this.s.BeginAccept(callback, null);
            }
            //In case there is any exceptions thrown while the server is doing this, the catch block will notify the system what went wrong, and a message in the console stating the exception.
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public delegate void SocketAcceptedhandler(Socket e);
        public event SocketAcceptedhandler SocketAccepted;
    }
}
