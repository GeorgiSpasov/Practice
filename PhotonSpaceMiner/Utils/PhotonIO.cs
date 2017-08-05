using System;
using System.IO;

namespace PhotonSpaceMiner.Utils
{
    public static class PhotonIO
    {
        public static string ReadSettings(string property)
        {
            string setting = "";
            using (StreamReader reader = new StreamReader("../../Core/Settings.txt"))
            {
                string line;
                while (true)
                {
                    line = reader.ReadLine();
                    if (line.Contains(property.ToLower()))
                    {
                        setting = line.Split(new string[] { ":>" }, StringSplitOptions.RemoveEmptyEntries)[1];
                        return setting;
                    }
                }
            }
        }

        public static void PrintMenu(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int i = 1;
                while (!reader.EndOfStream)
                {
                    string inputLine = reader.ReadLine();
                    Console.SetCursorPosition((Console.WindowWidth - inputLine.Length) / 2,
                                               Console.WindowHeight / 2 - 10 + i++);
                    Console.Write(inputLine);
                }
            }
        }
    }
}
