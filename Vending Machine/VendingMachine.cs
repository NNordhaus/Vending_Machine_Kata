using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine_Kata.Interfaces;
using Vending_Machine_Kata;

namespace Vending_Machine_Kata
{
    public class VendingMachine
    {
        ICurrencyIdentifier identifier = new CoinIdentifier();
        IList<Coin> InsertedCoins = new List<Coin>();
        IList<Product> products = new List<Product>();
        Product selectedProduct;

        public VendingMachine()
        {
            // Load up some inventory
            products.Add(new Product() { Button = 'A', Name = "Cola", Price = 100, Count = 12 });
            products.Add(new Product() { Button = 'B', Name = "Chips", Price = 50, Count = 10 });
            products.Add(new Product() { Button = 'C', Name = "Candy", Price = 65, Count = 20 });
        }
        
        public IList<Coin> CoinReturn = new List<Coin>();

        public string Display
        {
            get
            {
                int sum = InsertedCoins.Sum(c => c.Value);
                if (sum == 0 && selectedProduct != null)
                {
                    return "$" + (selectedProduct.Price / 100f).ToString("0.00");
                }

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

        public void SelectProduct(char button)
        {
            selectedProduct = products.First(p => p.Button == button);
        }
    }
}
