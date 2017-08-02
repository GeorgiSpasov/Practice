using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PhotonSpaceMiner.Utils;

namespace PhotonSpaceMiner
{
    public static class Menu
    {
        public static int Start()
        {
            PhotonIO.PrintMenu("../../Core/Resources/Start.txt");

            int choice = 1;
            int.TryParse(Console.ReadLine(), out choice);
            Console.Clear();

            return choice;
        }
    }
}
