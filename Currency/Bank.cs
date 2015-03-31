using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata.Currency
{
    /// <summary>
    /// Bank provides the source of coins, valid coins should not be "minted" anywhere but here.
    /// http://www.usmint.gov/about_the_mint/index.cfm?flash=yes&action=coin_specifications
    /// </summary>
    public class Bank
    {
        public static IEnumerable<Coin> GetNickels(int count)
        {
            int counter = 0;
            while (counter < count)
            {
                yield return new Coin() { Value = 5, WeightInGrams = 5.000f, DiameterInMM = 21.21f, ThicknessInMM = 1.95f };
                counter++;
            }
        }

        public static IEnumerable<Coin> GetDimes(int count)
        {
            int counter = 0;
            while (counter < count)
            {
                yield return new Coin() { Value = 10, WeightInGrams = 2.268f, DiameterInMM = 17.91f, ThicknessInMM = 1.35f };
                counter++;
            }
        }

        public static IEnumerable<Coin> GetQuarters(int count)
        {
            int counter = 0;
            while (counter < count)
            {
                yield return new Coin() { Value = 25, WeightInGrams = 5.670f, DiameterInMM = 24.26f, ThicknessInMM = 1.75f };
                counter++;
            }
        }
    }
}
