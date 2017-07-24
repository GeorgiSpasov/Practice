using System;
using System.Linq;

namespace HR0113.Kangaroo
{
    class Kangaroo
    {

        static string KangarooCheck(int start1, int rate1, int start2, int rate2)
        {
            string result = "";
            if (rate1 == rate2 || (start1 > start2 && rate1 > rate2) || (start1 < start2 && rate1 < rate2))
            {
                result = "NO";
            }
            else
            {
                if ((start1 - start2) % (rate2 - rate1) == 0)
                {
                    result = "YES";
                }
                else
                {
                    result = "NO";
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start1 = input[0];
            int rate1 = input[1];
            int start2 = input[2];
            int rate2 = input[3];
            string result = KangarooCheck(start1, rate1, start2, rate2);
            Console.WriteLine(result);
        }
    }
}
