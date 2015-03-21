using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine_Kata
{
    [TestClass]
    public class CoinIdentifierTests
    {
        [TestClass]
        public class GetCoinValue_Should
        {
            // Using coin specs found here: http://www.usmint.gov/about_the_mint/index.cfm?flash=yes&action=coin_specifications 

            [TestMethod]
            public void Match_5_cents_by_a_Nickels_Size_and_weight()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5f, DiameterInMM = 21.21f, ThicknessInMM = 1.95f });

                Assert.AreEqual(5, actual);
            }
        }
    }
}
