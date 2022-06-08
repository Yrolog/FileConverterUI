using System;

namespace XlsxTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @Console.ReadLine();
            string secondPath = @Console.ReadLine();
            NewTablesOperations.WriteDataTable(NewTablesOperations.GetTable(path), secondPath);



            //Console.WriteLine(RawTextFromTable(path));

        }
    }
}