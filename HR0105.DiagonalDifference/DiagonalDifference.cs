using System;
using System.Linq;

namespace HR0105.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] intArray = new int[n][];
            for (int i = 0; i < n; i++)
            {
                intArray[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            int sumPrimary = 0;
            int sumSecondary = 0;
            int absDifference = 0;

            for (int i = 0; i < n; i++)
            {
                sumPrimary += intArray[i][i];
                sumSecondary += intArray[n - 1 - i][i];
            }

            absDifference = Math.Abs(sumPrimary - sumSecondary);
            Console.WriteLine(absDifference);
        }
    }
}
