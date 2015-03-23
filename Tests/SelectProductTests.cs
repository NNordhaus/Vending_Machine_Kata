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
        public class SelectProduct_Should
        {
            [TestMethod]
            public void Display_Product_Price()
            {
                var sut = new VendingMachine();

                sut.SelectProduct('A');

                Assert.AreEqual("$1.00", sut.Display);
            }

            [TestMethod]
            public void Dispense_correct_product_when_enough_money_was_already_inserted()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);

                sut.SelectProduct('A');

                Assert.AreEqual("Cola", sut.ProductReturn[0].Name);
            }

            [TestMethod]
            public void Dispense_correct_product_when_product_selected_then_money_inserted()
            {
                var sut = new VendingMachine();

                sut.SelectProduct('B');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Nickel);

                Assert.AreEqual("Chips", sut.ProductReturn[0].Name);
            }

            
        }
    }
}
