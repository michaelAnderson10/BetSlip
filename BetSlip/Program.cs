using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace BetSlip
{
    internal class Program
    {

        public static string? choice;
        static void Main(string[] args)
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
                    Console.WriteLine("You chose to stop.");                  
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                }
            }
            while (!choice.Equals("N", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\nBet Slip");

            BetProcessorMain betProcessor = new BetProcessorMain();
            List<BetReturn> betReturns = betProcessor.CalculateReturn(bets);
            BetOutcome outcome = betProcessor.CalculateTotalBetAndPotentialReturn(betReturns);

            BetSlip betSlip = new BetSlip(betReturns, outcome);
            
            foreach (var bet in betSlip.Betreturns)
            {
                Console.WriteLine($"{bet.SportEvent} @ {bet.Odd} Bet:£{bet.Amount} Return:£{bet.PotentialReturns}");
            }
            Console.WriteLine($"Total Bet: £{betSlip.BetOutcome.TotalBet}");
            Console.WriteLine($"Total Potential Returns: £{betSlip.BetOutcome.TotalPotentialReturn}");
        }
    }
}