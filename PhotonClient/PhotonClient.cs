using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotonClient
{
    public class PhotonClient
    {
        private NetworkStream output;
        private BinaryWriter writer;
        private BinaryReader reader;
        private Thread readThread;
        private string message = null;

        private void LoadClient()
        {
            readThread = new Thread(new ThreadStart(RunClient));
            readThread.Start();
        }

        public void SendData(string output)
        {
            try
            {
                this.writer.Write("Client: " + output);
            }
            catch (SocketException)
            {
                Console.WriteLine("Error writing object!");
            }
        }

        public void RunClient()
        {
            TcpClient client;

            try
            {
                Console.WriteLine("Attempting connection");

                client = new TcpClient();
                client.Connect("127.0.0.1", 50000);
                output = client.GetStream();
                writer = new BinaryWriter(output);
                reader = new BinaryReader(output);

                do
                {
                    try
                    {
                        message = reader.ReadString();
                        Console.WriteLine(message);

                        SendData(Console.ReadLine()); //Added
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Connection lost!");
                    }
                } while (message != "Server: terminate");

                writer.Close();
                reader.Close();
                output.Close();
                client.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Connection Error");
            }
        }

        static void Main(string[] args)
        {
            PhotonClient pc = new PhotonClient();
            pc.LoadClient();
        }

        public void StartMyClient()
        {
            TcpClient client = new TcpClient();
            string output = null;
            string input = null;

            while (!client.Connected)
            {
                try
                {
                    client.Connect("localhost", 50000);
                    if (client.Connected)
                    {
                        Console.WriteLine("Connection with server established!");
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("No server available! " + DateTime.Now);
                    Thread.Sleep(2400);
                }
            }


            while (true)
            {
                NetworkStream stream = client.GetStream();
                BinaryWriter writer = new BinaryWriter(stream);
                BinaryReader reader = new BinaryReader(stream);

                while (output != "end")
                {
                    output = Console.ReadLine();
                    writer.Write(output);
                    if (output == "end")
                    {
                        client.Close();
                    }

                    input = reader.ReadString();
                    Console.WriteLine("Server: " + input);
                }
            }
        }
    }
}
