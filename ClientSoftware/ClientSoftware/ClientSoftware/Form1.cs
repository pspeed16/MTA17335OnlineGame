using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

using System.Threading;

namespace ClientSoftware
{
    public partial class Form1 : Form
    {
        TcpClient socketForServer;

        IPAddress IPADDRESS = IPAddress.Parse("127.0.0.1");

        int portNumber = 8888;

        Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        private Image x;
        private Image o;


        bool winner = false;

        int changeInt = 0;
        int cValue = 1;
        int turn_count = 1;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Parent = PictureContainer;
            pictureBox2.Parent = PictureContainer;
            pictureBox3.Parent = PictureContainer;
            pictureBox4.Parent = PictureContainer;
            pictureBox5.Parent = PictureContainer;
            pictureBox6.Parent = PictureContainer;
            pictureBox7.Parent = PictureContainer;
            pictureBox8.Parent = PictureContainer;
            pictureBox9.Parent = PictureContainer;

            x = ClientSoftware.Properties.Resources.X;
            o = ClientSoftware.Properties.Resources.O;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Connecting...");
            try
            {
                socketForServer.Connect(IPADDRESS, portNumber);
                Console.WriteLine("Connected");
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            changeInt = 0;
            lotsoffunctions();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changeInt = 1;
            lotsoffunctions();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changeInt = 2;
            lotsoffunctions();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            changeInt = 3;
            lotsoffunctions();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            changeInt = 4;
            lotsoffunctions();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            changeInt = 5;
            lotsoffunctions();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            changeInt = 6;
            lotsoffunctions();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            changeInt = 7;
            lotsoffunctions();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            changeInt = 8;
            lotsoffunctions();

        }
        void player()
        {
            if (cValue == 2)
            {
                cValue = 1;
            }
            else if (cValue == 1)
            {
                cValue = 2;
            }

        }

        void changeFunction(int setImage)
        {

            var pictureBoxes = new List<PictureBox> { pictureBox1,
                                                      pictureBox2,
                                                      pictureBox3,
                                                      pictureBox4,
                                                      pictureBox5,
                                                      pictureBox6,
                                                      pictureBox7,
                                                      pictureBox8,
                                                      pictureBox9 };

            if (cValue == 1)
            {
                pictureBoxes[setImage].Image = o;
            }
            else if (cValue == 2)
            {
                pictureBoxes[setImage].Image = x;
            }
            pictureBoxes[setImage].Enabled = false;
        }
        
        void winCondition()
        {
           

            //horizontal win condition
            if (pictureBox1.Image == x && pictureBox2.Image == x && pictureBox3.Image == x || pictureBox1.Image == o && pictureBox2.Image == o && pictureBox3.Image == o)
            {
                
                winner = true;
            }
            else if (pictureBox4.Image == x && pictureBox5.Image == x && pictureBox6.Image == x || pictureBox4.Image == o && pictureBox5.Image == o && pictureBox6.Image == o)
            {
                winner = true;
            }
            else if(pictureBox7.Image == x && pictureBox8.Image == x && pictureBox9.Image == x || pictureBox7.Image == o && pictureBox8.Image == o && pictureBox9.Image == o) {
                winner = true;
            }

            //vertical win condition
            if (pictureBox1.Image == x && pictureBox4.Image == x && pictureBox7.Image == x || pictureBox1.Image == o && pictureBox4.Image == o && pictureBox7.Image == o)
            {
               
                winner = true;
            }
            else if (pictureBox2.Image == x && pictureBox5.Image == x && pictureBox8.Image == x || pictureBox2.Image == o && pictureBox5.Image == o && pictureBox8.Image == o)
            {
                winner = true;
            }
            else if (pictureBox3.Image == x && pictureBox6.Image == x && pictureBox9.Image == x || pictureBox3.Image == o && pictureBox6.Image == o && pictureBox9.Image == o)
            {
                winner = true;
            }

            //cross win condition
            if (pictureBox1.Image == x && pictureBox5.Image == x && pictureBox9.Image == x || pictureBox1.Image == o && pictureBox5.Image == o && pictureBox9.Image == o)
            {
               
                winner = true;
            }
            else if (pictureBox3.Image == x && pictureBox5.Image == x && pictureBox7.Image == x || pictureBox3.Image == o && pictureBox5.Image == o && pictureBox7.Image == o)
            {
                winner = true;
            }



            //win or draw method
            if (winner == true)
            {
                MessageBox.Show("You win!");
            }
            else if (turn_count == 9)
            {
                MessageBox.Show("Draw!");
            }

            resetGame();
        }

        void resetGame()
        {
            if (turn_count == 9 || winner == true)
            {
                    this.Close();

            }

        }

        private void lotsoffunctions()
        {
            player();

            changeFunction(changeInt);

            winCondition();

            turn_count++;
        }

        //Need a function that sends data to the server.
        private void statusSend()
        {
            
        }
        
        //Also need one that receives data and updates the board
        public void Receive(Socket sender, byte[] bytes, int declareWin)
        {
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
            Encoding.ASCII.GetString(bytes, 0, bytesRec));

            if (declareWin == 1)
            {
                
            }


        }
    }
}
