using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Data;

namespace FileConverterUI
{
    internal static class NewTablesOperations
    {
        public static DataTable GetTable(string filePath)  //С помощью библиотеки получает DataTable из .csv файла
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);
                    return dt;
                }
            }
        }

        public static void WriteDataTable(DataTable table, string path)
        {
            foreach (DataColumn column in table.Columns)
            {
                table.Columns[column.ColumnName].ReadOnly = false;
            }

            int counter;
            foreach (DataRow row in table.Rows)
            {
                counter = 0;
                foreach(DataColumn column in table.Columns)
                {
                    counter++;
                    if(counter % 2 == 0)
                    {
                        row[column] = EncDecClass.DecodeString(EncDecClass.EncodeString(row[column].ToString()));  //В силу того, что программа умеет кодировать только в английский текст,
                                                                                                                   //то нужно сначала закодировать строку,(из-за того, что в таблице текст на русском)
                                                                                                                   //а потом декодировать ее в уже английский текст, который сможет читать игра
                    }  
                }
            }

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (DataRow row in table.Rows)
                {
                    for (var i = 0; i < table.Columns.Count; i++)
                    {
                        csv.WriteField(row[i]);
                    }
                    csv.NextRecord();
                }
            }
        }

            
    }


}
