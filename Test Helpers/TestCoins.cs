using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata
{
    public static class TestCoins
    {
        public static Coin Penny { get { return new Coin() { Value = 1, WeightInGrams = 2.500f, DiameterInMM = 19.05f, ThicknessInMM = 1.52f }; } }
        public static Coin Nickel { get { return new Coin() { Value = 5, WeightInGrams = 5.000f, DiameterInMM = 21.21f, ThicknessInMM = 1.95f }; } }
        public static Coin Dime { get { return new Coin() { Value = 10, WeightInGrams = 2.268f, DiameterInMM = 17.91f, ThicknessInMM = 1.35f }; } }
        public static Coin Quarter { get { return new Coin() { Value = 25, WeightInGrams = 5.670f, DiameterInMM = 24.26f, ThicknessInMM = 1.75f }; } }
        public static Coin HalfDollar { get { return new Coin() { Value = 50, WeightInGrams = 11.340f, DiameterInMM = 30.61f, ThicknessInMM = 2.15f }; } }
    }
}