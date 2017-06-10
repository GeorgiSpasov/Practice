using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_2017_03.SpellCaster
{
    class SpellCaster
    {
        static void Main(string[] args)
        {
            // Step 1 ============================================================
            string[] words = Console.ReadLine().Split(' ');
            StringBuilder appended = new StringBuilder();

            int longest = words.OrderBy(w => w.Length).Last().Length;

            for (int i = 0; i < longest; i++)
            {
                foreach (string word in words)
                {
                    if (word.Length > i)
                    {
                        appended.Append(word[word.Length - 1 - i]);
                    }
                }
            }
            
            // Step 2 ============================================================

            char currentChar = ' ';
            int charNumber = 0;
            int shift = 0;

            for (int i = 0; i < appended.Length; i++)
            {
                currentChar = appended.ToString()[i];
                charNumber = appended.ToString().ToLower()[i] - 96;
                if ((charNumber % appended.Length + i) < appended.Length)
                {
                    shift = charNumber % appended.Length + i;
                }
                else
                {
                    shift = charNumber % appended.Length + i - appended.Length;
                }

                appended.Remove(i, 1);
                appended.Insert(shift, currentChar);
            }
            Console.WriteLine(appended);
        }
    }
}
