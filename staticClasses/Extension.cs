using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StaticClass
{
    static class Extension
    {
        private static Random random = new Random();

        // Tar en sträng och ersätter en karaktär på ett index med en ny sträng
        public static string ReplaceAt(this string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index)).Insert(index, replace);
        }

        // Skriver ut en sträng-array i konsolfönstret med given färg
        public static void WriteColorized(this string[] stringArray, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            foreach (string str in stringArray)
            {
                Console.Write(str);
            }
            Console.ResetColor();
        }
        public static void Write(this string[] stringArray)
        {
            foreach (string str in stringArray)
            {
                Console.Write(str);
            }
        }

        // Skriver ut en lista med strängar med färgen "Magenta"
        public static void WriteAsOptions(this List<string> optionList)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (string option in optionList)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Skriver ut ett meddelande med bakgrundsfärgen 'Röd' och textfärgen 'Svart'
        static public void WriteAsError(this string errorMessage)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
            Console.WriteLine();
        }

        // Returnerar en lista med alla index från en annan lista
        static public List<int> GetIndexOfLists(this List<List<Group>> list)
        {
            List<int> indexList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                indexList.Add(i);
            }

            return indexList;
        }
        // Skriver ut en sträng-array i konsolfönstret med given färg på ställen utmärkta med hjälp av Regex
        public static void PrintColorized(this string[] stringArray, ConsoleColor foregroundColor, string regexPattern)
        {
            Regex regex = new Regex(regexPattern);
            foreach (string str in stringArray)
            {
                Match match = regex.Match(str);

                if (match.Success)
                {
                    foreach (Group group in match.Groups)
                    {
                        if (group.Name.Contains("color"))
                        {
                            Console.ForegroundColor = foregroundColor;
                            Console.Write(group.Value);
                            Console.ResetColor();
                        }
                        else if (group.Name.Contains("default"))
                        {
                            Console.Write(group.Value);
                        }
                    }
                }
                else
                {
                    Console.Write(str);
                }
            }
        }
        // Skriver ut en sträng-array i konsolfönstret med given färg på ställen utmärkta med hjälp av Regex och Random
        public static void PrintColorizedRandom(this string[] stringArray, string regexPattern)
        {
            Random random = new Random();
            Regex regex = new Regex(regexPattern);
            foreach (string str in stringArray)
            {
                Match match = regex.Match(str);

                if (match.Success)
                {
                    foreach (Group group in match.Groups)
                    {
                        if (group.Name.Contains("color"))
                        {
                            Console.ForegroundColor = (ConsoleColor)random.Next(0, Enum.GetNames(typeof(ConsoleColor)).Length);
                            Console.Write(group.Value);
                            Console.ResetColor();
                        }
                        else if (group.Name.Contains("default"))
                        {
                            Console.Write(group.Value);
                        }
                    }
                }
            }
        }

        // Läser av vilken färgkod smaken har
        public static ConsoleColor ToColor(this Flavours flavour)
        {
            if ((int)flavour == 99)
            {
                return (ConsoleColor)random.Next(0, Enum.GetNames(typeof(ConsoleColor)).Length);
            }
            else
            {
                return (ConsoleColor)flavour;
            }
        }
    }
}