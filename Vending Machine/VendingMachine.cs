using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine_Kata.Interfaces;
using Vending_Machine_Kata;
using Vending_Machine_Kata.Currency;

namespace Vending_Machine_Kata
{
    public class VendingMachine
    {
        ICurrencyIdentifier identifier = new CoinIdentifier();
        IList<Coin> InsertedCoins = new List<Coin>();
        IList<Product> products = new List<Product>();
        List<Coin> quarters = new List<Coin>();
        List<Coin> dimes = new List<Coin>();
        List<Coin> nickels = new List<Coin>();
        Product selectedProduct;

        public VendingMachine()
        {
            // Load up some inventory
            products.Add(new Product() { Button = 'A', Name = "Cola", Price = 100, Count = 12 });
            products.Add(new Product() { Button = 'B', Name = "Chips", Price = 50, Count = 2 });
            products.Add(new Product() { Button = 'C', Name = "Candy", Price = 65, Count = 20 });

            // Load up some change
            nickels.AddRange(Bank.GetNickels(5));
            dimes.AddRange(Bank.GetDimes(5));
            quarters.AddRange(Bank.GetQuarters(5));
        }
        
        public IList<Coin> CoinReturn = new List<Coin>();
        public IList<Product> ProductReturn = new List<Product>();

        bool selectedProductSoldOut;
        bool productJustDispensed;
        public string Display
        {
            get
            {
                if (selectedProductSoldOut)
                {
                    selectedProductSoldOut = false;
                    return "SOLD OUT";
                }

                if (productJustDispensed)
                {
                    productJustDispensed = false;
                    return "THANK YOU";
                }

                int sum = InsertedCoins.Sum(c => c.Value);
                if (sum == 0 && selectedProduct != null)
                {
                    return FormatPrice(selectedProduct.Price);
                }

                if (sum > 0)
                {
                    return FormatPrice(sum);
                }

                if (!CanMakeChange())
                {
                    return "EXACT CHANGE ONLY";
                }

                return "INSERT COIN";
            }
        }

        private string FormatPrice(int price)
        {
            return "$" + (price / 100f).ToString("0.00");
        }

        private bool CanMakeChange()
        {
            return nickels.Count > 0 && dimes.Count > 1;
        }

        public void InsertCoin(Coin coin)
        {
            if(InsertedCoins.Sum(c => c.Value) >= products.Max(p => p.Price))
            {
                CoinReturn.Add(coin);
                return;
            }

            coin.Value = identifier.GetCoinValue(coin);

            if (coin.Value == 0f)
            {
                CoinReturn.Add(coin);
            }
            else
            {
                InsertedCoins.Add(coin);
            }
            DispenseProduct();
        }

        public void SelectProduct(char button)
        {
            selectedProduct = products.First(p => p.Button == button);
            if (selectedProduct.Count == 0)
            {
                selectedProductSoldOut = true;
            }
            else
            {
                DispenseProduct();
            }
        }

        private void DispenseProduct()
        {
            if (selectedProduct == null)
            {
                return;
            }

            var valueInserted = InsertedCoins.Sum(c => c.Value);
            if (valueInserted >= selectedProduct.Price)
            {
                ProductReturn.Add(new Product() { Name = selectedProduct.Name });
                products.First(p => p.Button == selectedProduct.Button).Count--;
                var changeDue = valueInserted - selectedProduct.Price;
                DispenseChange(changeDue);
                selectedProduct = null;
                InsertedCoins.Clear();
                productJustDispensed = true;
            }
        }

        private void DispenseChange(int changeDue)
        {
            while(changeDue >= 25 && quarters.Any())
            {
                CoinReturn.Add(quarters[0]);
                quarters.RemoveAt(0);
                changeDue -= 25;
            }
            
            while(changeDue >= 10 && dimes.Any())
            {
                CoinReturn.Add(dimes[0]);
                dimes.RemoveAt(0);
                changeDue -= 10;
            }

            while (changeDue >= 5)
            {
                CoinReturn.Add(nickels[0]);
                nickels.RemoveAt(0);
                changeDue -= 5;
            }
        }

        public void ReturnCoins()
        {
            ((List<Coin>)CoinReturn).AddRange(InsertedCoins);
            InsertedCoins.Clear();
        }
    }
}
