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



namespace ClientSoftware
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Form1 startGame = new Form1();
            connectInfoLabel.Text += ipInput.Text;
            connectInfoLabel.Text += portInput.Text;
            startGame.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
