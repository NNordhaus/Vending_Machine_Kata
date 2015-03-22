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
        }
    }
}
