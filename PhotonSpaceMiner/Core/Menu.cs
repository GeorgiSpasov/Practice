using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotonSpaceMiner
{
    public static class Menu
    {
        public static int Start()
        {
            PrintCentred("../../Core/Resources/Start.txt");

            int choice = 1;
            int.TryParse(Console.ReadLine(), out choice);
            Console.Clear();

            return choice;
        }

        public static void PrintCentred(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int i = 1;
                while (!reader.EndOfStream)
                {
                    string inputLine = reader.ReadLine();
                    Console.SetCursorPosition((Console.WindowWidth - inputLine.Length) / 2,
                                               Console.WindowHeight / 2 - 10 + i++);
                    Console.Write(inputLine);
                }
            }
        }
    }
}
