using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace screensaver
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller contr = new controller(pictureBox1.Size.Width, pictureBox1.Size.Height);
            contr.connectPictureBox(pictureBox1);
        }
        
        
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
