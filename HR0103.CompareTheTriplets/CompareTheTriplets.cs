using System;

namespace HR0103.CompareTheTriplets
{
    class CompareTheTriplets
    {
        static int[] Solve(int a0, int a1, int a2, int b0, int b1, int b2)
        {
            // Complete this function
            int[] scores = new int[2];
            int scoreA = 0;
            int scoreB = 0;

            if (a0 > b0)
            {
                scoreA++;
            }
            if (a0 < b0)
            {
                scoreB++;
            }
            if (a1 > b1)
            {
                scoreA++;
            }
            if (a1 < b1)
            {
                scoreB++;
            }
            if (a2 > b2)
            {
                scoreA++;
            }
            if (a2 < b2)
            {
                scoreB++;
            }

            scores[0] = scoreA;
            scores[1] = scoreB;

            return scores;
        }

        static void Main(String[] args)
        {
            string[] tokens_a0 = Console.ReadLine().Split(' ');
            int a0 = Convert.ToInt32(tokens_a0[0]);
            int a1 = Convert.ToInt32(tokens_a0[1]);
            int a2 = Convert.ToInt32(tokens_a0[2]);
            string[] tokens_b0 = Console.ReadLine().Split(' ');
            int b0 = Convert.ToInt32(tokens_b0[0]);
            int b1 = Convert.ToInt32(tokens_b0[1]);
            int b2 = Convert.ToInt32(tokens_b0[2]);
            int[] result = Solve(a0, a1, a2, b0, b1, b2);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
