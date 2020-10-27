using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyDemo
{
    public class CSVHandler
    {
        
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\Pranav V Jaguste\source\repos\ThirdPartyDemo\ThirdPartyDemo\Utility\Address.csv";
            string exportFilePath = @"C:\Users\Pranav V Jaguste\source\repos\ThirdPartyDemo\ThirdPartyDemo\Utility\export.csv";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data reading done successfully. from Address.csv file");

                foreach (AddressData addressData in record)
                {
                    Console.Write("\t" + addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.Write("\n");
                }

                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(record);
                }
            }

            
        }
    }
}
