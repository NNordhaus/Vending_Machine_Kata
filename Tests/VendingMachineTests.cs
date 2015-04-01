using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine_Kata
{
    [TestClass]
    public partial class VendingMachineTests
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

            [TestMethod]
            public void Read_THANK_YOU_on_first_read_after_dispense_then_INSERT_COIN()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);

                sut.SelectProduct('A');

                Assert.AreEqual("THANK YOU", sut.Display);
                Assert.AreEqual("INSERT COIN", sut.Display);
            }

            [TestMethod]
            public void Read_EXACT_CHANGE_ONLY_when_cannot_give_nickel_back()
            {
                var sut = new VendingMachine();
            
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.SelectProduct('A');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.SelectProduct('A');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.SelectProduct('A');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.SelectProduct('A');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.InsertCoin(TestCoins.Dime);
                sut.SelectProduct('A');
                var d = sut.Display;
                Assert.AreEqual("THANK YOU", d);
           
                Assert.AreEqual("EXACT CHANGE ONLY", sut.Display);
            }

            [TestMethod]
            public void Read_EXACT_CHANGE_ONLY_when_cannot_give_two_dimes_back()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.SelectProduct('C');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.SelectProduct('C');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.SelectProduct('C');

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.SelectProduct('C');

                var d = sut.Display;
                Assert.AreEqual("THANK YOU", d);

                Assert.AreEqual("EXACT CHANGE ONLY", sut.Display);
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

            [TestMethod]
            public void Reject_Any_Coin_When_Inserted_Amount_Is_Equal_or_Greater_than_most_expensive_item()
            {
                var sut = new VendingMachine();

                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);
                sut.InsertCoin(TestCoins.Quarter);

                Assert.AreEqual(1, sut.CoinReturn.Count);
            }
        }   
    }
}