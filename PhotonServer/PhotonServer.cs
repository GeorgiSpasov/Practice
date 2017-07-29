using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
{
    public class PhotonServer
    {
        private TcpListener server;
        private IPAddress ip; // Store it in a configuration file
        private int port;
        private bool isRunning;

        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();


        public PhotonServer(string ip = "127.0.0.1", int port = 5555)
        {
            this.ip = IPAddress.Parse(ip);
            this.port = port;
            this.server = new TcpListener(this.ip, port);
            this.server.Start();
            Console.WriteLine("PhotonServer initiated!");
            this.isRunning = true;

            this.LoopClients();
        }

        public void LoopClients()
        {
            while (isRunning) // Add server close method
            {
                Console.WriteLine("Waiting for connection...");

                // wait for client connection
                TcpClient newClient = server.AcceptTcpClient();

                // client found & create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

            StreamWriter sWriter = new StreamWriter(client.GetStream());
            StreamReader sReader = new StreamReader(client.GetStream());
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested

            bool clientConnected = true;
            string data = null;

            // Client status read
            data = sReader.ReadLine();
            Console.WriteLine(data);

            // Connection confirmation
            sWriter.WriteLine("Your client is connected to Photon server!");
            sWriter.Flush();


            // Player authentication
            string playerName = PlayerAuthentication(client); // Could throw exception!!!

            Console.WriteLine(string.Join("\n", this.clients));
            Console.ReadLine();


            int i = 0;
            while (clientConnected)
            {
                try
                {
                    data = sReader.ReadLine();
                    Console.WriteLine(playerName + ": " + data);

                    if (data == "terminate")
                    {
                        Console.WriteLine("User terminated connectioin!");

                        sWriter.Close();
                        sReader.Close();
                        client.Close();
                        clientConnected = false;
                    }

                    // to write something back
                    sWriter.WriteLine("server test data: " + ((i++) % 10));
                    sWriter.Flush();
                    Thread.Sleep(200); //Match game speed!!!!!=============
                }
                catch (Exception)
                {
                    Console.WriteLine("Connection with player lost!");
                    sWriter.Close();
                    sReader.Close();
                    client.Close();
                    clientConnected = false;
                }
            }
        }

        public string PlayerAuthentication(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream());
            string playerName = sReader.ReadLine();
            Console.WriteLine(playerName);
            string password = sReader.ReadLine();
            Console.WriteLine(password);

            this.clients.Add(playerName, client); // Exchange user data / choose player 2 =====

            return playerName;
        }


        static void Main(string[] args)
        {
            PhotonServer server = new PhotonServer();
        }
    }
}
