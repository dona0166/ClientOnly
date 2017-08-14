using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ClientOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            Console.WriteLine("Write the command: ");
            string command = Console.ReadLine();
            myprogram.Running(command);
            Console.ReadKey();
            
            
        }
        public void Running(string option)
        {
            bool running = true;
            
            while (running)
            {
                switch (option) {
                    case "date":
                        Client();
                        break;
                    case "exit":
                        running = false;
                        break;
                }
            }
        }

        public void Client()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint((IPAddress.Parse("127.0.0.1")), 11000);
            client.Connect(remoteEP);
            byte[] message = new byte[1024];
            
                message = Encoding.ASCII.GetBytes("Client: Redhead Time ??");
                client.Send(message);
            
            

            byte[] response = new byte[1024];
            if (response != null)
            {
                client.Receive(response);
                string stringResponse = Encoding.ASCII.GetString(response);
                Console.Write("From Server: " + stringResponse);
            }
            //client.Close();
            //client.Shutdown(SocketShutdown.Both);
            Console.ReadKey();
            Console.Clear();
            


        }
    }
}
