using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAM_Learning
{
    public abstract class BaseCsvForm : Form
    {
        protected DataGridView dataGridView;

        public BaseCsvForm()
        {
            InitializeComponent();
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                // other common properties
            };
            this.Controls.Add(dataGridView);
        }

        // Abstract method to be implemented by child forms to load data
        protected abstract void LoadCsvData();
    }

    public class CsvForm1 : BaseCsvForm
    {
        protected override void LoadCsvData()
        {
            // Your logic to load data from CSV 1 and populate the DataGridView
            List<Channel> csvData = LoadCsv1();  // Assuming you have a method for loading CSV 1
            dataGridView.DataSource = csvData;
        }
    }

    public class CsvForm2 : BaseCsvForm
    {
        protected override void LoadCsvData()
        {
            // Your logic to load data from CSV 2 and populate the DataGridView
            List<Channel> csvData = LoadCsv2();  // Assuming you have a method for loading CSV 2
            dataGridView.DataSource = csvData;
        }
    }

    /*
     * // Rename columns
        dataGridView.Columns["Name"].HeaderText = "Channel Name";
        dataGridView.Columns["Measurement"].HeaderText = "Measurement Type";

        // Hide a column if needed
        dataGridView.Columns["Units"].Visible = false;

        // Assuming 'channels' is your list of channel classes
        dataGridView.DataSource = channels;

        // Optionally adjust columns
        dataGridView.Columns["Location"].HeaderText = "Channel Location";
        dataGridView.Columns["Units"].Visible = false;  // If you want to hide this column
     * 
     * */


// Modifying and writing back to the class

/*
 private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
{
if (e.RowIndex >= 0)
{
    // Assuming you are binding a list of Channel objects to the DataGridView
    Channel channel = (Channel)dataGridView.Rows[e.RowIndex].DataBoundItem;

    if (e.ColumnIndex == dataGridView.Columns["Name"].Index)
    {
        // Example: Update the Measurement property when the Name is changed
        string newName = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
        channel.Measurement = "Updated based on " + newName;

        // Update the DataGridView to reflect the change
        dataGridView.Rows[e.RowIndex].Cells["Measurement"].Value = channel.Measurement;
    }
}
}
*/

// Changing the color of the DGV for duplicates

    /*
    private void HighlightDuplicates(string columnName)
    {
    Dictionary<string, List<int>> valueOccurrences = new Dictionary<string, List<int>>();

    // Iterate over rows and track occurrences of each value
    foreach (DataGridViewRow row in dataGridView.Rows)
    {
        if (row.Cells[columnName].Value != null)
        {
            string value = row.Cells[columnName].Value.ToString();

            if (valueOccurrences.ContainsKey(value))
            {
                // If already exists, mark all occurrences as duplicate
                valueOccurrences[value].Add(row.Index);
            }
            else
            {
                // Add new value to the dictionary
                valueOccurrences[value] = new List<int> { row.Index };
            }
        }
    }

    // Highlight duplicates (if there's more than one occurrence)
    foreach (var entry in valueOccurrences)
    {
        if (entry.Value.Count > 1)
        {
            foreach (int rowIndex in entry.Value)
            {
                dataGridView.Rows[rowIndex].Cells[columnName].Style.BackColor = Color.Yellow;
            }
        }
    }
    }
    */





}
