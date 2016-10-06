using System;
using System.IO;

namespace _11_Files
{
    internal class StockIO
    {
        internal void WriteStock(StringWriter sw, Stock hp)
        {
            sw.WriteLine(hp.Symbol);
            sw.WriteLine(hp.PricePerShare);
            sw.WriteLine(hp.NumShares);


        }

        internal Stock ReadStock(StringReader data)
        {
            Stock stock = new Stock();
            stock.Symbol=data.ReadLine();
            stock.PricePerShare = double.Parse(data.ReadLine());
            stock.NumShares = int.Parse(data.ReadLine());
            return stock;
        }

        internal void WriteStock(FileInfo output, Stock hp)
        {
            StringWriter sw = new StringWriter();
            StreamWriter writer;
            this.WriteStock(sw, hp);
            writer = new StreamWriter(output.Name);
            writer.WriteLine(sw.ToString());
           
            writer.Close();
        }

        internal Stock ReadStock(FileInfo output)
        {
			throw new NotImplementedException();
        }
    }
}