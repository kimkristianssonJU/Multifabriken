using System;
using NamespaceProduct;
using StaticClass;

namespace ConsoleProduct
{
    /*  Denna klass är till för att göra en visuell
     *  presentation av ett objekt av en produkt
     */
    class ConsoleCandy : Candy
    {
        // Regex-mönster för att färglägga godisbitar
        const string regexPattern = @"(?<default>.*[^o])(?<color>o.*)(?<color2>o.*)(?<color3>o.*\n?)|(?<default2>.*[^o])(?<color4>o.*)(?<color5>o.*\n?)|(?<default3>.*[^o])(?<color6>o.*\n?)|(?<default4>.*[^o]\n?)";
        Random random = new Random();
        public ConsoleCandy(Flavours flavour, int amount) : base(flavour, amount) { }

        // Används för att kategorisera i handelslistan (Session.shoppingCart) 
        public override string ProductType
        {
            get
            {
                return "Godis";
            }
        }

        public string ToAmountString()
        {
            return $"{amount} st";
        }

        // Skriver ut en visuell representation av objektet
        public override void PrintInformation()
        {
            string[] candyStringArray =
            {
                $@"   ",
                $@"  /\.--./\",
                $@"  \/'--'\/",
            };

            string[] infoStringArray =
            {
                $@"   ",
                $@"Smak: {this.flavour.ToString()}   ",
                $@"Antal: {this.ToAmountString()}   ",
            };

            infoStringArray = ConsolePresentation.PreparePresentation(infoStringArray);

            // Skriver ut och färglägger ASCII
            for (int i = 0; i < infoStringArray.Length; i++)
            {
                Console.Write(infoStringArray[i]);
                Console.ForegroundColor = (ConsoleColor)this.flavour.ToColor();
                Console.Write($"{candyStringArray[i]}\n");
                Console.ResetColor();
            }
        }

        // Skriver ut ASCII bild som föreställer en godispåse
        public void WriteAsciiCandy()
        {
            Console.Clear();
            string[] asciiStringArray = {
                "         o   oo      \n",
                "     o         o   o \n",
                "        ___o o   o   \n",
                "       /`._;o       o\n",
                "      |   /   o      \n",
                "      ;_  |          \n",
                "        `-'          \n",
                "\n"
            };
            RandomAsciiCandy.SetAsciiCandyPosition(asciiStringArray, this.amount);

            // Om "GottOchBlandat" har valts så slumpas en färg fram
            if ((int)this.flavour == 99)
            {
                asciiStringArray.PrintColorizedRandom(regexPattern);
            }
            else
            {
                asciiStringArray.PrintColorized((ConsoleColor)this.flavour, regexPattern);
            }
            Console.WriteLine($"Smak: {this.flavour}");
            Console.WriteLine($"Antal: {this.ToAmountString()}\n");
            Console.WriteLine("Glöm inte att bjuda en vän!\n");
        }
    }
}
