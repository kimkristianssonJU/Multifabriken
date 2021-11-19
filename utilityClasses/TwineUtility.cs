using System;
using StaticClass;

namespace ProductUtility
{
    class TwineUtility
    {
        const string regexPatternLength = @"^([0-9]*[.,]?[0-9]+)\s*(mm|cm|dm|m)?$";
        const string regexPatternLengthInfo = @"(?<default2>.*\n?)(?<color>10cm\n?)(?<default3>.*\n?)|(?<default>.*\n?)";
        public string[] lengthInfoMsg =
        {
            "Hur långt är ett snöre?\n",
            "Detta är en filosofisk fråga som vi på Multifabriken AB har ett väldigt ostigt svar på:\n",
            "Kunden bestämmer... så länge snöret är 10cm eller längre!\n",
            "\n",
            "Ange gärna snörets längd i mm, cm ,dm eller m. T.ex: 10.3 dm\n",
            "Längden kommer automatiskt att omvandlas till centimeter: 103 cm.\n",
            "Om ingen enhet har angetts så används vår standard, som är centimeter\n",
            "\n"
        };
        public string[] colorMessage =
        {
            "-\"Om man stryper en smurf, vad får han för ansiktsfärg då?\"\n",
            "Detta är en av många frågor vi får här på Multifabriken AB.\n",
            "Anledningen, tror vi, är att de flesta vet att vi kan allt om färg.\n",
            "\n"
        };
        string errorLengthMsg = "Du har angett en längd som inte är tillåten!";
        string errorColorMsg = "Du har angett en färg som inte finns tillgängligt!";

        public double GetLength()
        {
            bool isError = false;

            do
            {
                Console.Clear();
                lengthInfoMsg.PrintColorized(ConsoleColor.Green, regexPatternLengthInfo);

                if (isError)
                {
                    errorLengthMsg.WriteAsError();
                }

                string tempChosenLength = Message.GetInputFor("Välj en längd: ");

                if (Utility.TryFormatLength(tempChosenLength, regexPatternLength, out double chosenLength))
                {
                    if (chosenLength >= 10)
                    {
                        return chosenLength;
                    }
                }
                isError = true;
            } while (true);
        }
        public Colors GetColor()
        {
            bool isError = false;
            do
            {
                Console.Clear();
                colorMessage.Write();
                Utility.WriteColorOptions();

                if (isError)
                {
                    errorColorMsg.WriteAsError();
                }

                string tempChosenColor = Message.GetInputFor("Varsågod att välja en färg på ditt snöre: ");

                if (Enum.TryParse(tempChosenColor, true, out Colors colorValue))
                {
                    Console.Clear();
                    return colorValue;
                }
                isError = true;
            } while (true);
        }
    }
}
