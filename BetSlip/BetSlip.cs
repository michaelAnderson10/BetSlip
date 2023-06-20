using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public class BetSlip
    {    
        public List<BetReturn> Betreturns { get; set; }    
        public BetOutcome BetOutcome { get; set; }

        public BetSlip(List<BetReturn> betReturns, BetOutcome betOutcome)
        {
            Betreturns = betReturns;
            BetOutcome = betOutcome;
        }
    }
}
