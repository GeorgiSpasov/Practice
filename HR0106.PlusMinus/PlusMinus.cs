using System;
using System.Linq;

namespace HR0106.PlusMinus
{
    class PlusMinus
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int positiveCount = 0;
            int negativeCount = 0;
            int zeroCount = 0;

            foreach (int item in intArray)
            {
                if (item > 0)
                {
                    positiveCount++;
                }
                else if (item < 0)
                {
                    negativeCount++;
                }
                else
                {
                    zeroCount++;
                }
            }

            Console.WriteLine((double)positiveCount / n);
            Console.WriteLine((double)negativeCount / n);
            Console.WriteLine((double)zeroCount / n);
        }
    }
}
