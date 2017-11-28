using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSoftware
{
    public partial class Form1 : Form
    {

        private Image x;
        private Image o;
        private Image noImage;

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
            noImage = ClientSoftware.Properties.Resources.None;

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(0);

            winCondition();

            turn_count++;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(1);

            winCondition();

            turn_count++;
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(2);

            winCondition();

            turn_count++;
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(3);

            winCondition();

            turn_count++;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(4);

            winCondition();

            turn_count++;
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(5);

            winCondition();

            turn_count++;
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(6);

            winCondition();

            turn_count++;
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(7);

            winCondition();

            turn_count++;
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            player();

            changeFunction(8);

            winCondition();

            turn_count++;
            

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

            var pictureBoxes = new List<PictureBox> { pictureBox1,
                                                      pictureBox2,
                                                      pictureBox3,
                                                      pictureBox4,
                                                      pictureBox5,
                                                      pictureBox6,
                                                      pictureBox7,
                                                      pictureBox8,
                                                      pictureBox9 };
            if (turn_count == 9 || winner == true)
            {
                for (int i = 0; i < 9; i++)
                {
                    pictureBoxes[i].Image = noImage;
                    this.Close();
                }
            }

        }
    }
}
