using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public class SportEvents
    {
        public static int EventOutcome()
        {
            Random random = new Random();
            return random.Next(2);

        }
    }
}
