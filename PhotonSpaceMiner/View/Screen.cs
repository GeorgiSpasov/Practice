using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotonSpaceMiner.Model.Contracts;
using PhotonSpaceMiner.Model;

namespace PhotonSpaceMiner.View
{
    public static class Screen
    {
        public static readonly int screenHight;
        public static readonly int screenWidth;

        public static void SetScreenSize(int hight, int width/*, int refreshRate*/)
        {
            Console.BufferHeight = Console.WindowHeight = hight;
            Console.BufferWidth = Console.WindowWidth = width;
        }

        public static void PrintObject(IPrintable obj)
        {
            Console.ForegroundColor = obj.Color;
            Console.SetCursorPosition(obj.PlayerPosition.X, obj.PlayerPosition.Y);
            Console.Write(obj);
        }

        public static void PrintStats(Player player1, Player player2 = null)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Score: {player1.Score} Position: X:{player1.PlayerPosition.X} Y:{player1.PlayerPosition.Y}");

            if (player2 != null)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(30, 0);
                Console.WriteLine($"Score: {player1.Score} Position: X:{player1.PlayerPosition.X} Y:{player1.PlayerPosition.Y}");
            }
        }
    }
}
