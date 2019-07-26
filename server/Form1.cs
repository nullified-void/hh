using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public partial class Form1 : Form
    {
        public List<object> items = new List<object>(100);
        public List<object> rm = new List<object>(100);
        public static ListBox lb = new ListBox();
        public Server server;
        public static procdialog dialog = new procdialog();
        public Form1() 
        {
            InitializeComponent();
            System.Threading.Thread th = new System.Threading.Thread(timer);
            th.Start();
        }
        public void RemoveFromList(object obj)
        {
            rm.Add(obj);
        }
        public void AddToList(object obj)
        {
            items.Add(obj);
        }
        public void timer()
        {

            while (true)
            {
                if (items.Count != 0)
                {
                    foreach (object obj in items)
                        listBox1.Invoke(new Action(() => listBox1.Items.Add(obj.ToString())));
                    items.Clear();
                }
                if (rm.Count != 0)
                {
                    foreach (object obj in rm)
                        listBox1.Invoke(new Action(() => listBox1.Items.Remove(obj.ToString())));
                }
                System.Threading.Thread.Sleep(100);
            }
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selected = listBox1.SelectedItem.ToString();
                selected = selected.Substring(selected.IndexOf("/") + 1);
                string msg = "$check";
                Program.server.BroadcastMessage(msg, selected);
            }
        }
        private void showform()
        {
            DialogResult dr = dialog.ShowDialog();
            string msg = "add " + dialog.temp;
            if (dialog.DialogResult == DialogResult.OK)
                Program.server.BroadcastMessage(msg, "1000");

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread dialog = new Thread(showform);
            dialog.Start();
        }

        private void Browserbtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selected = listBox1.SelectedItem.ToString();
                selected = selected.Substring(selected.IndexOf("/") + 1);
                string msg = "$browser";
                Program.server.BroadcastMessage(msg, selected);
            }
        }
    }

}
