using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1_OOP_Projekt_Kassasystem
{
    public class Receipt
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public DateOnly DateOnly { get; set; }

        public void readReceipt(DateOnly currentDate)
        {
            int maxId = 0;
            string file = File.ReadAllText($"../../../Files/Receipt-{currentDate}.txt");
            var matches = Regex.Matches(file, @"Kvitto ID: (\d+)");
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    int receiptId = int.Parse(match.Groups[1].Value);
                    if (receiptId > maxId)
                    {
                        maxId = receiptId;
                    }
                }
                Id = maxId + 1;
            }
            else
            {
                Id = 1;
            }
        }
        public void createReceipt(List<Product> products, float totalPrice, DateOnly currentDate, short amount)
        {
            TotalPrice = totalPrice;
            DateOnly = currentDate;

            List<string> receiptLines = new List<string>
            {
                $"Kvitto ID: {Id}",
                $"Datum: {currentDate}",
                $"Total pris: {totalPrice}",
                $"Antal: {amount}",
                "Products:"
            };
            foreach (var product in products)
            {
                receiptLines.Add($"- {product.Name}, Price: {product.Price}");
            }
            File.AppendAllLines($"../../../Files/Receipt-{currentDate}.txt", receiptLines);
        }
    }
}