using System;

namespace HR0107.Staircase
{
    class Staircase
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string(' ', n - 1 - i) + new string('#', i + 1));
            }
        }
    }
}
