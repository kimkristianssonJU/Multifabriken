using System;
using StaticClass;

namespace ProductUtility
{
    class CandyUtility
    {
        string[] flavourMessage =
        {
            "Sockerfritt godis är som alkoholfritt vin,\n",
            "det finns ingen mening att bruka det.\n",
            "\n"
        };

        string[] amountMessage =
        {
            "Godis innehåller väldigt få vitaminer.\n",
            "Det är därför man måste äta så mycket!\n",
            "Så se till att plocka på dig!\n",
            "(Vi säljer styckvis)\n",
            "\n"
        };
        string errorMsgTaste = "Du har angett en smak som inte finns tillgängligt!";
        string errorMsgAmount = "Du har angett en ogiltlig mängd";
        Random random = new Random();
        /* -------------------------- METHODS TO CREATE OBJECT ------------------------- */

        // Returnerar det antal godisar som användaren har angett
        public int GetAmount()
        {
            bool isError = false;

            do
            {
                Console.Clear();
                amountMessage.Write();

                if (isError)
                {
                    errorMsgAmount.WriteAsError();
                }

                string tempChosenLength = Message.GetInputFor("Välj ett antal: ");

                if (int.TryParse(tempChosenLength, out int chosenAmount))
                {
                    if (chosenAmount >= 1)
                    {
                        return chosenAmount;
                    }
                }
                isError = true;
            } while (true);
        }

        // Returnerar smaken som användaren har angett
        public Flavours GetFlavour()
        {
            bool isError = false;
            do
            {
                Console.Clear();
                flavourMessage.Write();
                Utility.WriteFlavourOptions();


                if (isError)
                {
                    errorMsgTaste.WriteAsError();
                }

                string tempFlavourColor = Message.GetInputFor("Varsågod att välja en smak: ");

                if (Enum.TryParse(tempFlavourColor, true, out Flavours flavourValue))
                {
                    Console.Clear();
                    return flavourValue;
                }
                isError = true;
            } while (true);
        }
    }
}
