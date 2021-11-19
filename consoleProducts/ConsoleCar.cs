using System;
using multifabriken_kimkristianssonJU;
using NamespaceProduct;
using StaticClass;

namespace ConsoleProduct
{
    class ConsoleCar : Car
    {
        public ConsoleCar(string brand, Colors color, string regNumber) : base(brand, color, regNumber) { }
        // Används för att kategorisera i handelslistan (Session.shoppingCart) 
        public override string ProductType
        {
            get
            {
                return "Bil";
            }
        }

        // Skriver ut en visuell representation av objektet
        public override void PrintInformation()
        {
            string[] carStringArray =
            {
                $@"  ______     ",
                $@" /|_||_\`.__ ",
                $@"(   _    _ _\",
                $@"=`-(_)--(_)-'"
            };

            string[] infoStringArray =
            {
                $@"   ",
                $@"Märke: {this.brand}   ",
                $@"Färg: {this.color.ToString()}   ",
                $@"RegNr: {this.regNumber}   ",
            };

            infoStringArray = ConsolePresentation.PreparePresentation(infoStringArray);

            for (int i = 0; i < infoStringArray.Length; i++)
            {
                Console.Write(infoStringArray[i]);
                Console.ForegroundColor = (ConsoleColor)this.color;
                Console.Write($"{carStringArray[i]}\n");
                Console.ResetColor();
            }
        }

        // Skriver ut ASCII bild som föreställer en bil
        public void WriteAsciiCar()
        {
            Console.ForegroundColor = (ConsoleColor)this.color;
            Console.WriteLine(@"        __-------__");
            Console.WriteLine(@"      / _---------_ \");
            Console.WriteLine(@"     / /           \ \");
            Console.WriteLine(@"     | |           | |");
            Console.WriteLine(@"     |_|___________|_|");
            Console.WriteLine(@" /-\|                 |/-\");
            Console.Write(@"|");
            Message.WriteAndColorize(" _ ", ConsoleColor.Yellow);
            Message.WriteAndColorize(@"|\      ", (ConsoleColor)this.color);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(@$"({this.brand[0]})");
            Console.ResetColor();
            Console.ForegroundColor = (ConsoleColor)this.color;
            Message.WriteAndColorize(@"      /|", (ConsoleColor)this.color);
            Message.WriteAndColorize(@" _ ", ConsoleColor.Yellow);
            Message.WriteAndColorize($"|", (ConsoleColor)this.color);
            Console.ResetColor();
            Console.WriteLine($"   Märke: { this.brand}");
            Message.WriteAndColorize($"|", (ConsoleColor)this.color);
            Message.WriteAndColorize("(_)", ConsoleColor.Yellow);
            Message.WriteAndColorize(@"| \      !      / |", (ConsoleColor)this.color);
            Message.WriteAndColorize("(_)", ConsoleColor.Yellow);
            Message.WriteAndColorize($"|", (ConsoleColor)this.color);
            Console.ResetColor();
            Console.WriteLine($"   Färg: {this.color.ToString()}");
            Message.WriteAndColorize(@$"|___|__\_____!_____/__|___|", (ConsoleColor)this.color);
            Console.ResetColor();
            Console.WriteLine($"   RegNr: {this.regNumber}");
            Message.WriteAndColorize($@"[________|", (ConsoleColor)this.color);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(this.regNumber);
            Console.ResetColor();
            Console.ForegroundColor = (ConsoleColor)this.color;
            Console.WriteLine(@$"|________]");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@" ||||    ~~~~~~~~     ||||");
            Console.WriteLine(@" `--'                 `--'");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Grattis till din nya bil!");
            Console.WriteLine();
        }
    }
}
