using System;
using NamespaceProduct;

namespace StaticClass
{
    static class Message
    {
        public static string[] introductionMessage =
        {
            "Vi på Multifabriken AB hälsar eder välkommen..\n",
            "Ta en titt runt på fabriken genom att navigera dig med tangenterna 1-6\n",
            "\n"
        };
        static public void WriteLogo()
        {
            /* -------------------------------- MAIN MENU -------------------------------- */
            Console.Clear();
            string[] stringArray =
            {
                $@"                          __  . .* ,                                     {Environment.NewLine}",
                $@"                        ~#@#%/'.,$ @                                     {Environment.NewLine}",
                $@"                        .' ^ *;'*                                        {Environment.NewLine}",
                $@"                       ..                                                {Environment.NewLine}",
                $@"                      ;. :                                   . .         {Environment.NewLine}",
                $@"                      ;==:                     ,,   ,.@#(&*.;'           {Environment.NewLine}",
                $@"                      ;. :                   .;#$% & ^^&                 {Environment.NewLine}",
                $@"                      ;==:                   &  ......                   {Environment.NewLine}",
                $@"                      ;. :                   ,,;       :                 {Environment.NewLine}",
                $@"                      ;==:  ._______.       ;  ;       :                 {Environment.NewLine}",
                $@"                      ;. :  ;    ###:__.    ;  ;       :                 {Environment.NewLine}",
                $@"_____________________.'  `._;       :  :__.' .'         `._______________{Environment.NewLine}",
                $@"___  ___      _ _   _  __      _          _ _                 ___ ______ {Environment.NewLine}",
                $@"|  \/  |     | | | (_)/ _|    | |        (_| |               / _ \| ___ \{Environment.NewLine}",
                $@"| .  . |_   _| | |_ _| |_ __ _| |__  _ __ _| | _____ _ __   / /_\ | |_/ /{Environment.NewLine}",
                $@"| |\/| | | | | | __| |  _/ _` | '_ \| '__| | |/ / _ | '_ \  |  _  | ___ \{Environment.NewLine}",
                $@"| |  | | |_| | | |_| | || (_| | |_) | |  | |   |  __| | | | | | | | |_/ /{Environment.NewLine}",
                $@"\_|  |_/\__,_|_|\__|_|_| \__,_|_.__/|_|  |_|_|\_\___|_| |_| \_| |_\____/ {Environment.NewLine}",
                $@"                                                                         {Environment.NewLine}"
            };

            stringArray.WriteColorized(ConsoleColor.DarkGreen);
        }

        static public char GetMenuChoice()
        {
            string[] stringArray =
            {
                $"[1] Beställ bil                   {Environment.NewLine}",
                $"[2] Beställ godis                 {Environment.NewLine}",
                $"[3] Beställ snören                {Environment.NewLine}",
                $"[4] Beställ tofu                  {Environment.NewLine}",
                $"[5] Lista alla beställda produkter{Environment.NewLine}",
                $"[6] Avsluta                       {Environment.NewLine}",
                $"                                  {Environment.NewLine}",
                $"{Environment.NewLine}",
                "Välj: "
            };
            stringArray.Write();
            return Console.ReadKey().KeyChar;
        }


        /* --------------------------------- GENERAL -------------------------------- */
        static public string GetInputFor(string text)
        {
            Console.Write(text);
            string userInput = Console.ReadLine();
            Console.WriteLine();
            return userInput;
        }

        // Skriver ut en enkel sträng med färg
        public static void WriteAndColorize(string text, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.Write(text);
        }
    }
}