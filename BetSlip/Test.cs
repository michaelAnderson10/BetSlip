using NUnit.Framework;

namespace BetSlip
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void CalculateReturn_BetReturnTest()
        {
            //Arrage
            List<Bet> bets = new List<Bet>
            {
                new Bet("Football", 2, "2/1", 10),
                new Bet("Hockey", 4, "3/2", 5)
            };
            Bet footballBet = bets[0];
            BetReturn expectedFootballReturn = new BetReturn(footballBet.SportEvent, footballBet.Odd, footballBet.OddFraction, footballBet.Amount, 30);
                         
            //Act
            BetProcessorMain betProcessorMain = new BetProcessorMain();
            List<BetReturn> betReturns = betProcessorMain.CalculateReturn(bets);

            //Assert
            BetReturn actualFootballReturn = betReturns[0];

            Assert.AreEqual(2, betReturns.Count);
            Assert.AreEqual(expectedFootballReturn.SportEvent, actualFootballReturn.SportEvent);
            Assert.AreEqual(expectedFootballReturn.Odd, actualFootballReturn.Odd);
            Assert.AreEqual(expectedFootballReturn.Amount, actualFootballReturn.Amount);
            Assert.AreEqual(30, actualFootballReturn.PotentialReturns);
        }

        [Test]
        public void CalculateTotalBetAndPotentialReturn_Checks()
        {
            //Arrange
            List<BetReturn> betReturns = new List<BetReturn>
            {
                new BetReturn("Football", 2, "2/1", 10, 30),
                new BetReturn("Hockey", 2, "2/1", 5, 15)
            };
            
            decimal expectedTotalBet = 15;
            decimal expectedTotalPotentialReturn = 45;
            BetReturn football = betReturns[0];

            //Act
            BetProcessorMain betProcessorMain = new BetProcessorMain();
            BetOutcome betOutcome = betProcessorMain.CalculateTotalBetAndPotentialReturn(betReturns);

            //Assert
            Assert.AreEqual(2, betReturns.Count());
            Assert.AreEqual(expectedTotalBet, betOutcome.TotalBet);
            Assert.AreEqual(expectedTotalPotentialReturn, betOutcome.TotalPotentialReturn);           
        }
        [Test]
        public void CalculateSettlement_Checks()
        {
            //Arrange
            List<BetReturn> betReturns = new List<BetReturn>()
            {
                new BetReturn("Football", 2, "2/1", 10, 30),
                //new BetReturn("Hockey", 2, "2/1", 5, 15)
            };
            BetReturn Football = betReturns[0];
            decimal expectedTotalBet1 = 15;
            decimal expectedTotalPotentialReturn1 = 45;
            BetOutcome expectedOutcome = new BetOutcome(expectedTotalBet1, expectedTotalPotentialReturn1);
            BetSlip expectedBetSlip = new BetSlip(betReturns, expectedOutcome );

            BetReturn actualBetReturn = new BetReturn(Football.SportEvent, Football.Odd, Football.OddFraction, Football.Amount, expectedTotalPotentialReturn1);
            BetOutcome actualBetOutcome = new BetOutcome(15, 45);
            BetSlip actualBetslip = new BetSlip(betReturns, actualBetOutcome );
           
            //Act
            BetProcessorMain betProcessorMain1 = new BetProcessorMain();
            BetSlip expectedSettlement = betProcessorMain1.CalculateSettlement(expectedBetSlip);
            BetSlip actualSettlement = betProcessorMain1.CalculateSettlement(actualBetslip);

            //Asert
            Assert.AreEqual(actualSettlement, expectedSettlement);
        }
    }
}
