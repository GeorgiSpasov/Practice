using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PhotonSpaceMiner.Remote;
using PhotonSpaceMiner.Core.Contracts;

namespace PhotonSpaceMiner.Core
{
    public class Engine : IEngine
    {
        private static readonly IEngine instance = new Engine();

        private readonly Player currentPlayer;

        public Engine()
        {
            this.currentPlayer = new Player(); //choose from game mode ? new, load, register
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
            //Console size
            Console.BufferHeight = Console.WindowHeight = 40;
            Console.BufferWidth = Console.WindowWidth = 60;
            double speed = 200.0;

            IClient client = null;
            int choice = Menu.Start();
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                case 3:
                    //Start client
                    client = PhotonClient.Instance;
                    client.ConnectClient();
                    break;
                case 4:
                    Console.WriteLine("Not supported yet!");//===============
                    Thread.Sleep(1000);
                    return;
                default:
                    break;
            }

            Player currentPlayer = new Player(); // ??? positioning

            Console.SetCursorPosition((Console.WindowWidth - currentPlayer.Skin.Length) / 2, Console.WindowHeight - 1);

            while (true) //Animation
            {
                Console.Clear();
                Console.CursorVisible = false;

                Print(currentPlayer);
                currentPlayer.Move();
                currentPlayer.Score++;

                if (choice == 2 || choice == 3)
                {
                    //client.SendData(currentPlayer.PlayerPosition.ToString()); //---------------------------------02.08.2017
                    client.SendObj(currentPlayer);
                    client.ReadServerData();
                }

                Thread.Sleep((int)(600 - speed)); //Refresh rate
            }
        }

        public static void Print(Player player)
        {
            Console.ForegroundColor = player.Color;
            Console.SetCursorPosition(player.PlayerPosition.X, player.PlayerPosition.Y);
            Console.Write(player);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Score: {player.Score} Position: X:{player.PlayerPosition.X} Y:{player.PlayerPosition.Y}");
        }
    }
}
