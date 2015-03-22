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
            public void Return_5_cents_when_matching_a_Nickels_weight_and_size()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.000f, DiameterInMM = 21.21f, ThicknessInMM = 1.95f });

                Assert.AreEqual(5, actual);
            }

            [TestMethod]
            public void Return_0_cents_when_matching_a_Nickels_weight_but_wrong_size()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.000f, DiameterInMM = 23.00f, ThicknessInMM = 1.95f });

                Assert.AreEqual(0, actual);
            }

            [TestMethod]
            public void Return_0_cents_when_matching_a_Nickels_weight_and_diameter_but_wrong_thickness()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.000f, DiameterInMM = 21.21f, ThicknessInMM = 1.85f });

                Assert.AreEqual(0, actual);
            }

            [TestMethod]
            public void Return_10_cents_when_matching_a_Dimes_weight_and_size()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 2.268f, DiameterInMM = 17.91f, ThicknessInMM = 1.35f });

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
            public void Return_25_cents_when_matching_a_Quarters_weight_and_size()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 5.670f, DiameterInMM = 24.26f, ThicknessInMM = 1.75f });

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
            public void Return_0_cents_when_given_Half_Dollar()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 11.340f });

                Assert.AreEqual(0, actual);
            }

            [TestMethod]
            public void Return_0_cents_when_given_Penny()
            {
                var sut = new CoinIdentifier();

                var actual = sut.GetCoinValue(new Coin() { WeightInGrams = 2.500f, DiameterInMM = 19.05f, ThicknessInMM = 1.52f });

                Assert.AreEqual(0, actual);
            }
        }
    }
}
