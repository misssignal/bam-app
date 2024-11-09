using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAM_Learning.Helpers
{
    internal class ClsProgressBar
    {
        // Progress Bar
        private async Task ProcessFilesAsync(string[] files)
        {
            progressBar1.Maximum = files.Length;
            progressBar1.Value = 0;

            for (int i = 0; i < files.Length; i++)
            {
                // Process each file (replace with your actual processing code)
                ProcessFile(files[i]);

                // Update the progress bar
                progressBar1.Value = i + 1;

                // Optionally update a label to show progress
                labelProgress.Text = $"Processed {i + 1}/{files.Length} files";
            }

            MessageBox.Show("Processing Complete!");
        }

        private void ProcessFile(string filePath)
        {
            // Simulate file processing delay
            System.Threading.Thread.Sleep(100); // Remove this in real code
        }

        // Usage

        private async void btnStartProcessing_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("path_to_your_files");
            await ProcessFilesAsync(files); // Process files asynchronously
        }

        // Method 2- Separate Form

        public partial class LoadingForm : Form
        {
            public LoadingForm()
            {
                InitializeComponent();
            }

            public void UpdateProgress(int progress, string status)
            {
                progressBar1.Value = progress;
                labelStatus.Text = status;
            }
        }
        // Main form code

        private async Task ProcessFilesWithLoadingFormAsync(string[] files)
        {
            using (var loadingForm = new LoadingForm())
            {
                loadingForm.Show(); // Show the loading form

                for (int i = 0; i < files.Length; i++)
                {
                    // Process the file (your actual processing code)
                    ProcessFile(files[i]);

                    // Update progress on the loading form
                    loadingForm.UpdateProgress((i + 1) * 100 / files.Length, $"Processing file {i + 1}/{files.Length}");

                    await Task.Delay(100); // Simulate processing delay, remove in real code
                }

                loadingForm.Close(); // Close the loading form after processing
            }

            MessageBox.Show("All files processed!");
        }

        private async void btnStartProcessing_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles("path_to_your_files");
            await ProcessFilesWithLoadingFormAsync(files); // Process files with a loading form
        }

        // Method 3- Background Worker

        public void backgroundstuff()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            worker.DoWork += (s, ev) =>
            {
                string[] files = (string[])ev.Argument;
                for (int i = 0; i < files.Length; i++)
                {
                    // Process the file
                    ProcessFile(files[i]);

                    // Report progress
                    worker.ReportProgress((i + 1) * 100 / files.Length);
                }
            };

            worker.ProgressChanged += (s, ev) =>
            {
                // Update the progress bar
                progressBar1.Value = ev.ProgressPercentage;
                labelProgress.Text = $"Processed {ev.ProgressPercentage}%";
            };

            worker.RunWorkerCompleted += (s, ev) =>
            {
                MessageBox.Show("Processing Complete!");
            };

            worker.RunWorkerAsync(files);

        }


    }
}
