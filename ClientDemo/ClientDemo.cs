using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemo
{
    public class ClientDemo
    {
        private TcpClient client;
        private IPAddress ip; // Store it in a configuration file
        private int port;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private Boolean isConnected;

        public ClientDemo(string ip = "127.0.0.1", int port = 5555)
        {
            this.ip = IPAddress.Parse(ip);
            this.port = port;
            this.client = new TcpClient();
            this.RunClient();
            this.HandleCommunication();
        }

        public void RunClient()
        {
            while (!client.Connected)
            {
                try
                {
                    Console.WriteLine("Attempting connection...");
                    client.Connect(this.ip, port);
                    Console.WriteLine("PhotonClient initiated!");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Connection Error");
                }

                Thread.Sleep(5000);
            }
        }

        public void HandleCommunication()
        {
            this.sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            this.sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);

            this.isConnected = true;
            String sData = null;

            this.sWriter.WriteLine("New player connected! " + DateTime.Now);
            this.sWriter.Flush();

            //Player Athentication
            this.SendCredentials();



            //while (_isConnected)
            //{
            //    ////Console.Write("&gt; ");
            //    ////sData = Console.ReadLine();

            //    ////// write data and make sure to flush, or the buffer will continue to 
            //    ////// grow, and your data might not be sent when you want it, and will
            //    ////// only be sent once the buffer is filled.
            //    ////_sWriter.WriteLine(sData);
            //    _sWriter.WriteLine("connected");
            //    _sWriter.Flush();

            //    ////// if you want to receive anything
            //    ////String sDataIncomming = _sReader.ReadLine();
            //    ////Console.WriteLine(sDataIncomming);
            //}
        }

        public void SendCredentials()
        {
            Console.Write("Enter user name: ");
            string userName = Console.ReadLine();
            sWriter.WriteLine(userName);
            sWriter.Flush();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            sWriter.WriteLine(password);
            sWriter.Flush();
        }

        public void SendData(string output)
        {
            try
            {
                this.sWriter.WriteLine(output);
                this.sWriter.Flush();
            }
            catch (SocketException)
            {
                Console.WriteLine("Error writing object!");
            }

        }

        static void Main(string[] args)
        {
            ClientDemo client = new ClientDemo();
        }
    }
}
