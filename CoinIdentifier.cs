using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata
{
    public class CoinIdentifier
    {
        public int GetCoinValue(Coin c)
        {
            return 5;
        }
    }

    public class Coin
    {
        public int Value { get; set;}
        public float WeightInGrams { get; set;}
        public float DiameterInMM { get; set;}
        public float ThicknessInMM { get; set; }
    }
}
