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
            public void Update_Display()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Nickel);

                Assert.AreEqual("$0.05", sut.Display);
            }
        }
    }
}
