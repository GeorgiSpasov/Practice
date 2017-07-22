using System;

namespace HR0110.TimeConversion
{
    class TimeConversion
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string convertedTime = TimeConverter(input);
            Console.WriteLine(convertedTime);
        }

        static string TimeConverter(string input)
        {
            string result;

            if (input[input.Length - 2] == 'A')
            {
                if (input.Substring(0, 2) == "12")
                {
                    result = "00" + (input.Substring(2, input.Length - 4));
                }
                else
                {
                    result = input.Substring(0, input.Length - 2);
                }
            }
            else
            {
                if (input.Substring(0, 2) == "12")
                {
                    result = input.Substring(0, input.Length - 2);
                }
                else
                {
                    result = (int.Parse(input.Substring(0, 2)) + 12) + (input.Substring(2, input.Length - 4));

                }
            }

            return result;
        }
    }
}
