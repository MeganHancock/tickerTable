using System;
using System.IO;
using Newtonsoft.Json;

namespace tickerTable
{
    class Program
    {
        public class Company
        {
            public string Name { get; set; }
            public string Ticker { get; set; }
            public double StockPrice { get; set; }
            public double ChangeValue { get; set; }
        }

        class FileData
        {
            public List<Company> companies { get; set; } = new List<Company>();
        }


        static void Main(string[] args)
        {
            try
            {
                string jsonCompanyData = File.ReadAllText(@"C:\Users\mgnhn\Source\Projects\Interview_Assignment\tickerTable\companyData.json");

                if (String.IsNullOrEmpty(jsonCompanyData))
                {
                    return;
                }

                FileData file = JsonConvert.DeserializeObject<FileData>(jsonCompanyData);

                if (file == null)
                {
                    return;
                }

                string html = "<table style=\"border: 1px solid black; width: 50%\"><tr><th>Company</th><th>Ticker</th><th>Price</th><th>Delta</th>";
                foreach (Company company in file.companies)
                {
                    html += "<tr><td>" + company.Name + "</td><td>" + company.Ticker + "</td><td>" + company.StockPrice + "</td><td>" + company.ChangeValue + "</td>";
                }
                File.WriteAllText(@"C:\Users\mgnhn\Source\Projects\Interview_Assignment\tickerTable\companies.html", html);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file", e.Message);
            }




        }
    }
}
