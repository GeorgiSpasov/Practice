using System;
using System.Linq;

namespace HR0115.BreakingTheRecords
{
    class BreakingTheRecords
    {
        static int[] GetRecord(int[] scores)
        {
            int[] result = new int[2];
            int maxRecord = scores[0];
            int minRecord = scores[0];
            int countMax = 0;
            int countMin = 0;

            foreach (int score in scores)
            {
                if (score > maxRecord)
                {
                    maxRecord = score;
                    countMax++;
                }
                else if (score < minRecord)
                {
                    minRecord = score;
                    countMin++;
                }
            }

            result[0] = countMax;
            result[1] = countMin;

            return result;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] scores = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] records = GetRecord(scores);

            Console.WriteLine(string.Join(" ", scores));
        }
    }
}
