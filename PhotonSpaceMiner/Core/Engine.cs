using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

using PhotonSpaceMiner.Core.Contracts;
using PhotonSpaceMiner.Model;
using PhotonSpaceMiner.Model.Contracts;
using PhotonSpaceMiner.Remote;
using PhotonSpaceMiner.View;

namespace PhotonSpaceMiner.Core
{
    public class Engine : IEngine
    {
        private static readonly IEngine instance = new Engine();
        private int gameSpeed;

        public static IEngine Instance
        {
            get
            {
                return instance;
            }
        }

        public int GameSpeed
        {
            get
            {
                return this.gameSpeed;
            }
            set
            {
                this.gameSpeed = value;
            }
        }

        public void Run()
        {
            Screen.SetScreenSize(40, 60);
            Instance.GameSpeed = 200;

            int choice = Menu.Start();
            switch (choice)
            {
                case 1:
                    Player offlinePlayer = new Player();
                    Instance.PlayOffline(offlinePlayer);
                    break;
                case 2:
                case 3:
                    IClient client = new PhotonClient();
                    client.ConnectClient();
                    Instance.PlayOnline(client);
                    break;
                case 4:
                    Console.WriteLine("Only in paid version!");
                    Thread.Sleep(1000);
                    return;
                default:
                    break;
            }
        }

        public void PlayOffline(Player offlinePlayer)
        {
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;

                Screen.PrintObject(offlinePlayer);
                Screen.PrintStats(offlinePlayer);
                offlinePlayer.Move();
                offlinePlayer.Score++; // Test ---------------

                Thread.Sleep((int)(600 - Instance.GameSpeed));
            }
        }

        public void PlayOnline(IClient client)
        {
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                //string serverData = client.ReadServerData();
                //Console.WriteLine(serverData);

                // Read GameObjects from server and print
                List<IPrintable> list = ReceiveSerializedList(client);
                Screen.PrintStats((Player)list[0], (Player)list[1]);

                // Mirror opponent
                ((Player)list[1]).playerPosition.Y = 1;
                ((Player)list[1]).Skin = "|<V>|";

                list.ForEach(Screen.PrintObject);

                int pressedKey = ReadPressedKey();
                client.SendData(pressedKey.ToString());

                Thread.Sleep((int)(600 - Instance.GameSpeed));
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

        public IPrintable ReceiveSerializedObejct(TcpClient client)
        {
            IPrintable receivedObject;
            NetworkStream ns = client.GetStream();
            byte[] incommingBytes = new byte[2048];
            ns.Read(incommingBytes, 0, 2048);
            using (var ms = new MemoryStream(incommingBytes))
            {
                var formatter = new BinaryFormatter();
                receivedObject = (IPrintable)formatter.Deserialize(ms);
            }

            return receivedObject;
        }

        public List<IPrintable> ReceiveSerializedList(IClient client)
        {
            List<IPrintable> list = null;
            try
            {
                NetworkStream ns = client.Client.GetStream();
                byte[] incommingBytes = new byte[2048];
                ns.Read(incommingBytes, 0, 2048);
                using (var ms = new MemoryStream(incommingBytes))
                {
                    var formatter = new BinaryFormatter();
                    list = (List<IPrintable>)formatter.Deserialize(ms);
                }

            }
            catch (IOException)
            {
                Console.WriteLine("Connection with server lost!");
                Console.WriteLine("Continue offline? (y/n)");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Instance.PlayOffline(new Player());
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            return list;
        }
    }
}
