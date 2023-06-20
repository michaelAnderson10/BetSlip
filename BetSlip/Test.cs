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
            Assert.AreEqual(2, betReturns.Count);
            BetReturn actualFootballReturn = betReturns[0];

            Assert.AreEqual(expectedFootballReturn.SportEvent, actualFootballReturn.SportEvent);
            Assert.AreEqual(expectedFootballReturn.Odd, actualFootballReturn.Odd);
            Assert.AreEqual(expectedFootballReturn.Amount, actualFootballReturn.Amount);
            Assert.AreEqual(30, actualFootballReturn.PotentialReturns);
        }
    }
}
