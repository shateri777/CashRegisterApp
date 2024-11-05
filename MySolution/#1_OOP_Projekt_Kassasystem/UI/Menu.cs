using _1_OOP_Projekt_Kassasystem.ProductManagement;
using _1_OOP_Projekt_Kassasystem.Transactions;
using System.Reflection;
using System.Threading.Channels;

namespace _1_OOP_Projekt_Kassasystem.UI
{
    internal class Menu
    {
        public void DisplayMenu()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            ProductManager productManager = new ProductManager();
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("Kassasystem");
                    Console.WriteLine("1. Ny Kund");
                    Console.WriteLine("2. Avsluta");
                    byte mainMenuChoice = Convert.ToByte(Console.ReadLine());
                    float totalPrice = 0;
                    ushort amount = 0;
                    switch (mainMenuChoice)
                    {
                        case 1:
                            List<SelectedProduct> chosenProducts = new List<SelectedProduct>();
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Produkter:");
                                productManager.DisplayProducts();
                                Console.WriteLine("Kommandon:");
                                Console.WriteLine("<produktid> <antal>");
                                Console.WriteLine("PAY");
                                string[] userInputForProductChoice = new string[1];
                                userInputForProductChoice = Console.ReadLine().Split(' ');
                                string productId = userInputForProductChoice[0].ToUpper();
                                if (productId == "PAY")
                                {
                                    if (chosenProducts.Count > 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ditt kvitto skrivs ut...");
                                        Thread.Sleep(3000);
                                        Receipt receipt = new Receipt();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("*RECEIPT HAS BEEN PRINTED*");
                                        Console.ResetColor();
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        receipt.ReadReceipt(currentDate);
                                        receipt.CreateReceipt(chosenProducts, totalPrice, currentDate);
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nTryck på valfri knapp för att återgå till huvudmenyn...");
                                        Console.ReadKey();
                                        Console.ResetColor();
                                        DisplayMenu();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Din varukorg var tom, försök igen...");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nTryck på valfri knapp för att återgå till produkterna...");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                }
                                else if (productId == "1" || 
                                    productId == "2" || 
                                    productId == "3" || 
                                    productId == "4" ||
                                    productId == "5")
                                {
                                    amount = Convert.ToUInt16(userInputForProductChoice[1]);
                                    if (amount == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(@"Du får inte välja ""0"" som antal, försök igen.");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn...");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        DisplayMenu();
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Kom ihåg kommandon: <produktid> <antal>");
                                    Console.WriteLine(@"T.ex: ""5 200""");
                                    Console.WriteLine("");
                                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                    productManager.DisplayChosenProducts(productId, chosenProducts, ref totalPrice, amount);
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nTryck på valfri knapp för att återgå till produkterna...");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(@"Var vänlig att ange ett korrekt ""ProduktID"", försök igen.");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn...");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    DisplayMenu();
                                }
                            }
                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Tack för att använde dig av vår kassasystem!!!");
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Var vänlig att ange rätt flik nummer, försök igen.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du skrev i fel format, försök igen.");
                    Console.ResetColor();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"Var vänlig att ange ett korrekt ""ProduktID"", försök igen.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"Var vänlig att ange ett värde som inte överstiger det tillåtna intervallet för datatypen, försök igen.");
                    Console.ResetColor();
                }
            }
        }
    }
}