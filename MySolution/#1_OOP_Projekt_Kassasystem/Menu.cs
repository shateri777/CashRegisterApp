using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _1_OOP_Projekt_Kassasystem
{
    internal class Menu
    {
        public void DisplayMenu()
        {
            List<Product> chosenProducts = new List<Product>();
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            ProductManager productManager = new ProductManager();

            Console.Clear();
            Console.WriteLine("1. Ny Kund");
            Console.WriteLine("2. Adminverktyg");
            Console.WriteLine("3. Avsluta");
            try
            {
                byte choice = Convert.ToByte(Console.ReadLine());
                while (choice >= 1 && choice <= 3)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            productManager.DisplayProducts();
                            Console.WriteLine("Kommandon:");
                            Console.WriteLine("<produktid> <antal> (Max antal: 255)");
                            Console.WriteLine("PAY");
                            string[] answers = new string[1];
                            answers = Console.ReadLine().Split(' ');
                            byte productid = Convert.ToByte(answers[0]);
                            byte amount = Convert.ToByte(answers[1]);
                            if(amount == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(@"Du får inte välja ""0"" som antal, programmet stänger ner..");
                                Console.ResetColor();
                                Environment.Exit(0);
                            }
                            float endPrice = 0;
                            Console.Clear();
                            productManager.DisplayChosenProducts(productid, chosenProducts, endPrice, amount);
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
                                DisplayMenu();
                            }
                            else if (answer2 == "RETURN")
                            {
                                Console.Clear();
                                DisplayMenu();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Du skrev i fel format, försök igen.");
                                Console.ResetColor();
                                Thread.Sleep(3000);
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Admin verktyg");
                            Console.WriteLine("______________");
                            break;


                        case 3:
                            Console.Clear();
                            Console.WriteLine("Thank you for using our kassasystem!");
                            Environment.Exit(0);
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Var vänlig att ange rätt flik nummer, programmet stänger ner..");
                Console.ResetColor();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du skrev i fel format, programmet stänger ner..");
                Console.ResetColor();
            }
            catch (IndexOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"Var vänlig att ange ett korrekt ""ProduktID"", programmet stänger ner..");
                Console.ResetColor();
            }
            catch (System.OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"Var vänlig att ange ett värde som inte överstiger det tillåtna intervallet för datatypen, programmet stänger ner..");
                Console.ResetColor();
            }
        }
    }
}
