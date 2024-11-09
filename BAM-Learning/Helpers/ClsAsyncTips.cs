using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM_Learning.Helpers
{
    internal class ClsAsyncTips
    {

        // Method 1-- Parallel
        private void LoadFilesConcurrently(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.txt");

            // Using Parallel.ForEach to process files in parallel
            Parallel.ForEach(files, filePath =>
            {
                ProcessFile(filePath);
            });
        }

        private void ProcessFile(string filePath)
        {
            // Your logic to parse the key-value pairs from each file
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                // Parse and store the key-value pairs
            }
        }
        // Method 2- Async and Await
        private async Task LoadFilesAsync(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.txt");

            List<Task> tasks = new List<Task>();

            foreach (var filePath in files)
            {
                tasks.Add(ProcessFileAsync(filePath));
            }

            // Wait for all file processing tasks to complete
            await Task.WhenAll(tasks);
        }

        private async Task ProcessFileAsync(string filePath)
        {
            // Async file reading
            string[] lines = await File.ReadAllLinesAsync(filePath);

            foreach (string line in lines)
            {
                // Parse and store the key-value pairs
            }
        }

        // Method 3-- Threadpool and Background Worker

        private async void LoadFilesInBackground(string folderPath)
        {
            await Task.Run(() => LoadFilesConcurrently(folderPath));
        }


    }
}
