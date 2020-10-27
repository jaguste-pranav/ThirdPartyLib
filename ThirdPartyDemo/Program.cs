using System;

namespace ThirdPartyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CSVHandler.ImplementCSVDataHandling();
            JSONCsvManipulation.ImplementCsvToJson();
            JSONCsvManipulation.ImplementJsonToCsv();
        }
    }
}
