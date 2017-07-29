using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientDemo;

namespace Game
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
            String ip = "127.0.0.1";
            int port = 5555;
            ClientDemo.ClientDemo client = new ClientDemo.ClientDemo(ip, port);

            Player player = new Player();

            Console.SetCursorPosition((Console.WindowWidth - player.Skin.Length) / 2, Console.WindowHeight - 1);

            int i = 0;

            while (true) //Animation
            {
                Console.Clear();

                Print(player);
                player.Move();
                player.Score++;

                client.SendData(player.PlayerPosition.ToString());

                Thread.Sleep((int)(600 - speed)); //Refresh rate
            }
        }
    }
}
