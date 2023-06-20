using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public class BetReturn
    {
        public string? SportEvent { get; set; }
        public decimal Odd { get; set; }
        public decimal Amount { get; set; }
        public decimal PotentialReturns { get; set; }

        public BetReturn(string sportEvent, decimal odd, decimal amount, decimal potentialReturn)
        {
            SportEvent = sportEvent;
            Odd = odd;
            Amount = amount;
            PotentialReturns = potentialReturn;
        }
    }
}
