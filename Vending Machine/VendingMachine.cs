using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine_Kata.Interfaces;

namespace Vending_Machine_Kata
{
    public class VendingMachine
    {
        ICurrencyIdentifier identifier = new CoinIdentifier();
        IList<Coin> InsertedCoins = new List<Coin>();

        public IList<Coin> CoinReturn = new List<Coin>();

        public string Display
        {
            get
            {
                int sum = InsertedCoins.Sum(c => c.Value);
                if (sum > 0)
                {
                    return "$" + (sum / 100f).ToString("0.00");
                }
                return "INSERT COIN";
            }
        }

        public void InsertCoin(Coin coin)
        {
            coin.Value = identifier.GetCoinValue(coin);

            if (coin.Value == 0f)
            {
                CoinReturn.Add(coin);
            }
            else
            {
                InsertedCoins.Add(coin);
            }
        }

        
    }
}
