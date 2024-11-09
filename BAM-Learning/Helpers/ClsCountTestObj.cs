using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM_Learning.Helpers
{
    internal class ClsCountTestObj
    {
        // Get a count of the test objects
        private int CalculateTestObjects(List<string> mmeCodes)
        {
            HashSet<char> uniqueTestObjects = new HashSet<char>();

            foreach (var code in mmeCodes)
            {
                if (!string.IsNullOrEmpty(code))
                {
                    uniqueTestObjects.Add(code[0]); // First character of the MME code
                }
            }

            return uniqueTestObjects.Count;
        }

        // Block of text to represent test object for mme

        private void GenerateTestObjects(int numTestObjects, string mmeFilePath)
        {
            List<string> testObjectBlocks = new List<string>();

            for (int i = 0; i < numTestObjects; i++)
            {
                string testObjectBlock = $"Test Object {i + 1}:\nSome relevant data here\n...";
                testObjectBlocks.Add(testObjectBlock);
            }

            File.WriteAllLines(mmeFilePath, testObjectBlocks);
        }

        // Match test object index and update channel file

        private void UpdateChannelFiles(List<string> channelFiles, Dictionary<char, int> testObjectIndexMap)
        {
            foreach (var filePath in channelFiles)
            {
                string[] lines = File.ReadAllLines(filePath);
                string mmeCode = lines[1]; // Assuming the second line has the MME code

                char testObjectChar = mmeCode[0]; // First character of the MME code
                int testObjectIndex = testObjectIndexMap[testObjectChar]; // Get the corresponding test object index

                lines[0] = testObjectIndex.ToString(); // Replace the first line with the test object index
                File.WriteAllLines(filePath, lines);   // Write the updated file
            }
        }


    }
}
