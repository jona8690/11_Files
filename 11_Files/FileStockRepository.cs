using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace _11_Files
{
    internal class FileStockRepository : IStockRepository , IFileRepository
    {
        private DirectoryInfo repositoryDir;

        private int Id = 0;
        private Dictionary<long, Stock> Database = new Dictionary<long, Stock>();

        public FileStockRepository(DirectoryInfo repositoryDir)
        {
            this.repositoryDir = repositoryDir;
        }

        public void Clear()
        {
            Database.Clear();
        }

        public ICollection FindAllStocks()
        {
            return Database;
        }

        public Stock LoadStock(long id)
        {
            StreamReader reader = new StreamReader(this.StockFileName(id));
            Stock returnStock = new Stock();
            returnStock.Symbol = reader.ReadLine();
            returnStock.PricePerShare = double.Parse (reader.ReadLine());
            returnStock.NumShares = int.Parse (reader.ReadLine());
            reader.Close();
            return returnStock;

        }

        public long NextId()
        {
            Id++;
            return Id;
        }

        public void SaveStock(Stock stock)
        {
            if(stock.Id == 0)
            {
                stock.Id = (int) this.NextId();
            }

            if (Database.ContainsKey(stock.Id))
            {
                Database[stock.Id] = stock;
            }
            else Database.Add(stock.Id, stock);

            StreamWriter writer;
            writer = new StreamWriter(this.StockFileName(stock));
            writer.WriteLine(stock.Symbol);
            writer.WriteLine(stock.PricePerShare);
            writer.WriteLine(stock.NumShares);

            writer.Close();
        }

        public string StockFileName(long v)
        {
            return "stock" + v + ".txt";
        }

        public string StockFileName(Stock v)
        {
           return this.StockFileName(v.Id);
            
        }
    }
}