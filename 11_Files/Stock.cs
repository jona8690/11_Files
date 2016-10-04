using System;

namespace _11_Files
{
    internal class Stock : IAsset
    {
        public Stock(string symbol, double pricePerShare, int numShares)
        {
            Symbol = symbol;
            PricePerShare = pricePerShare;
            NumShares = numShares;
        }

        public Stock()
        {

        }

        public int NumShares { get; internal set; }
        public double PricePerShare { get; internal set; }
        public string Symbol { get; internal set; }
        public int Id { get; internal set; }

        public double GetValue()
        {
            return PricePerShare * NumShares;

        }

        internal static double TotalValue(IAsset[] stocks)
        {
            double totalValue = 0;
            foreach (IAsset stock in stocks)
            {
                totalValue = totalValue + stock.GetValue();
            }



            return totalValue;



        }

        public override string ToString()
        {
            return "Stock[symbol=" + Symbol + ",pricePerShare=" + PricePerShare + ",numShares=" + NumShares + "]";
        }

        public override bool Equals(object obj)
        {
            Stock abc = (Stock)obj;

            return (Symbol == abc.Symbol && PricePerShare == abc.PricePerShare && NumShares == abc.NumShares);
        }

        public string GetName()
        {
            return Symbol;
        }
    }
}