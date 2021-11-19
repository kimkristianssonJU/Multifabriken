using System;
using multifabriken_kimkristianssonJU;
using NamespaceProduct;
using StaticClass;

namespace ConsoleProduct
{
    class ConsoleTofu : Tofu
    {
        public ConsoleTofu(double quantity, string seasoning) : base(quantity, seasoning) { }
        // Används för att kategorisera i handelslistan (Session.shoppingCart) 
        public override string ProductType
        {
            get
            {
                return "Tofu";
            }
        }
        public string ToQuantityString()
        {
            return $"{quantity} liter";
        }
        // Skriver ut en visuell representation av objektet
        public override void PrintInformation()
        {
            string[] tofuStringArray =
            {
                $@"   ",
                $@"   _",
                $@"  |_|",
            };

            string[] infoStringArray =
            {
                $@"   ",
                $@"Mängd: {this.ToQuantityString()}   ",
                $@"Krydda: {this.seasoning}   ",
            };

            infoStringArray = ConsolePresentation.PreparePresentation(infoStringArray);

            for (int i = 0; i < infoStringArray.Length; i++)
            {
                Console.Write(infoStringArray[i]);
                Console.Write($"{tofuStringArray[i]}\n");
            }
        }
        // Skriver ut ASCII bild som föreställer en Tofu
        public void WriteAsciiTofu()
        {
            Console.Clear();
            string[] tofuAscii =
            {
                @$"        ________________                                         {Environment.NewLine}",
                @$"       /   o           /|                                        {Environment.NewLine}",
                @$"      /_______________/o|   Mängd: {this.ToQuantityString()}     {Environment.NewLine}",
                @$"     | o              | |   Krydda: {this.seasoning}             {Environment.NewLine}",
                @$"     |             o  | /                                        {Environment.NewLine}",
                @$"     |________________|/                                         {Environment.NewLine}",
                @$"                                                                 {Environment.NewLine}"
            };

            tofuAscii.Write();
        }
    }
}
