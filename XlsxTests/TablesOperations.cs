using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlsxTests
{
    internal static class TablesOperations
    {
        private static List<string> RawsFromTable(string path)
        {
            List<string> lines = new List<string>();
            string textFromFile;

            using (var streamReader = new StreamReader(path))
            {
                textFromFile = streamReader.ReadToEnd();
                streamReader.Close();
            }

            string[] cellsArray = textFromFile.Split("\r\n");

            for (int i = 0; i < cellsArray.Length; i++)
            {
                lines.Add(cellsArray[i]);
            }

            return lines;

        }

        private static string[,] RawsAndColumnsFromTable(List<string> rawsList)
        {
            string[] countColumns = rawsList[0].Split(',');
            string[,] rawsAndColumns = new string[rawsList.Count, countColumns.Length];

            string[] columns;
            for (int raw = 0; raw < rawsList.Count; raw++)
            {
                columns = rawsList[raw].Split(',', 4);
                for (int column = 0; column < columns.Length; column++)
                {
                    rawsAndColumns[raw, column] = columns[column].Replace("\u0022", "");
                }
            }

            return rawsAndColumns;
        }

        private static string[,] GiveTable(string path)
        {
            return RawsAndColumnsFromTable(RawsFromTable(path));
        }

        private static void WriteTableWithSrtingArray(string[,] table)
        {
            for (int raw = 0; raw < table.GetLength(0); raw++)
            {
                Console.WriteLine($"\n--------Строка {raw}\n");
                for (int column = 0; column < table.GetLength(1); column++)
                {
                    Console.WriteLine($" Колонка #{column}: {table[raw, column]} ");
                }
                Console.WriteLine();
            }
        }

        public static void WriteTable(string path)
        {
            string[,] table = GiveTable(path);
            WriteTableWithSrtingArray(table);
        }
    }
}