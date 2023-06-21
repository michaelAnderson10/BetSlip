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
                Console.WriteLine("To place a bet, press Y");
                Console.WriteLine("To cancel bet, Press N");
                Console.WriteLine("To Print Bet Slip, press P");
                Console.WriteLine("Place a bet? (Y/N/P)");
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
                        Console.WriteLine("An error occured, please type a correct formats as instructed below...");
                        Console.WriteLine("Sport event: Words, Amount: Number, Odd: Fraction, e.g 2/1");
                    }
                    continue;

                }
                else if (choice.Equals("P", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(".......Bet Slip.......");
                }
                else if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Invalid choice. Please press Y, N or P.");
                }
            }
            while (!choice.Equals("P", StringComparison.OrdinalIgnoreCase));

            return bets;

        }

    }
}
