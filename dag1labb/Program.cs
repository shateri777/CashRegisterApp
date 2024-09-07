using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dag1labb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine(2023);
            Console.WriteLine("2024");
            Console.WriteLine(2023-12-24);
            Console.WriteLine("2023-12-24");

            Console.WriteLine("Hej vad heter du?");
            string name = Console.ReadLine();
            Console.WriteLine($"Jag heter {name}");

            int dagar = 24;
            Console.WriteLine("Den här kursen är: ");
            Console.WriteLine(dagar);
            Console.WriteLine("dagar lång.");
            Console.ReadKey();
            Console.WriteLine("Athyaaaaa");
            int num = 2;

            switch (num)
            {
                Console.ReadLine();
                case 1:     
                    Console.WriteLine("This is option 1");
                    break;
                case 2:
                    Console.WriteLine("This is option 1");
                    break;
                default:
                    Console.WriteLine("Try again");
                    break;


                // x is declared inside MyMethod's scope​

                int x = 5; ​

                if (x == 5)​

                {​

                    // y is declared inside the if statement's scope​

                    int y = 10; ​

                    Console.WriteLine("x is 5 and y is " + y);​

                }​

                Console.WriteLine("x is " + x);​

                // OBS: y cannot be accessed here because it's outside of its scope​
                // Try to print y to the console. What happens?
                Console.WriteLine(y);}


            // få ålder från user
            Console.WriteLine("Barn");
            int age = Convert.ToUInt32(Console.ReadLine()));
            // skriv ut text "barn" om dem är under 18
            if (age <= 18)
            {
                Console.WriteLine("Barn");

            }
            else if (age > 18 && < 65)
            {
                Console.WriteLine("Vuxen");

            }*/


            /* Console.Write("Skriv in ditt förnamn: ");
           string firstName = Console.ReadLine();
           Console.Write("Skriv in ditt efternamn: ");
           string lastName = Console.ReadLine();
           Console.WriteLine($"Ditt namn är {firstName} {lastName}"); */

            /* Console.WriteLine("Mata in tal 1:");
             int nmr1 = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Mata in tal 2:");
             int nmr2 = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine(nmr1 + nmr2);
             Console.WriteLine(nmr1 - nmr2);
             Console.WriteLine(nmr1 + nmr2 * 1.25);
             Console.ReadKey();*/

            Console.WriteLine("Mata in antal minuter: ");
            int minuter = Convert.ToInt32(Console.ReadLine());
            int timme = minuter / 60;
            int minuterkvar = minuter % 60;
            int dagar = timme / 24;
            int timmekvar = timme % 24;

            string message = $"Detta blir {minuterkvar} minuter, {timmekvar} timmar och {dagar} dagar!";
            string message2 = $"Detta blir {minuterkvar} minuter, {timmekvar} timmar och {dagar} dag!";
            string message3 = $"Detta blir {minuterkvar} minuter och {timmekvar} timmar!";
            string message4 = $"Detta blir {minuterkvar} minuter och {timmekvar} timme!";
            string message5 = $"Detta blir {minuterkvar} minut och {timmekvar} timmar!";
            string message6 = $"Detta blir {minuterkvar} minut och {timmekvar} timme!";
            string errormessage = $"Oops! Värdet måste vara högre än 60..\nFörsök igen!\n";

            if (minuter < 60)
            {
                Console.WriteLine(errormessage);
                Main(args);

            }
            else if (dagar == 1)
            {
                Console.Write(message2);
            }
            else if (dagar < 1)
            {
                Console.Write(message3);
            }
            else if(timmekvar == 1)
            {
                Console.WriteLine(message4);
            }
            else if(minuterkvar == 1)
            {
                Console.WriteLine(message5);
            }
            else if(minuterkvar == 1 && timme == 1)
            {
                Console.WriteLine(message6);
            }
            else
            {
                Console.WriteLine(message);
            }
            hejsan hoppsan detta är en liten testi test test hehe 
        }
    }
}
