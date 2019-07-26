using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace client
{
    class Program
    {
        private static string host = "127.0.0.1";
        private const int port = 8888;
        public static string[] prclst = File.ReadAllLines("BlackList.txt");
        public static List<string> Bad = new List<string>(prclst.Length);
        public static string userName;
        static TcpClient client;
        static NetworkStream stream;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            //Console.Write("Enter ip to connect");
            //host = Console.ReadLine();
            //Console.Write("Enter nickname: ");
            //userName = Console.ReadLine();
            //Thread showform = new Thread(show);
            var handle = GetConsoleWindow();


            ShowWindow(handle, SW_HIDE);
            show();
            client = new TcpClient();
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();

                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                Thread recieveThread = new Thread(new ThreadStart(RecieveMessage));
                recieveThread.Start();
                Console.WriteLine();
                SendMessage();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        static void SendMessage()
        {
            Console.WriteLine("Enter message: ");

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }

        static void RecieveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64];

                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    if (message == "$check")
                    {
                        check();
                    }
                    if (message.StartsWith("add"))
                    {
                         string msg = message.Substring(4, message.Length-4);
                         add(msg);
                    }
                    if (message == "$browser")
                    {
                        Process[] pname = Process.GetProcessesByName("chrome");
                        Process[] pname1 = Process.GetProcessesByName("MicrosoftEdge");
                        Process[] pname2 = Process.GetProcessesByName("Opera");
                        Process[] pname3 = Process.GetProcessesByName("firefox");
                        if (pname.Length != 0 || pname1.Length != 0 || pname2.Length != 0 || pname3.Length != 0)
                        {
                            send("browse");
                        }
                        else
                            send("noBrowse");

                    }
                    Console.WriteLine(message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("connection error");
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }
        static void show()
        {
            banner b = new banner();
            DialogResult dr = b.ShowDialog();
            if (b.DialogResult == DialogResult.OK)
                return;

        }
        static void add(string proc)
        {

            StreamWriter sw = new StreamWriter("BlackList.txt", true);
            sw.WriteLine(proc);
            sw.Close();
            prclst = File.ReadAllLines("BlackList.txt");
        }
        static void check()
        {
            int i = 0;
            foreach (string S in prclst)
            {
                Process[] pname = Process.GetProcessesByName(S);
                if (pname.Length != 0)
                {
                    i++;
                    Bad.Add(S);
                }
            }
            if (i == 0)
            {
                send("0");
            }
            else
            {
                foreach (string s in Bad)
                {
                    send("f " + s);
                    Thread.Sleep(100);
                }
            }

            if (i != 0)
                send("End");
            i = 0;
            Bad.Clear();
        }
        static void send(string message)
        {
            
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);

        }
        static void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0);
        }
    }
}
