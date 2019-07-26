using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class banner : Form
    {
        public bool boolean = false;
        public banner()
        {
            InitializeComponent();
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            FIOtxt.Size = new Size((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2) - FIOtxt.Size.Width / 2, 
                System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2 - 50);
            FIOtxt.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2) - FIOtxt.Size.Width / 2  , 
                (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2) - 50);
            Acception.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2) - 50, 
                (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2));
        }

        private void banner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (boolean == false)
                e.Cancel = true;
        }

        private void banner_Deactivate(object sender, EventArgs e)
        {
            if (boolean == false)
                this.WindowState = FormWindowState.Maximized;
        }

        private void banner_Leave(object sender, EventArgs e)
        {
            if (boolean == false)
                this.WindowState = FormWindowState.Maximized;
        }

        private void Acception_Click(object sender, EventArgs e)
        {
            if (FIOtxt.Text != "" && (FIOtxt.Text.IndexOf(" ") > -1) && FIOtxt.TextLength >= 8)
            {
                client.Program.userName = FIOtxt.Text;
                boolean = true;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Строка должна содержать ваше имя и фамилию, разделенные пробелом.");
            }
        }

        private void FIOtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Acception.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
