using System;
using System.Collections.Generic;
using NamespaceProduct;
using StaticClass;
using ProductUtility;
using ConsoleProduct;

namespace multifabriken_kimkristianssonJU
{
    class Program
    {
        static Session currentSession = new Session();
        static void Main(string[] args)
        {

            do
            {
                Message.WriteLogo();
                Message.introductionMessage.Write();
                switch (Message.GetMenuChoice())
                {
                    case '1': // Car
                        CreateNewCar();
                        break;
                    case '2': // Candy
                        CreateNewCandy();
                        break;
                    case '3': // Twine
                        CreateNewTwine();
                        break;
                    case '4': // Tofu
                        CreateNewTofu();
                        break;
                    case '5': // List all
                        currentSession.PrintOutCart();
                        break;
                    case '6': // Quit
                        return;
                }
            } while (true);
        }
        /* ---------------------------- CREATE NEW METHODS ---------------------------- */

        /*  
         *  Skapar alla nya objekt!
         */

        // Skapar ny Car
        static void CreateNewCar()
        {
            CarUtility carUtility = new CarUtility();
            string carBrand = carUtility.GetCarBrand();
            Colors carColor = carUtility.GetCarColor();
            string carRegNr = carUtility.GetRegNumber();

            ConsoleCar newCarConsole = new ConsoleCar(carBrand, carColor, carRegNr);

            newCarConsole.WriteAsciiCar();
            currentSession.AddToCart(newCarConsole);

            Console.Write("[Tryck vad som helst för att gå till huvudmenyn...]");
            Console.ReadKey();
        }

        // Skapar ny Candy
        static void CreateNewCandy()
        {
            CandyUtility candyUtility = new CandyUtility();
            Flavours candyFlavour = candyUtility.GetFlavour();
            int candyAmount = candyUtility.GetAmount();

            ConsoleCandy newConsoleCandy = new ConsoleCandy(candyFlavour, candyAmount);
            newConsoleCandy.WriteAsciiCandy();

            currentSession.AddToCart(newConsoleCandy);

            Console.Write("[Tryck vad som helst för att gå till huvudmenyn...]");
            Console.ReadKey();
        }

        // Skapar ny Twine
        static void CreateNewTwine()
        {
            TwineUtility twineUtility = new TwineUtility();
            double twineLength = twineUtility.GetLength();
            Colors twineColor = twineUtility.GetColor();

            ConsoleTwine newConsoleTwine = new ConsoleTwine(twineLength, twineColor);

            newConsoleTwine.WiteAsciiTwine();
            currentSession.AddToCart(newConsoleTwine);

            Console.Write("[Tryck vad som helst för att gå till huvudmenyn...]");
            Console.ReadKey();
        }


        // Skapar ny Tofu
        static void CreateNewTofu()
        {
            TofuUtility tofuUtility = new TofuUtility();
            double tofuQuantity = tofuUtility.GetAmount();
            string tofuSpice = tofuUtility.GetSpice();

            ConsoleTofu newConsoleTofu = new ConsoleTofu(tofuQuantity, tofuSpice);

            newConsoleTofu.WriteAsciiTofu();
            currentSession.AddToCart(newConsoleTofu);

            Console.Write("[Tryck vad som helst för att gå till huvudmenyn...]");
            Console.ReadKey();
        }
    }
}
