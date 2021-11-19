using System;
using NamespaceProduct;
using StaticClass;

namespace ProductUtility
{
    class CarUtility
    {
        string regexPattern = @"(?<color>\[\w+\s\d+\])(?<default>.*)(?<color2>\[\w+\s\d+\w?\])(?<default2>.?\n?)";
        string regexCarNrPattern = @"^([a-zA-Z]{3})[\s-:]*([0-9]{2}[a-zA-Z]{1}|[0-9]{3})$";
        string[] carBrandMessage =
        {
            "Multifabriken AB har ett unikt utbud av bilar\n",
            "Vi på Multifabriken värnar om lokala produkter.\n",
            "Därför känns det extra roligt att erbjuda dig en bil bland våra Svenska bilmärken:\n",
            "\n"
        };

        string[] regNrInfoMessage =
        {
            "2019 införde Sverige nya registreringsskyltar.\n",
            "Vi på Multifabriken tillåter dig att välja både bland de gamla\n",
            "[ABC 123] samt de nya [ABC 12X].\n",
            "Alla bokstäver mellan A-Z och a-z är tillåtet.\n",
            "\n",
            "Du får alltså möjligheten att välja mellan 51 miljoner olika kombinationer!\n",
            "\n"
        };
        string[] colorMessage =
        {
            "-\"Om man stryper en smurf, vad får han för ansiktsfärg då?\"\n",
            "Detta är en av många frågor vi får här på Multifabriken AB.\n",
            "Anledningen, tror vi, är att de flesta vet att vi kan allt om färg.\n",
            "\n"
        };
        string errorMsgCarBrand = "Du har angett ett märke som inte finns tillgängligt!";
        string errorMsgCarColor = "Du har angett en färg som inte finns tillgängligt!";
        string errorMsgCarRegNr = "Du har angett ett nummer som inte är tillåtet!";

        /* -------------------------- METHODS TO CREATE OBJECT ------------------------- */
        public string GetCarBrand()
        {
            bool isError = false;

            do
            {
                Console.Clear();
                carBrandMessage.Write();

                InHouse.CarBrands.WriteAsOptions();

                if (isError)
                {
                    errorMsgCarBrand.WriteAsError();
                }

                string tempChosenBrand = Message.GetInputFor("Välj ett märke: ");

                foreach (string brand in InHouse.CarBrands)
                {
                    if (tempChosenBrand.ToLower() == brand.ToLower())
                    {
                        Console.Clear();
                        return brand;
                    }
                }

                isError = true;
            } while (true);
        }
        public Colors GetCarColor()
        {
            bool isError = false;
            do
            {
                Console.Clear();
                colorMessage.Write();
                Utility.WriteColorOptions();

                if (isError)
                {
                    errorMsgCarColor.WriteAsError();
                }

                string tempChosenColor = Message.GetInputFor("Varsågod att välja en färg på din bil: ");

                if (Enum.TryParse(tempChosenColor, true, out Colors colorValue))
                {
                    Console.Clear();
                    return colorValue;
                }
                isError = true;
            } while (true);
        }
        public string GetRegNumber()
        {
            bool isError = false;
            do
            {
                Console.Clear();
                regNrInfoMessage.PrintColorized(ConsoleColor.Green, regexPattern);

                if (isError)
                {
                    errorMsgCarRegNr.WriteAsError();
                }

                string tempChosenRegNumber = Message.GetInputFor("Ange bilens registreringsnummer: ");

                if (Utility.TryFormatRegNr(tempChosenRegNumber, regexCarNrPattern, out string chosenRegNumber))
                {
                    Console.Clear();
                    return chosenRegNumber;
                }

                isError = true;
            } while (true);
        }

    }
}
