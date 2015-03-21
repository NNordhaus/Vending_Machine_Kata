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
            public void Return_5_cents_when_matching_a_Nickels_weight_and_diameter()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.000f, DiameterInMM = 21.21f });

                Assert.AreEqual(5, actual);
            }

            [TestMethod]
            public void Return_0_cents_when_matching_a_Nickels_weight_but_wrong_diameter()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.000f, DiameterInMM = 23.00f });

                Assert.AreEqual(0, actual);
            }

            [TestMethod]
            public void Return_10_cents_when_matching_a_Dimes_weight()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 2.268f, DiameterInMM = 17.91f });

                Assert.AreEqual(10, actual);
            }

            [TestMethod]
            public void Return_0_cents_when_matching_a_Dimes_weight_but_wrong_diameter()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 2.268f, DiameterInMM = 23.00f });

                Assert.AreEqual(0, actual);
            }

            [TestMethod]
            public void Return_25_cents_when_matching_a_Quarters_weight()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.670f, DiameterInMM = 24.26f });

                Assert.AreEqual(25, actual);
            }

            [TestMethod]
            public void Return_0_cents_when_matching_a_Quarterss_weight_but_wrong_diameter()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.670f, DiameterInMM = 23.00f });

                Assert.AreEqual(0, actual);
            }

            [TestMethod]
            public void Not_match_Half_Dollar()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 11.340f });

                Assert.AreEqual(0, actual);
            }
        }
    }
}
