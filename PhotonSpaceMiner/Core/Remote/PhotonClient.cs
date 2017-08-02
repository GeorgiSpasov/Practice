using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PhotonSpaceMiner.Core.Remote;
using PhotonSpaceMiner.Utils;
using PhotonSpaceMiner.Core.Contracts;
using System.Runtime.Serialization.Formatters.Binary;

namespace PhotonSpaceMiner.Remote
{
    public class PhotonClient : IClient
    {
        private static readonly IClient instance = new PhotonClient();

        private TcpClient client;
        private IPAddress ip;
        private int port;
        private StreamReader sReader;
        private StreamWriter sWriter;

        public PhotonClient()
        {
            this.ip = IPAddress.Parse(PhotonIO.ReadSettings("ip"));
            this.port = int.Parse(PhotonIO.ReadSettings("port"));
            this.client = new TcpClient();
        }

        public static IClient Instance
        {
            get
            {
                return instance;
            }
        }

        public void ConnectClient()
        {
            while (!client.Connected)
            {
                try
                {
                    Console.WriteLine("Attempting connection...");
                    client.Connect(this.ip, port);
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

        public void SendObj(Player output)
        {
            try
            {
                //+++++++++++++++++++++++++++++++++
                // TODO: Send player
                //_______________________________
                this.sWriter.WriteLine(output);
                this.sWriter.Flush();
            }
            catch (SocketException)
            {
                Console.WriteLine("Error writing object!");
            }
        }

        public void ReadServerData()
        {
            try
            {
                string incoming = this.sReader.ReadLine();
                Console.WriteLine(incoming);
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading object!");
            }
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