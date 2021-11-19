using System;
using System.Globalization;
using StaticClass;

namespace ProductUtility
{
    class TofuUtility
    {
        const string regexPattern = @"^([0-9]*[.,]?[0-9]+)\s*(ml|cl|dl)?$";

        /* -------------------------------- MESSAGES -------------------------------- */
        string[] spiceMessage =
        {
                "Tofu är en populär färskostliknande produkt gjort på sojabönor, perfekt val för en vegan.\n",
                "Kom ihåg dock! Veganer kan man skämta om men aldrig om tufo, för det är bara smaklöst.\n",
                "Men smaklöst är det aldrig när du handlar hos Multifabriken AB!\n",
                "Speciellt inte med vårt unika utbud av kryddor.\n",
                "\n"
            };

        string[] quantityMessage =
        {
                "Ta för dig! Vi har tofu för en hel armé och säljer litervis!.\n",
                "\n"
            };
        string errorMsgSpice = "Du har angett en smak som inte finns tillgängligt!";
        string errorMsgAmount = "Du har angett en ogiltlig mängd";
        Random random = new Random();

        /* -------------------------- METHODS TO CREATE OBJECT ------------------------- */
        public double GetAmount()
        {
            bool isError = false;

            do
            {
                Console.Clear();
                quantityMessage.Write();

                if (isError)
                {
                    errorMsgAmount.WriteAsError();
                }

                string tempChosenLength = Message.GetInputFor("Ange en mängd: ");

                if (double.TryParse(tempChosenLength.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double chosenLength))
                {
                    if (chosenLength > 0)
                    {
                        return Math.Round(chosenLength, 1);
                    }
                }
                isError = true;
            } while (true);
        }
        public string GetSpice()
        {
            bool isError = false;
            do
            {
                Console.Clear();
                spiceMessage.Write();
                InHouse.TofuSpices.WriteAsOptions();

                if (isError)
                {
                    errorMsgSpice.WriteAsError();
                }

                string tempSpiceColor = Message.GetInputFor("Varsågod att välja en smak: ");

                if (tempSpiceColor.ToLower() == InHouse.TofuSpices[InHouse.TofuSpices.Count - 1].ToLower())
                {
                    string randomSpice = InHouse.TofuSpices[random.Next(0, InHouse.TofuSpices.Count - 1)];
                    return randomSpice;
                }
                else
                {
                    foreach (string spice in InHouse.TofuSpices)
                    {
                        if (tempSpiceColor.ToLower() == spice.ToLower())
                        {
                            return spice;
                        }
                    }
                }
                isError = true;
            } while (true);
        }
    }
}

