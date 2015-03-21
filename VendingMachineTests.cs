using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine_Kata
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestClass]
        public class VendingMachine_Should
        {
            [TestMethod]
            public void Display_INSERT_COIN_when_no_coins_inserted()
            {
                var sut = new VendingMachine();

                Assert.AreEqual("INSERT COIN", sut.Display);
            }
        }
    }
}
