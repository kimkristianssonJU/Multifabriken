using System;
using multifabriken_kimkristianssonJU;
using NamespaceProduct;
using StaticClass;

namespace ConsoleProduct
{
    class ConsoleTwine : Twine
    {
        public ConsoleTwine(double length, Colors color) : base(length, color) { }

        // Används för att kategorisera i handelslistan (Session.shoppingCart) 
        public override string ProductType
        {
            get
            {
                return "Snöre";
            }
        }
        public string ToLengthString()
        {
            return $"{length} cm";
        }
        // Skriver ut en visuell representation av objektet
        public override void PrintInformation()
        {
            string[] twineStringArray =
            {
                $@"   ",
                $@"    ,´",
                $@"  --'",
            };

            string[] infoStringArray =
            {
                $@"   ",
                $@"Längd: {this.ToLengthString()}   ",
                $@"Färg: {this.color.ToString()}   ",
            };

            infoStringArray = ConsolePresentation.PreparePresentation(infoStringArray);

            for (int i = 0; i < infoStringArray.Length; i++)
            {
                Console.Write(infoStringArray[i]);
                Console.ForegroundColor = (ConsoleColor)this.color;
                Console.Write($"{twineStringArray[i]}\n");
                Console.ResetColor();
            }
        }

        // Skriver ut ASCII bild som föreställer en snubbe med ett rep
        public void WiteAsciiTwine()
        {
            string[] stringArray =
            {
                $"               :                                  \n",
                $"               ;                                  \n",
                $"              :                                   \n",
                $"              ;                                   \n",
                $"             /                                    \n",
                $"           o/                                     \n",
                $"         ._/\\___,Längd: {this.ToLengthString()}  \n",
                $"             \\   Färg: {this.color}              \n",
                $"             /                                    \n",
                $"             `                                    \n",
                $"                                                  \n"
            };

            stringArray.PrintColorized((ConsoleColor)this.color, @"(?<color>\s*[:;]\s?)?(?<default>.*\n)");
        }
    }
}
