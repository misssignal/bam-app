namespace BAM_Learning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog1.FileName;

                int fileContent = await ReadFileLineAsync(filename);

                MessageBox.Show(fileContent.ToString()); // Show the content in a MessageBox or display in a TextBox
            }
        }

        private async Task<string> ReadFileAsync(string filename)
        {
            char[] buffer;

            using (var sr = new StreamReader(filename))
            {
                buffer = new char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }

            return new string(buffer);
        }

        private async Task<int> ReadFileLineAsync(string filename)
        {
            try
            {
                int count = 0;
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (true)
                    {
                        string line = await reader.ReadLineAsync();
                        if (line == null)
                        {
                            break;
                        }
                        else
                        {
                            Array bla = line.Split(":");
                            Console.WriteLine(bla);
                        }
                        count++;
                    }
                }
                Console.WriteLine("At end of CountLinesAsync");
                return count;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return -1;
        }





        private void BtnBrowse2File_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    //ClsCHNFile.ReadAndDisplayFilesAsync(file);
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }
    }
}
