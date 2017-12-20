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
using System.Net;
using System.Threading;
using System.IO;

namespace ClientSoftware
{
    public partial class Form1 : Form
    {

        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        int portNumber = 8888;


        private Image x;
        private Image o;

        bool myTurn;
        bool winner = false;

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




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ToSendOrNotToSend(8);
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
                if (cValue == 1)
                {
                    MessageBox.Show("You win!");
                }
                else
                {
                    MessageBox.Show("You lose!");
                }
            }
            else if (turn_count == 9)
            {
                MessageBox.Show("Draw!");
            }

            resetGame();
        }

        void ToSendOrNotToSend(int change)
        {
            if (myTurn)
            {
                StatusSend(change);
                changeFunction(change);
                player();
                winCondition();
                turn_count++;
            }
        }

        void resetGame()
        {
            if (turn_count == 9 || winner == true)
            {
                    this.Close();
            }
        }
        //Need a function that sends data to the server.
        private void StatusSend(int change)
        {
            myTurn = false;
            socket.Send(BitConverter.GetBytes(change));
            socket.Bind(new IPEndPoint(IPAddress.Any, portNumber));
            socket.Listen(10);
            socket.BeginAccept(new AsyncCallback(Receive), null);
        }

        //Also need one that receives data and updates the board
        public void Receive(IAsyncResult asyncResult)
        {
            //Setting cValue to 2 before checking winCondition. This means that if the oppoenent has won, the text box will say "You Lose!
            cValue = 2;
            byte[] bytes = new byte[256];

            socket.Receive(bytes, 0, bytes.Length, SocketFlags.None);
            
            int bytesRead = socket.EndReceive(asyncResult);


            //Update board here
            int change = bytesRead;
            changeFunction(change);
            //Need to update board before running winCondition
            winCondition();
            myTurn = true;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Connecting...");
            try
            {
                socket.Connect(textIP.Text, portNumber);
                MessageBox.Show("Connected");
            }
            //BTW sand made this
            catch
            {
                MessageBox.Show("Failed to connect");

            }
        }
    }
}
