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

        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        int portNumber = 8888;
        IPAddress serverIP;
        private Image x;
        private Image o;
        private Image pictureToCheckFor;
        private Image pictureNotToCheckFor;
        bool myTurn = true;
        bool? winner = null;
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
            //Changes the pictureboxes to the proper images upon being called.
            if (myTurn == false) pictureBoxes[setImage].Image = pictureNotToCheckFor;
            else pictureBoxes[setImage].Image = pictureToCheckFor;
            this.Invoke((MethodInvoker)delegate { pictureBoxes[setImage].Enabled = false; });
            
        }
        
        void winCondition()
        {
            //Declaring necessary variabes to check for a winer.
            PictureBox[,] pbs = new PictureBox[3, 3];
            int[] winSum = new int[2];
            winSum[0] = 0;
            winSum[1] = 0;
            pbs[0, 0] = pictureBox1;
            pbs[0, 1] = pictureBox2;
            pbs[0, 2] = pictureBox3;
            pbs[1, 0] = pictureBox4;
            pbs[1, 1] = pictureBox5;
            pbs[1, 2] = pictureBox6;
            pbs[2, 0] = pictureBox7;
            pbs[2, 1] = pictureBox8;
            pbs[2, 2] = pictureBox9;
            //The loops that check whether a player has won or lost.
            for (int i=0; i < 3; i++)
            {
                //Looping through pictureboxes to check whether there is a winner in the diagonal.
                for (int j = 0; j < 3; j++)
                {
                    //If the picture in the picturebox is the one corresponding to the player's shape, add one to the win-counter.
                    if (pbs[i, j].Image == pictureToCheckFor)
                    {
                        if (i == j)
                        {
                            winSum[0]++;
                        }
                        if (i == 2 - j)
                        {
                            winSum[1]++;
                        }
                    }
                    //If the picture is not the player's shape, remove one from the win-counter.
                    if (pbs[i, j].Image == pictureNotToCheckFor)
                    {
                        if (i == j)
                        {
                            winSum[0]--;
                        }
                        if (i == 2 - j)
                        {
                            winSum[1]--;
                        }
                    }
                }
                //horizontal
                if (pbs[i, 0].Image==pictureToCheckFor && pbs[i, 1].Image==pictureToCheckFor && pbs[i, 2].Image==pictureToCheckFor)
                {
                    winner = true;
                }
                //vertical
                else if(pbs[0, i].Image == pictureToCheckFor && pbs[1, i].Image == pictureToCheckFor && pbs[2, i].Image == pictureToCheckFor)
                {
                    winner = true;
                }
                else if (pbs[i, 0].Image == pictureNotToCheckFor && pbs[i, 1].Image == pictureNotToCheckFor && pbs[i, 2].Image == pictureNotToCheckFor)
                {
                    winner = false;
                }
                //vertical
                else if (pbs[0, i].Image == pictureNotToCheckFor && pbs[1, i].Image == pictureNotToCheckFor && pbs[2, i].Image == pictureNotToCheckFor)
                {
                    winner = false;
                }
            }
            //If the win-counter is positive 3, the player on this client has won. If it is negative 3, the player has lost. 
            if (winSum[0] == 3 || winSum[1] == 3) winner = true;
            if (winSum[0] == -3 || winSum[1] == -3) winner = false;

            //win or draw method
            if (winner == true)
            {
                MessageBox.Show("You win!");
            }
            else if (winner == false)
            {
                MessageBox.Show("You lose!");
            }
            else if (turn_count == 9)
            {
                MessageBox.Show("Draw!");
            }

            resetGame();
        }
        //ToSendOrNotToSend checks whether it's the player's turn, and if it is, it runs all the necessary methods.
        void ToSendOrNotToSend(int change)
        {
            if (myTurn)
            {
                this.changeFunction(change);
                StatusSend(change);
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
        private void StatusSend(int change)
        {
            //Sends which picturebox was clicked to the server.
            myTurn = false;
            socket.Send(BitConverter.GetBytes(change));
        }

        //Also need one that receives data and updates the board
        public void Receive(IAsyncResult asyncResult)
        {
            //Receiving stuff
            byte[] bytes = new byte[4];
            var sync = socket.BeginReceive(bytes, 0, 4, SocketFlags.None, new AsyncCallback(Receive), socket);
            sync.AsyncWaitHandle.WaitOne();
            int recVal = BitConverter.ToInt32(bytes, 0);
            try
            {
                socket.EndReceive(asyncResult);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            //Update board here
            if (recVal > 9)
            {
                if (recVal == 11) myTurn = false;
                cValue = recVal - 10;
            }
            else
            {
                changeFunction(recVal);
                myTurn = true;
            }
            //Defining what shape the player has.
            if (cValue == 0)
            {
                pictureToCheckFor = o;
                pictureNotToCheckFor = x;
            }
            else
            {
                pictureToCheckFor = x;
                pictureNotToCheckFor = o;
            }
            //Need to update board before running winCondition
            winCondition();
            
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Connecting...");
            try
            {
                //Beginning the connection, also listening for incoming signals to the scoket.
                serverIP = IPAddress.Parse(textIP.Text);
                socket.BeginConnect(new IPEndPoint(serverIP, portNumber), new AsyncCallback(Receive), socket);
                MessageBox.Show("Connected");
            }
            catch
            {
                MessageBox.Show("Failed to connect");
            }
        }
    }
}
