using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata
{
    public class VendingMachine
    {
        string display = "INSERT COIN";

        public string Display
        {
            get { return display; }
        }

        internal void InsertCoin(Coin coin)
        {
            display = "$0.05";
        }
    }
}
