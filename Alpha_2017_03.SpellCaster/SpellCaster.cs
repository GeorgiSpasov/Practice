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
            //string[] words = Console.ReadLine().Split(' ');
            string[] words = "Fun exam right".Split(' ');
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
            
            Console.WriteLine(appended);

            // Step 2 ============================================================

            foreach (char c in appended.ToString())
            {

            }

            -96
            Console.WriteLine((int)'a');




        }
    }
}
