using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public class UserInputManager
    {
        public static string? choice;
        public static List<Bet> UserInputConverter()
        {
            List<Bet> bets = new List<Bet>();

            do
            {
                Console.WriteLine("Place a bet? (Y/N)");
                choice = Console.ReadLine();
                if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {

                    Console.WriteLine("You chose to continue!");

                    Console.Write("Enter Sport Event: ");

                    string? SportEvent = Console.ReadLine();

                    Console.Write("Enter Amount: ");
                    string? AmountInput = Console.ReadLine();
                    decimal Amount;
                    if (decimal.TryParse(AmountInput, out Amount))
                    {
                        //
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }

                    Console.Write("Enter Odd: ");
                    string? OddInput = Console.ReadLine();
                    decimal Odd;
                    if (decimal.TryParse(OddInput, out Odd))
                    {
                        //
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }

                    Bet bet = new Bet(SportEvent, Odd, Amount);
                    bets.Add(bet);
                    Console.WriteLine("Values Inputed");
                    continue;

                }
                else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Processing Bet Slip...");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                }
            }
            while (!choice.Equals("N", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\nBet Slip");

            return bets;

        }

    }
}
