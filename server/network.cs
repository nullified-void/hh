using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public class Client
    {
        protected internal string id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }

        TcpClient client;
        Server server;
        string userName;
        string userid;
        public Form1 form;
        public List<string> msgs = new List<string>();
        public string pList = "";
        public Client(TcpClient tcpclient, Server serverObj)
        {
            id = Guid.NewGuid().ToString();
            client = tcpclient;
            server = serverObj;
            serverObj.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string message = GetMessage();
                userName = message;
                message = userName + " connected.";
                server.BroadcastMessage(message, this.id);
                userid = userName + "/" + this.id;
                Program.form.AddToList(userid);
                Console.WriteLine(message);
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        //message = string.Format("{0}: {1}",userName,message);
                        Console.WriteLine(message);
                        if (message.StartsWith("browse"))
                        {
                            MessageBox.Show("На данном компьютере запущен браузер.","Результаты проверки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (message.StartsWith("noBrowse"))
                        {
                            MessageBox.Show("На данном компьютере не запущено браузеров.", "Результаты проверки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (message.StartsWith("f "))
                        {
                            msgs.Add(message.Remove(0, 2));
                        }
                        if (message == "End")
                        {
                            foreach (string s in msgs)
                            {
                                pList = pList + "," + s;
                            }
                            //pList = pList.Remove(pList.Length - 3);
                            pList = pList.Remove(0, 1);
                            msgs.Clear();
                            string msgbox = "Процессы, находящиеся в черном списке, запущенные на компьюетере, за которым сидит "  + userName + " = "  + pList;
                            pList = pList.Remove(0);
                            MessageBox.Show(msgbox, "Результаты проверки", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        if (message == "0")
                        {
                            string msgbox = "На компьютере, за которым сидит " + userName + " не запущенно процессов из черного списка.";
                            MessageBox.Show(msgbox, "Результаты проверки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //server.BroadcastMessage(message,this.id);

                    }
                    catch
                    {
                        message = string.Format("{0}: disconnected", userName);
                        Console.WriteLine(message);
                        string dc = userName + "/" + this.id;
                        Program.form.RemoveFromList(dc);
                        //server.BroadcastMessage(message, this.id);
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.id);
                Close();
            }
        }

        private string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);
          
            return builder.ToString();
        }

        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }

    public class Server
    {
        static TcpListener tcpListener;
        List<Client> clients = new List<Client>();

        protected internal void AddConnection(Client cl)
        {
            clients.Add(cl);
        }

        protected internal void RemoveConnection(string id)
        {
            Client cl = clients.FirstOrDefault(c => c.id == id);
            if (cl != null)
                clients.Remove(cl);
        }

        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Server listen...");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Client cl = new Client(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(cl.Process));
                    clientThread.Start();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Disconnect();
            }
        }

        public void BroadcastMessage(string message, string id)
        {
            if (message.ToLower().IndexOf("$") >= 0)
            {
                

                byte[] data = Encoding.Unicode.GetBytes(message);
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].id == id)
                    {
                        clients[i].Stream.Write(data, 0, data.Length);
                    }
                }
            }
            else
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].id != id)
                    {
                        clients[i].Stream.Write(data, 0, data.Length);
                    }
                }
            }
        }

        protected internal void Disconnect()
        {
            tcpListener.Stop();
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }
            Environment.Exit(0);
        }
    }
}
