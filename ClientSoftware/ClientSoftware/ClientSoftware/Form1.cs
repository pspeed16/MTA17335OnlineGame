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
    
        int cValue = 1;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(0);

            winCondition();



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(1);

            winCondition();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(2);
            winCondition();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player();

            changeFunction(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            player();

            changeFunction(8);

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
            if (pictureBox1.Image == x && pictureBox2.Image == x && pictureBox3.Image == x || pictureBox1.Image == o && pictureBox2.Image == o && pictureBox3.Image == o)
            {
                pictureBox1.Enabled = true;
                MessageBox.Show("Hello");
            }
        }
    }
}
