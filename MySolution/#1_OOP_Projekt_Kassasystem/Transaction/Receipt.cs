using System.Text.RegularExpressions;
using _1_OOP_Projekt_Kassasystem.ProductManagement;
namespace _1_OOP_Projekt_Kassasystem.Transactions
{
    public class Receipt
    {
        public int Id { get; set; }
        public void readReceipt(DateOnly currentDate)
        {
            int maxId = 0;
            string filePath = $"../../../Receipts/Receipt-{currentDate}.txt";
            try
            {
                string file = File.ReadAllText(filePath);
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
            catch
            {
                using FileStream fs = File.Create($"../../../Receipts/Receipt-{currentDate}.txt");
                Id = 1;
            }
        }
        public void createReceipt(List<Product> products, float totalPrice, DateOnly currentDate, byte amount)
        {
            foreach (Product product1 in products)
            {
                totalPrice = product1.Price * amount;
            }
            List<string> receiptLines = new List<string>
            {
                $"Kvitto ID: {Id}",
                $"Datum: {currentDate}",
                $"Total pris: {totalPrice}",
                $"Antal: {amount}",
                "Products:"
            };
            foreach (Product product in products)
            {
                receiptLines.Add($"- {product.Name}, Price: {product.Price}");
            }
            File.AppendAllLines($"../../../Receipts/Receipt-{currentDate}.txt", receiptLines);
        }
    }
}