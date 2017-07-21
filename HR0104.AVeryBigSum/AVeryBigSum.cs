using System;
using System.Linq;

namespace HR0104.AVeryBigSum
{
    class AVeryBigSum
    {
        static long aVeryBigSum(int n, long[] ar)
        {
            // Complete this function
            return ar.Sum();
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] ar_temp = Console.ReadLine().Split(' ');
            long[] ar = Array.ConvertAll(ar_temp, Int64.Parse);
            long result = aVeryBigSum(n, ar);
            Console.WriteLine(result);
        }
    }
}
