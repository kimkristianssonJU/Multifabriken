using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StaticClass;

namespace StaticClass
{
    static class RandomAsciiCandy
    {
        private static Random random = new Random();

        /* ------------------------ RANDOM "GENERATING" CANDY ----------------------- */

        // Placerar ut godisar på slumpvalda ställen
        public static string[] SetAsciiCandyPosition(string[] stringArray, int candyAmount)
        {
            Regex regexWord = new Regex($"(o)+.*(o)+.*(o)+|(o)+.*(o)+|o");
            List<Match> matches = new List<Match>();
            int count = 12 - candyAmount;

            foreach (string str in stringArray)
            {
                matches.Add(regexWord.Match(str));
            }

            List<List<Group>> groupList2D = GetGroup2DList(matches, "o");
            List<int> availableIndexList = groupList2D.GetIndexOfLists();
            List<List<int>> indexList2D = GetCandyPositionList(availableIndexList, groupList2D, count);

            foreach (List<int> indexList in indexList2D)
            {
                stringArray[indexList[0]] = stringArray[indexList[0]].ReplaceAt(indexList[1], 1, " ");
            }

            return stringArray;
        }

        // Hämtar en tvådimensionell lista på de positioner som är möjliga för en godis att ligga på
        static List<List<int>> GetCandyPositionList(List<int> availableIndexList, List<List<Group>> groupList2D, int count)
        {
            List<List<int>> indexList2D = new List<List<int>>();

            while (count > 0)
            {
                List<int> randomIndexList = new List<int>();

                int randomIndex = random.Next(0, availableIndexList.Count);
                int randomLineIndex = availableIndexList[randomIndex];
                randomIndexList.Add(randomLineIndex);

                Group randomGroup = groupList2D[randomLineIndex][random.Next(0, groupList2D[randomLineIndex].Count)];
                randomIndexList.Add(randomGroup.Index);

                indexList2D.Add(randomIndexList);

                groupList2D[randomLineIndex].Remove(randomGroup);
                if (groupList2D[randomLineIndex].Count == 0)
                {
                    availableIndexList.RemoveAt(randomIndex);
                }

                count--;
            }

            return indexList2D;
        }

        // Returnerar en lista på grupper som matchat med regex-mönstret
        static List<List<Group>> GetGroup2DList(List<Match> matches, string textToRemove)
        {
            List<List<Group>> groupList2D = new List<List<Group>>();

            for (int i = 0; i < matches.Count; i++)
            {
                List<Group> tempGroupList = new List<Group>();
                foreach (Group group in matches[i].Groups)
                {
                    if (group.Value == textToRemove)
                    {
                        tempGroupList.Add(group);
                    }
                }
                if (tempGroupList.Count > 0)
                {
                    groupList2D.Add(tempGroupList);
                }
            }

            return groupList2D;
        }
    }
}