using System.Text.RegularExpressions;
using _1_OOP_Projekt_Kassasystem.ProductManagement;
namespace _1_OOP_Projekt_Kassasystem.Transactions
{
    public class Receipt
    {
        public int Id { get; set; }
        public void ReadReceipt(DateOnly currentDate)
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
        public void CreateReceipt(List<SelectedProduct> products, float totalPrice, DateOnly currentDate)
        {
            List<string> receiptLines = new List<string>
            {
                $"Kvitto ID: {Id}",
                $"Datum: {currentDate}",
                $"Total pris: {totalPrice}",
                "Products:"
            };
            foreach (var selectedProduct in products)
            {
                float productTotalPrice = selectedProduct.Product.Price * selectedProduct.Amount;
                totalPrice += productTotalPrice;
                receiptLines.Add($"- {selectedProduct.Product.Name}, Price: {selectedProduct.Product.Price}, Amount: {selectedProduct.Amount}");
            }
            foreach (var lines in receiptLines)
            {
                Console.WriteLine(lines);
            }
            File.AppendAllLines($"../../../Receipts/Receipt-{currentDate}.txt", receiptLines);
        }
    }
}