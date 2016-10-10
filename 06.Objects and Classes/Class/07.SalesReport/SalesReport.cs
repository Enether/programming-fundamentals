/*
 Write a class Sale holding the following data: town, product, price, quantity.
 Read a list of sales and calculate and print the total sales by town as shown in the output.
 Order alphabetically the towns in the output.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SalesReport
{
    class SalesReport
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[n];
            for (int i = 0; i < n; i++)
            {
                sales[i] = ReadSale();
            }
            
            // calculate the sum for each town
            SortedDictionary<string, double> townSum = new SortedDictionary<string, double>();
            foreach (var sale in sales)
            {
                string town = sale.Town;
                if (!townSum.ContainsKey(town))
                {
                    townSum[town] = sales.Where(x => x.Town == town).Sum(x => x.Price * x.Quantity);
                }
            }

            // print the results
            foreach (var town in townSum.Keys)
            {
                Console.WriteLine($"{town} -> {townSum[town]:F2}");
            }
        }

        static Sale ReadSale()
        {
            string[] saleInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string town = saleInfo[0];
            string product = saleInfo[1];
            double price = double.Parse(saleInfo[2]);
            double quantity = double.Parse(saleInfo[3]);

            return new Sale(town, product, price, quantity);
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public Sale(string town, string product, double price, double quantity)
        {
            this.Town = town;
            this.Product = product;
            this.Price = price;
            this.Quantity = quantity;
        }
    }

}
