using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine_Kata.Currency;
using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata
{
    public class CoinIdentifier : ICurrencyIdentifier
    {
        public CoinIdentifier()
        {
            acceptedCoins = new List<Coin>(3);
            
            acceptedCoins.Add(Bank.GetNickels(1).First());
            acceptedCoins.Add(Bank.GetDimes(1).First());
            acceptedCoins.Add(Bank.GetQuarters(1).First()); 
        }

        List<Coin> acceptedCoins;

        public int GetCoinValue(Coin c)
        {
            var matched = acceptedCoins.FirstOrDefault(ac => 
                ac.WeightInGrams == c.WeightInGrams
                && ac.DiameterInMM == c.DiameterInMM
                && ac.ThicknessInMM == c.ThicknessInMM);

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