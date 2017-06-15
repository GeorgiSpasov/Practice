using System;

namespace Alpha_2017_02.PaperCutter
{
    class PaperCutter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sheetsCapacity = new int[11];
            for (int i = 0; i < sheetsCapacity.Length; i++)
            {
                sheetsCapacity[sheetsCapacity.Length - 1 - i] = (int)Math.Pow(2, i);
            }

            for (int i = 0; i < sheetsCapacity.Length; i++)
            {
                if (n >= sheetsCapacity[i] && sheetsCapacity[i] != 0)
                {
                    n -= sheetsCapacity[i];
                    sheetsCapacity[i] = 0;
                }
            }

            for (int i = 0; i < sheetsCapacity.Length; i++)
            {
                if (sheetsCapacity[sheetsCapacity.Length - 1 - i] != 0)
                {
                    Console.WriteLine("A" + (sheetsCapacity.Length - 1 - i));
                }
            }
        }
    }
}
