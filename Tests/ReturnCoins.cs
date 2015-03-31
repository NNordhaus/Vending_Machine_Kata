using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata.Tests
{
    [TestClass]
    public class ReturnCoinTests
    {
        [TestClass]
        public partial class ReturnCoin_Should
        {
            [TestMethod]
            public void Return_All_Money_Inserted()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Nickel);

                sut.ReturnCoins();

                Assert.AreEqual(4, sut.CoinReturn.Count);
                Assert.AreEqual(65, sut.CoinReturn.Sum(c => c.Value));
            }

        }
    }
}
