using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using CsvHelper;
using Newtonsoft.Json;

namespace ThirdPartyDemo
{
    class JSONCsvManipulation
    {
        public static void ImplementCsvToJson()
        {
            string importFilePath = @"C:\Users\Pranav V Jaguste\source\repos\ThirdPartyDemo\ThirdPartyDemo\Utility\Address.csv";
            string exportFilePath = @"C:\Users\Pranav V Jaguste\source\repos\ThirdPartyDemo\ThirdPartyDemo\Utility\JsonDetails.json";

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

                Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, record);
                }
            }
        }

        public static void ImplementJsonToCsv()
        {
            string importFilePath = @"C:\Users\Pranav V Jaguste\source\repos\ThirdPartyDemo\ThirdPartyDemo\Utility\JsonDetails.json";
            string exportFilePath = @"C:\Users\Pranav V Jaguste\source\repos\ThirdPartyDemo\ThirdPartyDemo\Utility\Address_new.csv";

            IList<AddressData> addressdata = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));
            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(addressdata);
            }
        }
    }
}
