using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PhotonSpaceMiner;

namespace PhotonSpaceMiner
{
    public static class GameStart
    {
        public static void Print(Player player)
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = player.Color;
            Console.SetCursorPosition(player.PlayerPosition.X, player.PlayerPosition.Y);
            Console.WriteLine(player);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Score: {player.Score} Position: X:{player.PlayerPosition.X} Y:{player.PlayerPosition.Y}");
        }


        public static void Main()
        {
            //Console size
            Console.BufferHeight = Console.WindowHeight = 40;
            Console.BufferWidth = Console.WindowWidth = 60;
            double speed = 200.0;

            //Start client
            Client client = new Client();

            Player player = new Player();

            Console.SetCursorPosition((Console.WindowWidth - player.Skin.Length) / 2, Console.WindowHeight - 1);

            while (true) //Animation
            {
                Console.Clear();

                Print(player);
                player.Move();
                player.Score++;

                client.SendData(player.PlayerPosition.ToString());
                client.ReadServerData();

                Thread.Sleep((int)(600 - speed)); //Refresh rate
            }
        }
    }
}
