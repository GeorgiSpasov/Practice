using System;

using PhotonSpaceMiner.Utils;

namespace PhotonSpaceMiner
{
    public static class Menu
    {
        public static int Start()
        {
            string path = "../../Core/Resources/Start.txt";
            PhotonIO.PrintMenu(path);

            int choice = int.Parse(Console.ReadLine());
            Console.Clear();

            return choice;
        }
    }
}
