using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata.Tests
{
    [TestClass]
    public partial class VendingMachineTests
    {
        [TestClass]
        public partial class SelectProduct_Should
        {
            [TestMethod]
            public void Return_Correct_Amount_Of_Change()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Nickel);

                sut.SelectProduct('A');

                Assert.AreEqual(5, sut.CoinReturn.Sum(c => c.Value));
            }
        }
    }
}
