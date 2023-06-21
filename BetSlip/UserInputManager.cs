using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                    string? SportEvent;
                    decimal Odd;
                    string? OddFraction;
                    decimal Amount;

                    try
                    {
                        Console.Write("Enter Sport Event: ");
                        SportEvent = Console.ReadLine();

                        Console.Write("Enter Amount: ");
                        string? AmountInput = Console.ReadLine();
                        Amount = decimal.Parse(AmountInput);

                        Console.Write("Enter Odd: ");
                        OddFraction = Console.ReadLine();
                        string[] OddInputComponents = OddFraction.Split('/');
                        decimal numerator = decimal.Parse(OddInputComponents[0]);
                        decimal denominator = decimal.Parse(OddInputComponents[1]);
                        Odd = numerator / denominator;

                        Bet bet = new Bet(SportEvent, Odd, OddFraction, Amount);
                        bets.Add(bet);
                        Console.WriteLine("Values Inputed");

                    } 
                    catch 
                    {
                        Console.WriteLine("An error occured, please type a correct formats: Sport event: Words, Amount: Number, Odd: Fraction, e.g 2/1");
                    }
                    continue;

                }
                else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nPrinting Bet Slip...");
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
