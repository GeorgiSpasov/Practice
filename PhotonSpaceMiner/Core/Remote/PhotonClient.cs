using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using PhotonSpaceMiner.Core.Contracts;
using PhotonSpaceMiner.Core.Remote;
using PhotonSpaceMiner.Model;
using PhotonSpaceMiner.Utils;

namespace PhotonSpaceMiner.Remote
{
    public class PhotonClient : IClient
    {
        private TcpClient client;
        private IPAddress ip;
        private int port;
        private StreamReader sReader;
        private StreamWriter sWriter;

        private Player clientPlayer;
        private string playerName;

        public PhotonClient()
        {
            this.ip = IPAddress.Parse(PhotonIO.ReadSettings("ip"));
            this.port = int.Parse(PhotonIO.ReadSettings("port"));
            this.client = new TcpClient();
        }

        public TcpClient Client
        {
            get
            {
                return this.client;
            }
            set
            {
                this.client = value;
            }
        }

        public Player ClientPlayer
        {
            get
            {
                return this.clientPlayer;
            }
            set
            {
                this.clientPlayer = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                this.playerName = value;
            }
        }

        public void ConnectClient()
        {
            while (!client.Connected)
            {
                try
                {
                    Console.WriteLine("Attempting connection...");
                    client.Connect(this.ip, this.port);
                    this.sReader = new StreamReader(client.GetStream());
                    this.sWriter = new StreamWriter(client.GetStream());

                    this.sWriter.WriteLine("New player connected! " + DateTime.Now);
                    this.sWriter.Flush();
                    // Connection confirmation from server
                    Console.WriteLine(this.sReader.ReadLine());

                    // Initial communication with server
                    string incoming = "";
                    while (true)
                    {
                        incoming = sReader.ReadLine();
                        Console.WriteLine(incoming);
                        if (incoming == "over")
                        {
                            break;
                        }
                        sWriter.WriteLine(Console.ReadLine());
                        sWriter.Flush();
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Connection Error!");

                    Console.WriteLine("Starting new Photon server...");
                    Thread serverThread = new Thread(PhotonServer.Instance.Start);
                    serverThread.Start();
                }
            }
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

        public string ReadServerData()
        {
            string serverData = "";
            try
            {
                serverData = this.sReader.ReadLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading object!");
            }

            return serverData;
        }

        public void Chat()
        {
            while (client.Connected)
            {
                Console.Write("Client: ");
                string sData = Console.ReadLine();

                sWriter.WriteLine(sData);
                sWriter.Flush();

                String sDataIncomming = sReader.ReadLine();
                Console.WriteLine(sDataIncomming);
            }
        }

        public void CloseClient()
        {
            sWriter.Close();
            sReader.Close();
            client.Close();
        }
    }
}