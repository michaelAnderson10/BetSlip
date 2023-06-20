using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public class BetProcessorMain : IbetProcessor
    {      
        public List<BetReturn> CalculateReturn(List<Bet> bets)
        {
            List<BetReturn> betReturns = new List<BetReturn>();

            for (int i = 0; i<bets.Count(); i++)
            {
                decimal Odd = bets[i].Odd;
                decimal Amount = bets[i].Amount; 
                decimal PotentialReturn = (Odd * Amount) + Amount;
                BetReturn betReturn = new BetReturn(bets[i].SportEvent, Odd, Amount, PotentialReturn);
                betReturns.Add(betReturn);
            }          
            return betReturns;
        }

        public BetOutcome CalculateTotalBetAndPotentialReturn(List<BetReturn> betReturns)
        {
            decimal TotalBet = 0;
            decimal TotalPotentialReturn = 0;

            foreach(var betReturn in betReturns)
            {
                TotalBet += betReturn.Amount;
                TotalPotentialReturn += betReturn.PotentialReturns;
            }

            return new BetOutcome(TotalBet, TotalPotentialReturn);

        }
    }
}
