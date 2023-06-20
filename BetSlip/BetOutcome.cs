using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public class BetOutcome
    {
        public decimal TotalBet { get; set; } 
        public decimal TotalPotentialReturn { get; set; }

        public BetOutcome(decimal totalBet, decimal totalPotentialReturn)
        {
           TotalBet = totalBet;
           TotalPotentialReturn = totalPotentialReturn;    
        }
    }
}
