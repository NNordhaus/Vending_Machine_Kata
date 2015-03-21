using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Kata
{
    public class CoinIdentifier
    {
        public CoinIdentifier()
        {
            acceptedCoins = new List<Coin>(3);

            // http://www.usmint.gov/about_the_mint/index.cfm?flash=yes&action=coin_specifications
            acceptedCoins.Add(new Coin() { Value = 5, WeightInGrams = 5.000f, DiameterInMM = 21.21f, ThicknessInMM = 1.95f }); // USD Nickel
            acceptedCoins.Add(new Coin() { Value = 10, WeightInGrams = 2.268f, DiameterInMM = 17.91f, ThicknessInMM = 1.35f }); // USD Dime
            acceptedCoins.Add(new Coin() { Value = 25, WeightInGrams = 5.670f, DiameterInMM = 24.26f, ThicknessInMM = 1.75f }); // USD Quarter
        }

        List<Coin> acceptedCoins;

        public int GetCoinValue(Coin c)
        {
            var matched = acceptedCoins.FirstOrDefault(ac => 
                ac.WeightInGrams == c.WeightInGrams
                && ac.DiameterInMM == c.DiameterInMM);

            if (matched == null)
            {
                return 0;
            }

            return matched.Value;
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