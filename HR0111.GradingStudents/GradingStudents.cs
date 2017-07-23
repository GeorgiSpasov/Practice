using System;

namespace HR0111.GradingStudents
{
    class GradingStudents
    {
        static int[] RoundGeades(int[] input)
        {
            int[] result = new int[input.Length];
            int nextMultiple = 0;

            for (int i = 0; i < input.Length; i++)
            {
                nextMultiple = (input[i] + 5) - (input[i] + 5) % 5;
                if ((input[i] >= 38) && (nextMultiple - input[i] < 3))
                {
                    result[i] = nextMultiple;
                }
                else
                {
                    result[i] = input[i];
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] grades = new int[n];
            for (int i = 0; i < n; i++)
            {
                grades[i] = int.Parse(Console.ReadLine());
            }
            int[] result = RoundGeades(grades);
            Console.WriteLine(String.Join("\n", result));
        }
    }
}
