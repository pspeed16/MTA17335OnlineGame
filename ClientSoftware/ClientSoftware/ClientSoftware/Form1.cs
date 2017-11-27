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
        }

        int cValue = 1;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            player();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            player();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

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
    }
}
