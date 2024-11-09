using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM_Learning.Helpers
{
    internal class ClsProcessLargeData
    {
        
        // Process in Chunks

        const int chunkSize = 1000; // Read/write 1000 rows at a time

        private void ProcessLargeFileInChunks(BinaryReader reader, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int rowsProcessed = 0;

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // Read a chunk of data
                    for (int i = 0; i < chunkSize && reader.BaseStream.Position < reader.BaseStream.Length; i++)
                    {
                        int channelData = reader.ReadInt32();
                        writer.WriteLine(channelData);
                        rowsProcessed++;
                    }

                    // Optionally, show progress
                    Console.WriteLine($"{rowsProcessed} rows processed.");
                }
            }
        }

        // Streamwriter

        public void streaming()
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var row in channelDataRows)
                {
                    writer.WriteLine(row);
                }
            }

        }

    }
}
