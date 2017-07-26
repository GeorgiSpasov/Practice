using System;
using System.Linq;

namespace HR0114.BetweenTwoSets
{
    class BetweenTwoSets
    {
        static void Main(string[] args)
        {
            int[] numberOfElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] setA = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] setB = Console.ReadLine().Split().Select(int.Parse).ToArray();


            int result = CountElementsBetween(setA, setB);
            Console.WriteLine(result);
        }

        static int CountElementsBetween(int[] setA, int[] setB)
        {
            int count = 0;
            int lcmA = GetLCM(setA);
            int gcdB = GetGCD(setB);

            for (int i = lcmA; i <= gcdB; i += lcmA)
            {
                if (gcdB % i == 0)
                {
                    count++;
                }
            }

            return count;
        }

        //Greatest Common Divisor
        static int GetGCD(int a, int b)
        {
            while (b > 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        static int GetGCD(int[] b)
        {
            int gcd = b[0];
            for (int i = 1; i < b.Length; i++)
            {
                gcd = GetGCD(gcd, b[i]);
            }

            return gcd;
        }

        //Least Common Multiple
        static int GetLCM(int a, int b)
        {
            int lcm = a * b / GetGCD(a, b);

            return lcm;
        }

        static int GetLCM(int[] a)
        {
            int lcm = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                lcm = GetLCM(lcm, a[i]);
            }

            return lcm;
        }
    }
}
