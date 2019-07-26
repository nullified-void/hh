using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        public static Server server;
        static Thread listenThread;
        public static Form1 form = new Form1();
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();


            ShowWindow(handle, SW_HIDE);
            try
            {
                server = new Server();
                listenThread = new Thread(new ThreadStart(server.Listen));
                Thread thread = new Thread(formStart);
                thread.Start();
                listenThread.Start();
            }
            catch(Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }

            while (true)
            {
                string r = Console.ReadLine();
                r = r.ToLower();

                if (r == "exit" || r == "close" || r == "stop")
                    break;
            }

            Console.WriteLine("Server stoped succesfully. Press any key to close console");
            Console.ReadKey();
            Environment.Exit(0);
        }
        static private void formStart()
        {
            Application.Run(form);
        }
    }
}
