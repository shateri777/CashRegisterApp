using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace _1_OOP_Projekt_Kassasystem
{
    public class Program
    {

        public static void Main(string[] args)
        {
            List<Product> chosenProducts = new List<Product>();
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            //PRODUCTS:
            List<Product> Products = new List<Product>();
            Product product1 = new Product(1, "Banan", 9.99f, Units.Styck);
            Products.Add(product1);
            Product product2 = new Product(2, "Apelsin", 39.95f, Units.Kg);
            Products.Add(product2);
            Product product3 = new Product(3, "Karins Lasagne", 19.95f, Units.Styck);
            Products.Add(product3);
            Product product4 = new Product(4, "Äpple", 35.95f, Units.Kg);
            Products.Add(product4);
            Product product5 = new Product(5, "Snus", 42.95f, Units.Styck);
            Products.Add(product5);

            Console.Clear();
            Console.WriteLine("1. Ny Kund");
            Console.WriteLine("2. Adminverktyg");
            Console.WriteLine("3. Avsluta");
            int choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    Console.Clear();
                    foreach (Product p in Products)
                    {
                        Console.WriteLine($"{p.Id} {p.Name} {p.Price} {p.Unit}");
                    }
                    Console.WriteLine("Kommandon:");
                    Console.WriteLine("<produktid> <antal>");
                    Console.WriteLine("PAY");
                    string[] answers = new string[1];
                    answers = Console.ReadLine().Split(' ');
                    byte productid = Convert.ToByte(answers[0]);
                    short amount = Convert.ToInt16(answers[1]);
                    float endPrice = 0;
                    Console.Clear();
                    foreach (Product item in Products)
                    {
                        
                        if (productid == item.Id)
                        {
                            chosenProducts.Add(item);
                            endPrice += item.Price * amount;
                            Console.WriteLine($"Du valde: {item.Name}");
                            Console.WriteLine($"Enhet: {item.Unit}");
                            Console.WriteLine($"Antal: {amount}");
                            Console.WriteLine($"Slutpriset är: {endPrice}kr");
                        }
                    }
                    Console.WriteLine("\nOm du är nöjd med produkterna så skriver du 'PAY' i konsolen.");
                    Console.WriteLine("Annars skriv 'RETURN' för att gå tillbaka till startmenyn.");
                    string answer2 = Console.ReadLine().ToUpper();
                    if (answer2 == "PAY")
                    {
                        Console.Clear();
                        Console.WriteLine("Ditt kvitto skrivs ut...");
                        Thread.Sleep(3000);
                        Receipt receipt = new Receipt();
                        receipt.readReceipt(currentDate);
                        receipt.createReceipt(chosenProducts, endPrice, currentDate, amount);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("*RECEIPT HAS BEEN PRINTED*");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Main(args);
                    }
                    else if (answer2 == "RETURN")
                    {
                        Console.Clear();
                        Main(args);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Du skrev i fel format, återgår till startmenyn..");
                        Thread.Sleep(1000);
                        Main(args);
                    }
                    break;

                case 2:
                    break;


                case 3:
                    Console.Clear();
                    Console.WriteLine("Closing the program...");
                    break;
            }
        }
    }
}

