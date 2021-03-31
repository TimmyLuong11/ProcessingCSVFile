using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ProcessingCSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializing Variables
            string[] lines = File.ReadAllLines("sales_data_sample.csv");
            Dictionary<string, List<double>> years = new Dictionary<string, List<double>>();
            Dictionary<string, List<double>> months = new Dictionary<string, List<double>>();
            double sum;
            string sale;

            //Going through the file each line and for each year total adding the total to their respective list
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

            //Calculating the sum for the years and outputting the results to the user
            foreach (string year in years.Keys)
            {
                List<double> total = years[year];
                sum = 0;
                for (int i = 0; i < total.Count; i++)
                {
                    sum += total[i];
                }
                Console.WriteLine($"The total sale for {year} was {sum.ToString("C")}.");
            }

            //Going through the file each line and for each month total adding the total to their respective list
            for (int i = 1; i < lines.Length; i++)
            {
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

            Console.WriteLine();
            //Calculating the sum for the each month for the year and outputting the results to the user
            foreach (var item in months.OrderBy(i => int.Parse(i.Key)))
            {
                List<double> result = months[item.Key];
                sum = 0;
                for (int a = 0; a < result.Count; a++)
                {
                    sum += result[a];
                }
                Console.WriteLine($"For {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(item.Key))} 2003/2004/2005 the total sale was {sum.ToString("C")}.");
            }   
        }
    }
}
