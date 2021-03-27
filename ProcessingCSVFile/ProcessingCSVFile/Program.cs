using System;
using System.Collections.Generic;
using System.IO;

namespace ProcessingCSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("sales_data_sample.csv");
            Dictionary<string, List<double>> data = new Dictionary<string, List<double>>();
            double sum;

            data.Add("2003", new List<double>());
            data.Add("2004", new List<double>());
            data.Add("2005", new List<double>());
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] pieces = line.Split(',');
                string sale;
                if (pieces[6] == "Shipped" && pieces[9] == "2003")
                {
                    sale = pieces[4];
                    data["2003"].Add(Convert.ToDouble(sale));
                }
                else if (pieces[6] == "Shipped" && pieces[9] == "2004")
                {
                    sale = pieces[4];
                    data["2004"].Add(Convert.ToDouble(sale));
                }
                else if (pieces[6] == "Shipped" && pieces[9] == "2005")
                {
                    sale = pieces[4];
                    data["2005"].Add(Convert.ToDouble(sale));
                }
            }

            foreach (string year in data.Keys)
            {
                List<double> sa = data[year];
                sum = 0;
                for (int i = 0; i < sa.Count; i++)
                {
                    sum += sa[i];
                }
                Console.WriteLine($"{year} {sum.ToString("C")}");
            } 
        }
    }
}
