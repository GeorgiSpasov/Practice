using System;
using System.Linq;

namespace HR0102.SimpleArraySum
{
    public class SimpleArraySum
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] intArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = ArraySum(n, intArray);
            Console.WriteLine(sum);
        }

        public static int ArraySum(int n, int[] array)
        {
            int result = array.Sum();

            return result;
        }
    }
}
