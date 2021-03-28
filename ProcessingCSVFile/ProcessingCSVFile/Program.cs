using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ProcessingCSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("sales_data_sample.csv");
            Dictionary<string, List<double>> years = new Dictionary<string, List<double>>();
            Dictionary<string, List<double>> months = new Dictionary<string, List<double>>();
            double total, sum;
            string sale;

            
            years.Add("2003", new List<double>());
            years.Add("2004", new List<double>());
            years.Add("2005", new List<double>());
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] pieces = line.Split(',');
                if (pieces[6] == "Shipped" && pieces[9] == "2003")
                {
                    sale = pieces[4];
                    years["2003"].Add(Convert.ToDouble(sale));
                }
                else if (pieces[6] == "Shipped" && pieces[9] == "2004")
                {
                    sale = pieces[4];
                    years["2004"].Add(Convert.ToDouble(sale));
                }
                else if (pieces[6] == "Shipped" && pieces[9] == "2005")
                {
                    sale = pieces[4];
                    years["2005"].Add(Convert.ToDouble(sale));
                }
            }

            foreach (string year in years.Keys)
            {
                List<double> sa = years[year];
                sum = 0;
                for (int i = 0; i < sa.Count; i++)
                {
                    sum += sa[i];
                }
                Console.WriteLine($"The total sale for {year} was {sum.ToString("C")}.");
            }
            
            
            for (int i = 1; i < lines.Length; i++)
            {
                List<double> test = new List<double>();
                string line = lines[i];
                string[] pieces = line.Split(',');
                if (pieces[6] == "Shipped")
                {
                    sale = pieces[4];
                    if(months.ContainsKey(pieces[8]))
                    {
                        months[pieces[8]].Add(Convert.ToDouble(sale));
                    }
                    else
                    {
                        months.Add(pieces[8], new List<double>());
                        months[pieces[8]].Add(Convert.ToDouble(sale));
                    }
                }
            }

            foreach (string month in months.Keys)
            {
                List<double> tot = months[month];
                total = 0;
                for (int a = 0; a < tot.Count; a++)
                {
                    total += tot[a];
                }
                Console.WriteLine($"For {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(month))} 2003/2004/2005 the total sale was {total.ToString("C")}.");
            }
        }
    }
}
