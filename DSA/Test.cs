using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class Test
    {
        public static void Main(string[] args)
        {
            int[] sortedArray = { 2, 3, 5, 7, 9, 11, 14, 18 };
            int n = 11;
            int nIndex = BinayrSearch<int>(n, sortedArray);
            Console.WriteLine(nIndex);

        }

        static decimal Factorial(int n)
        {
            decimal sum = 0;
            if (n <= 1)
            {
                return 1;
            }

            sum += n * Factorial(n - 1);
            return sum;
        }

        public static string ReverseString(string input)
        {
            if (input.Length == 1)
            {
                return input;
            }
            string newString = input.Substring(0, input.Length - 1);
            string result = input[input.Length - 1] + ReverseString(newString);
            return result;
        }

        public static int BinayrSearch<T>(int n, IList<T> array)
        {
            return BinayrSearch(n, array, 0, array.Count - 1);
        }

        public static int BinayrSearch<T>(int n, IList<T> array, int minIndex, int maxIndex)
        {
            int nIndex = 0;
            int midIndex = (maxIndex + minIndex) / 2;
            if (minIndex > maxIndex)
            {
                return -1;
            }

            if (n.CompareTo(array[midIndex]) == 0)
            {
                return midIndex;
            }
            else if (n.CompareTo(array[midIndex]) < 0)
            {
                return nIndex = BinayrSearch(n, array, minIndex, --midIndex);
            }
            else if (n.CompareTo(array[midIndex]) > 0)
            {
                return nIndex = BinayrSearch(n, array, ++midIndex, maxIndex);
            }

            return nIndex;
        }
    }
}
