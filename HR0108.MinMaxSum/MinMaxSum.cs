using System;
using System.Linq;

namespace HR0108.MinMaxSum
{
    class MinMaxSum
    {
        static void Main(string[] args)
        {
            long[] intArray = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long minSum = intArray.Sum() - intArray.Max();
            long maxSum = intArray.Sum() - intArray.Min();

            Console.WriteLine(minSum + " " + maxSum);
        }
    }
}
