using System;
using System.Globalization;
using System.Text.RegularExpressions;
using NamespaceProduct;

namespace StaticClass
{
    static class Utility
    {
        static Random random = new Random();

        /*  Kontrollerar att regnumret är korrekt inmatat
         *  Letar efter mönster likt: ABC 232, eller ABC 12X
         *  Ett exempel från programmet är: ([a-zA-Z]{3})[\s-:]*([0-9]{2}[a-zA-Z]{1}|[0-9]{3})$
         */
        public static bool TryFormatRegNr(string regNumber, string regexPattern, out string formattedNumber)
        {
            formattedNumber = "";
            Regex regex = new Regex(regexPattern);
            Match match = regex.Match(regNumber);

            if (!match.Success)
            {
                return false;
            }

            for (int i = 1; i < match.Groups.Count; i++)
            {
                formattedNumber += match.Groups[i].Value.ToUpper();
                if (i + 1 < match.Groups.Count)
                {
                    formattedNumber += " ";
                }
            }

            return true;
        }

        /*
         * Skriver ut alla smakalternativ som finns tillgängligt         
        */
        public static void WriteFlavourOptions()
        {
            foreach (int value in Enum.GetValues<Flavours>())
            {
                if (value == 99)
                {
                    Console.BackgroundColor = (ConsoleColor)random.Next(0, Enum.GetNames(typeof(ConsoleColor)).Length);
                    Console.Write(" ");
                    Console.BackgroundColor = (ConsoleColor)random.Next(0, Enum.GetNames(typeof(ConsoleColor)).Length);
                    Console.Write(" ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($" {((Flavours)value).ToString()}");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = (ConsoleColor)value;
                    Console.Write("  ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($" {((Flavours)value).ToString()}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }

        /* 
         * Skriver ut alla färgalternativ som finns tillgängligt 
        */
        public static void WriteColorOptions()
        {
            foreach (int value in Enum.GetValues<Colors>())
            {
                Console.BackgroundColor = (ConsoleColor)value;
                Console.Write("  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($" {((Colors)value).ToString()}");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        /*  TryFormatLength
        *   För att använda denna behövs ett Regex-pattern som söker efter mm, cm, och dm
        *   Ett exempel som används i programmet är: ^([0-9]*[.,]?[0-9]+)\s*(mm|cm|dm|m)?$
        */
        public static bool TryFormatLength(string lengthInput, string regexPattern, out double length)
        {
            Regex regex = new Regex(regexPattern);
            length = -1;
            double factor = 1;
            Match match = regex.Match(lengthInput);

            if (!match.Success)
            {
                return false;
            }

            for (int i = match.Groups.Count - 1; i >= 0; i--)
            {
                switch (match.Groups[i].Value)
                {
                    case "mm":
                        factor = 0.1;
                        break;
                    case "dm":
                        factor = 10;
                        break;
                    case "m":
                        factor = 100;
                        break;
                }

                if (double.TryParse(match.Groups[i].Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double outLength))
                {
                    outLength *= factor;
                    length = Math.Round(2.0 * outLength) / 2.0;
                }
            }

            return true;
        }
    }
}
