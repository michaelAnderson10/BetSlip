﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetSlip
{
    public class Bet
    {
        public string? SportEvent { get; set; }
        public decimal Odd { get; set; }
        public string? OddFraction { get; set; }
        public decimal Amount { get; set; }


        public Bet(string sportEvent, decimal odd,string oddFraction, decimal amount)
        {
            SportEvent = sportEvent;
            Odd = odd;
            OddFraction = oddFraction;
            Amount = amount;        
        }
    }
}
