using _1_OOP_Projekt_Kassasystem.ProductManagement;
using _1_OOP_Projekt_Kassasystem.Transactions;

namespace _1_OOP_Projekt_Kassasystem.UI
{
    internal class Menu
    {
        public void DisplayMenu()
        {
            List<Product> chosenProducts = new List<Product>();
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            ProductManager productManager = new ProductManager();
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Ny Kund");
                    Console.WriteLine("2. Avsluta");
                    byte mainMenuChoice = Convert.ToByte(Console.ReadLine());
                    switch (mainMenuChoice)
                    {
                        case 1:
                            Console.Clear();
                            productManager.DisplayProducts();
                            Console.WriteLine("Kommandon:");
                            Console.WriteLine("<produktid> <antal> (Max antal: 255)");
                            Console.WriteLine("PAY");
                            string[] userInputForProductChoice = new string[1];
                            userInputForProductChoice = Console.ReadLine().Split(' ');
                            byte productId = Convert.ToByte(userInputForProductChoice[0]);
                            byte amount = Convert.ToByte(userInputForProductChoice[1]);
                            float totalPrice = 0;
                            if (amount == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(@"Du får inte välja ""0"" som antal, programmet stänger ner..");
                                Console.ResetColor();
                                Environment.Exit(0);
                            }
                            Console.Clear();
                            productManager.DisplayChosenProducts(productId, chosenProducts, totalPrice, amount);
                            Console.WriteLine("\nOm du är nöjd med produkterna så skriver du 'PAY' i konsolen.");
                            Console.WriteLine("Annars skriv 'RETURN' för att gå tillbaka till startmenyn.");
                            string userInputForPayment = Console.ReadLine().ToUpper();
                            if (userInputForPayment == "PAY")
                            {
                                Console.Clear();
                                Console.WriteLine("Ditt kvitto skrivs ut...");
                                Thread.Sleep(3000);
                                Receipt receipt = new Receipt();
                                receipt.readReceipt(currentDate);
                                receipt.createReceipt(chosenProducts, totalPrice, currentDate, amount);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("*RECEIPT HAS BEEN PRINTED*");
                                Console.ResetColor();
                                Thread.Sleep(1000);
                                DisplayMenu();
                            }
                            else if (userInputForPayment == "RETURN")
                            {
                                Console.Clear();
                                DisplayMenu();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Du skrev i fel format, försök igen.");
                                Console.ResetColor();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Tack för att använde dig av vår kassasystem!");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du skrev i fel format, försök igen.");
                    Console.ResetColor();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"Var vänlig att ange ett korrekt ""ProduktID"", försök igen.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"Var vänlig att ange ett värde som inte överstiger det tillåtna intervallet för datatypen, försök igen.");
                    Console.ResetColor();
                }
            }
        }
    }
}

