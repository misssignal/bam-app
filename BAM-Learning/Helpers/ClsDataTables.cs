using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BAM_Learning.Helpers
{
    internal class ClsDataTables
    {
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            dataTable.TableName = typeof(T).FullName;
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }


        public static IEnumerable<PropertyInfo> FlattenType(Type type)
        {
            var properties = type.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType.Assembly.GetName().Name == "mscorlib")
                {
                    yield return info;
                }
                else
                {
                    foreach (var childInfo in FlattenType(info.PropertyType))
                    {
                        yield return childInfo;
                    }
                }
            }
        }

        public DataSet GenerateDataSet(ClsBinaryFileConverter source)
        {
            return GenerateDataSet(new[] { source });
        }

        public DataSet GenerateDataSet(IEnumerable<ClsBinaryFileConverter> source)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            dt.Columns.Add("Name");
            dt.Columns.Add("Id", typeof(int));
            // other columns...
            foreach (ClsBinaryFileConverter c in source)
            {
                DataRow dr = dt.Rows.Add();
                //dr.SetField("Name", c.Name);
                //dr.SetField("Id", c.Id);
                // other properties
            }
            return ds;
        }



    }



public static class DataTableConverter
    {
        // Converts a list of objects to a DataTable
        public static DataTable ToDataTable<T>(List<T> items)
        {
            // Create an empty DataTable
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get the properties of T, and add each as a column in the DataTable
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Populate rows with the values from each item in the list
            foreach (var item in items)
            {
                var row = dataTable.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }

}
