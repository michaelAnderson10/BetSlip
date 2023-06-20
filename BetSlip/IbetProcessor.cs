using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public interface IbetProcessor
    { 
        abstract List<BetReturn> CalculateReturn(List<Bet> bets);
        abstract BetOutcome CalculateTotalBetAndPotentialReturn(List<BetReturn> betReturns);
    }
}
