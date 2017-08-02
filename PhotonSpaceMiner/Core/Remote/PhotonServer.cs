using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PhotonSpaceMiner.Core.Contracts;
using PhotonSpaceMiner.Core.Providers;
using PhotonSpaceMiner.Utils;

namespace PhotonSpaceMiner.Core.Remote
{
    public class PhotonServer : IServer
    {
        private static readonly IServer instance = new PhotonServer();

        private readonly TcpListener server;
        private readonly IPAddress ip;
        private readonly int port;
        private bool isRunning;

        private readonly Dictionary<string, TcpClient> clients;
        private readonly Dictionary<Tuple<string, string>, Player> users; //Load game
        #region Tuple usage
        //Dictionary<Tuple<string, string>, int> dic = new Dictionary<Tuple<string, string>, int>();
        //dic.Add(new Tuple<string, string>("playerNmae", "pass"), 22);
        //dic.Add(new Tuple<string, string>("playerNmae2", "pass1"), 11);
        //string n = "playerNmae";
        //string p = "pass";
        //bool c = dic.ContainsKey(new Tuple<string, string>(n, p));
        //int x = dic[new Tuple<string, string>(n, p)];
        //Console.WriteLine(x + " " + c);
        #endregion

        private PhotonServer()
        {
            this.ip = IPAddress.Parse(PhotonIO.ReadSettings("ip"));
            this.port = int.Parse(PhotonIO.ReadSettings("port"));
            this.server = new TcpListener(this.ip, port);
            this.clients = new Dictionary<string, TcpClient>();
            this.users = GameDB.Instance.Users;
        }

        public static IServer Instance
        {
            get
            {
                return instance;
            }
        }

        public void Start()
        {
            this.server.Start();
            this.isRunning = true;
            Console.WriteLine("PhotonServer initiated!");

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
            // you could use the NetworkStream to read and write, but there is no forcing flush, even when requested

            bool clientConnected = true;
            string data = "";

            // Client status read
            data = sReader.ReadLine();
            Console.WriteLine(data);

            // Connection confirmation
            sWriter.WriteLine("Your client is connected to PhotonServer!");
            sWriter.Flush();

            Thread.Sleep(2000);
            Console.Clear();

            // Player authentication
            string playerName = PlayerAuthentication(client);

            this.ChooseOpponent(client);

            // Initial  communication's end
            sWriter.WriteLine("over");
            sWriter.Flush();

            int i = 0;
            while (clientConnected)
            {
                try
                {
                    data = sReader.ReadLine();//------------------
                    //Player opponent = sReader.CreateObjRef(typeof(Player));

                    //____________________________________________
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
            StreamWriter sWriter = new StreamWriter(client.GetStream());

            sWriter.WriteLine("Enter user name: ");
            sWriter.Flush();
            string playerName = sReader.ReadLine();
            sWriter.WriteLine("Enter password: ");
            sWriter.Flush();
            string password = sReader.ReadLine();

            this.clients.Add(playerName, client); // Exchange user data / choose player 2 =====

            return playerName;
        }

        public void ChooseOpponent(TcpClient client)
        {
            StreamReader sReader = new StreamReader(client.GetStream());
            StreamWriter sWriter = new StreamWriter(client.GetStream());
            sWriter.WriteLine($"Choose your opponent: {string.Join(" | ", this.clients.Keys)}");
            sWriter.Flush();
            string opponentName = sReader.ReadLine();

            sWriter.WriteLine($"You have chosen {this.clients[opponentName]}!");
            sWriter.Flush();

        }
    }
}
