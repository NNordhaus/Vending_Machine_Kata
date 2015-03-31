using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata.Tests
{
    [TestClass]
    public partial class SoldOutTests
    {
        [TestClass]
        public partial class SelectProduct_Should
        {
            [TestMethod]
            public void Set_Display_To_Sold_Out_when_Product_has_zero_inventory()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.SelectProduct('B');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.SelectProduct('B');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.SelectProduct('B');

                Assert.AreEqual("SOLD OUT", sut.Display);
            }

            [TestMethod]
            public void Return_Correct_Amount_Of_Change_when_change_needs_Multiple_Coins()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Nickel);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);

                sut.SelectProduct('A');

                Assert.AreEqual(35, sut.CoinReturn.Sum(c => c.Value));
                Assert.IsTrue(sut.CoinReturn.Count > 1);
            }
        }
    }
}
