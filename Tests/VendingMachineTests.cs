using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine_Kata
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestClass]
        public class Display_Should
        {
            [TestMethod]
            public void Read_INSERT_COIN_when_no_coins_inserted()
            {
                var sut = new VendingMachine();

                Assert.AreEqual("INSERT COIN", sut.Display);
            }
        }

        [TestClass]
        public class InsertCoin_Should
        {
            [TestMethod]
            public void Update_Display_When_Nickel_Inserted()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Nickel);

                Assert.AreEqual("$0.05", sut.Display);
            }

            [TestMethod]
            public void Update_Display_When_Dime_Inserted()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Dime);

                Assert.AreEqual("$0.10", sut.Display);
            }

            [TestMethod]
            public void Put_Inserted_Penny_into_Coin_Return()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Penny);

                Assert.AreEqual(1, sut.CoinReturn.Count);
            }

            [TestMethod]
            public void Put_Inserted_Penny_and_Half_Dollar_into_Coin_Return()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Penny);
                sut.InsertCoin(TestCoins.HalfDollar);

                Assert.AreEqual(2, sut.CoinReturn.Count);
            }
        }
    }
}