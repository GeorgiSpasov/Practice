using System;
using System.Linq;

namespace HR0109.BirthdayCakeCandles
{
    class BirthdayCakeCandles
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] candles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int result = 0;

            int maxHight = candles.Max();
            foreach (int candle in candles)
            {
                if (candle == maxHight)
                {
                    result++;
                }
            }

            Console.WriteLine(result);
        }
    }
}
