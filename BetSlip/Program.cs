using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace BetSlip
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            
            List<Bet> bets = UserInputManager.UserInputConverter();
            BetProcessorMain betProcessor = new BetProcessorMain();
            List<BetReturn> betReturns = betProcessor.CalculateReturn(bets);
            BetOutcome outcome = betProcessor.CalculateTotalBetAndPotentialReturn(betReturns);

            BetSlip betSlip = new BetSlip(betReturns, outcome);
          
            foreach (var bet in betSlip.Betreturns)
            {
                Console.WriteLine($"{bet.SportEvent} @ {bet.OddFraction} Bet:£{bet.Amount} Return:£{bet.PotentialReturns}");
            }
            Console.WriteLine($"Total Bet: £{betSlip.BetOutcome.TotalBet}");
            Console.WriteLine($"Total Potential Returns: £{betSlip.BetOutcome.TotalPotentialReturn}");
            BetSlip TotalSettlement = betProcessor.CalculateSettlement(betSlip);
            Console.WriteLine();
            Console.WriteLine("Printing Final Settlement...");
            foreach (var bet in TotalSettlement.Betreturns)
            {
                Console.WriteLine($"{bet.SportEvent} @ {bet.OddFraction} Bet:£{bet.Amount} Return:£{bet.PotentialReturns}");
            }
            Console.WriteLine($"Final Settlement: £{TotalSettlement.BetOutcome.TotalPotentialReturn}");
        }
    }
} 