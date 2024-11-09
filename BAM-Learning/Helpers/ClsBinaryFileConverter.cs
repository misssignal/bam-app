using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM_Learning.Helpers
{
    internal class ClsBinaryFileConverter
    {
        using System;
using System.IO;
using System.Text;

public class BinaryFileConverter
    {
        public void ConvertBinaryFile(string binaryFilePath, string outputFolderPath)
        {
            using (FileStream fs = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.Unicode))
            {
                // Step 1: Read the first 240 Unicode characters (each character is 2 bytes in UTF-16)
                char[] header = reader.ReadChars(240);

                // Convert to string if needed
                string headerString = new string(header);
                Console.WriteLine("Header (first 240 characters): " + headerString);

                // Step 2: Read the channel data blocks (assuming Int32 blocks after the first 240 characters)
                // Keep track of channels, starting right after the 240 characters
                int channelIndex = 0;

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int channelData = reader.ReadInt32();

                    // Process each channel block
                    string channelFileName = Path.Combine(outputFolderPath, $"channel_{channelIndex}.txt");
                    File.WriteAllText(channelFileName, $"Channel {channelIndex} data: {channelData}");

                    Console.WriteLine($"Channel {channelIndex} data: {channelData}");
                    channelIndex++;
                }

                // Step 3: Create CHN file as a table of contents
                string chnFilePath = Path.Combine(outputFolderPath, "channels.chn");
                File.WriteAllText(chnFilePath, GenerateCHNContent(channelIndex));
            }
        }

        private string GenerateCHNContent(int totalChannels)
        {
            StringBuilder chnContent = new StringBuilder();
            chnContent.AppendLine("CHN File - Table of Contents");
            chnContent.AppendLine($"Total Channels: {totalChannels}");

            for (int i = 0; i < totalChannels; i++)
            {
                chnContent.AppendLine($"Channel {i}: channel_{i}.txt");
            }

            return chnContent.ToString();
        }
    }

}
}
