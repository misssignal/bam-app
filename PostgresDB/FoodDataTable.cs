using PostgresDB.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace PostgresDB
{
    public static class DataTableHelper
    {
        public static async Task<DataTable> GetFoodDataTableAsync(MyDbContext dbContext)
        {
            var foodItems = await dbContext.sample_table_food.ToListAsync(); // Fetch data from DbContext

            // Create DataTable and add columns
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("ChannelName1", typeof(string));
            dataTable.Columns.Add("ChannelName2", typeof(string));
            dataTable.Columns.Add("ChannelName3", typeof(string));
            dataTable.Columns.Add("To", typeof(string));
            dataTable.Columns.Add("Pos", typeof(string));
            dataTable.Columns.Add("Ml", typeof(string));
            dataTable.Columns.Add("Fl1", typeof(string));
            dataTable.Columns.Add("Fl2", typeof(string));
            dataTable.Columns.Add("Fl3", typeof(string));
            dataTable.Columns.Add("Dim", typeof(string));
            dataTable.Columns.Add("Dir", typeof(string));
            dataTable.Columns.Add("Filt", typeof(string));
            // Populate DataTable
            foreach (var item in foodItems) 
            { 
                dataTable.Rows.Add(item.id, item.type, item.chnl_name_1, 
                    item.chnl_name_2, item.chnl_name_3, item.to, item.pos, 
                    item.ml, item.fl1, item.fl2, item.fl3, item.dim, item.dir, 
                    item.filt);
            } 
            return dataTable; 
        }
    }
}
