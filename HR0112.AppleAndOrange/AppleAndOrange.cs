using System;
using System.Linq;

namespace HR0112.AppleAndOrange
{
    class AppleAndOrange
    {
        static void Main(string[] args)
        {
            int[] housePoints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int houseS = housePoints[0];
            int houseT = housePoints[1];

            int[] treePositions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int treeA = treePositions[0];
            int treeB = treePositions[1];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] appleDistances = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] orangeDistances = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int apples = appleDistances.Count(a => houseS <= treeA + a && treeA + a <= houseT);
            int oranges = orangeDistances.Count(o => houseS <= treeB + o && treeB + o <= houseT);

            Console.WriteLine(apples);
            Console.WriteLine(oranges);
        }
    }
}
