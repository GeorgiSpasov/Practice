using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PhotonSpaceMiner.Remote;
using PhotonSpaceMiner.Core.Contracts;
using PhotonSpaceMiner.Model;
using PhotonSpaceMiner.View;
using PhotonSpaceMiner.Model.Contracts;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PhotonSpaceMiner.Core
{
    public class Engine : IEngine
    {
        private static readonly IEngine instance = new Engine();

        //private readonly Dictionary<Tuple<string, string>, Player> users; //Load game
        private Player offlinePlayer; // only for offline play
        private int gameSpeed;

        public Engine()
        {
        }

        public static IEngine Instance
        {
            get
            {
                return instance;
            }
        }



        public void Run()
        {
            Screen.SetScreenSize(40, 60);
            this.gameSpeed = 200;// set on other place -----------



            this.offlinePlayer = new Player(); //choose from game 

            IClient client = null;//------------------------------
            int choice = Menu.Start();
            switch (choice)
            {
                case 1:
                    this.Animate();
                    break;
                case 2:
                case 3:
                    client = PhotonClient.Instance;
                    client.ConnectClient();
                    this.PlayOnLine(client);
                    break;
                case 4:
                    Console.WriteLine("Not supported yet!");//===============
                    Thread.Sleep(1000);
                    return;
                default:
                    break;
            }
        }

        public void Animate()
        {
            while (true) //Animation ================================================
            {
                Console.Clear();
                Console.CursorVisible = false;
                Screen.PrintObject(offlinePlayer);
                Screen.PrintStats(offlinePlayer);

                offlinePlayer.Move();
                offlinePlayer.Score++;

                //if (choice == 2 || choice == 3)
                //{
                //    client.SendData(currentPlayer.PlayerPosition.ToString());
                //    //client.SendObj(currentPlayer);
                //    client.ReadServerData();
                //}

                Thread.Sleep((int)(600 - gameSpeed)); //Refresh rate
            }
        }

        public void PlayOnLine(IClient client)
        {
            // Online Animation ================================================
            while (true) 
            {
                Console.Clear();
                Console.CursorVisible = false;
                //string serverData = client.ReadServerData();
                //Console.WriteLine(serverData);
                
                // Read GameObjects from server and print
                NetworkStream ns = client.Client.GetStream();
                byte[] incommingBytes = new byte[1024];
                ns.Read(incommingBytes, 0, 1024);
                IPrintable receivedObject;
                using (var ms = new MemoryStream(incommingBytes))
                {
                    var formatter = new BinaryFormatter();
                    
                    ms.Seek(0, SeekOrigin.Begin);
                    receivedObject = (IPrintable)formatter.Deserialize(ms);
                }

                Screen.PrintObject(receivedObject);
                Screen.PrintStats((Player)receivedObject);

                int pressedKey = ReadPressedKey();
                client.SendData(pressedKey.ToString());

                Thread.Sleep((int)(600 - gameSpeed)); //Refresh rate
            }
        }

        public int ReadPressedKey()
        {
            int result = 0;
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                result = (int)pressedKey.Key;
            }

            return result;
        }
    }
}
