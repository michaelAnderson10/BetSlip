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
                new Bet("Football", 2, 10),
                new Bet("Hockey", 4, 5)
            };
            Bet footballBet = bets[0];
            BetReturn expectedFootballReturn = new BetReturn(footballBet.SportEvent, footballBet.Odd, footballBet.Amount, 30);
                         
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
                new BetReturn("Football", 2, 10, 30),
                new BetReturn("Hockey", 2, 5, 15)
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
    }
}
