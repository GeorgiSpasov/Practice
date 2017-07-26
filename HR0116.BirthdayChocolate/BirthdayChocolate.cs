using System;
using System.Linq;

namespace HR0116.BirthdayChocolate
{
    class BirthdayChocolate
    {
        static int BarsCombinations(int[] bars, int day, int month)
        {
            int combinations = 0;

            for (int i = 0; i < bars.Length - month + 1; i++)
            {
                int sum = 0;
                for (int m = 0; m < month; m++)
                {
                    sum += bars[i + m];
                }
                if (sum == day)
                {
                    combinations++;
                }
            }

            return combinations;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] bars = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] dm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int day = dm[0];
            int month = dm[1];

            int combinations = BarsCombinations(bars, day, month);
            Console.WriteLine(combinations);
        }
    }
}
