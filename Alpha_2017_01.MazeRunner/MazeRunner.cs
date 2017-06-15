using System;

namespace Alpha_2017_01.MazeRunner
{
    class MazeRunner
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = new string[n];

            for (int i = 0; i < n; i++)
            {
                int sumEven = 0;
                int sumOdd = 0;
                int asciiCode = 48;
                string input = Console.ReadLine();

                foreach (var digit in input)
                {
                    if ((digit - asciiCode) % 2 == 0)
                    {
                        sumEven += (digit - asciiCode);
                    }
                    else
                    {
                        sumOdd += (digit - asciiCode);
                    }

                    if (sumEven > sumOdd)
                    {
                        directions[i] = "left";
                    }
                    else if (sumEven < sumOdd)
                    {
                        directions[i] = "right";
                    }
                    else
                    {
                        directions[i] = "straight";
                    }
                }
            }

            foreach (string direction in directions)
            {
                Console.WriteLine(direction);
            }
        }
    }
}
