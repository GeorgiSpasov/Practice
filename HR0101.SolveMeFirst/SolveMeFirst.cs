using System;

namespace HR0101.SolveMeFirst
{
    public class SolveMeFirst
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int sum = SumInts(a, b);
            Console.WriteLine(sum);
        }

        public static int SumInts(int a, int b)
        {
            int result = a + b;

            return result;
        }
    }
}
