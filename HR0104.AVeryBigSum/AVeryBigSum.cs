using System;
using System.Linq;

namespace HR0104.AVeryBigSum
{
    class AVeryBigSum
    {
        static long BigSum(int n, long[] ar)
        {
            // Complete this function
            return ar.Sum();
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arTemp = Console.ReadLine().Split(' ');
            long[] ar = Array.ConvertAll(arTemp, Int64.Parse);
            long result = BigSum(n, ar);
            Console.WriteLine(result);
        }
    }
}
