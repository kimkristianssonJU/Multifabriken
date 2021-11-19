using System;

namespace StaticClass
{
    static class ConsolePresentation
    {
        static Random random = new Random();
        public static string[] PreparePresentation(string[] stringArray)
        {
            // Tar emot ett heltal representerar längden på den längsta strängen i arrayen
            int longestStringIndex = GetLongestStringIndex(stringArray);
            // Adderar mellanrum " " till de övriga arrayen så att längden blir densamma på alla
            stringArray = PrepareStringArray(longestStringIndex, stringArray);
            return stringArray;
        }

        // Adderar mellanrum " " till de övriga arrayen så att längden blir densamma på alla
        public static string[] PrepareStringArray(int longestStringIndex, string[] stringArray)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                int lengthDiff = stringArray[longestStringIndex].Length - stringArray[i].Length;

                for (int j = 0; j < lengthDiff; j++)
                {
                    stringArray[i] += " ";
                }
            }

            return stringArray;
        }

        // Tar emot ett heltal representerar längden på den längsta strängen i arrayen
        public static int GetLongestStringIndex(string[] stringArray)
        {
            int longestStringIndex = 0;

            for (int i = 1; i < stringArray.Length; i++)
            {
                if (stringArray[i].Length > stringArray[longestStringIndex].Length)
                {
                    longestStringIndex = i;
                }
            }

            return longestStringIndex;
        }
    }
}
