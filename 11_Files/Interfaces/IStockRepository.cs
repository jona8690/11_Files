using System.Collections;

namespace _11_Files
{
    internal interface IStockRepository
    {
        long NextId();
        void SaveStock(Stock yhoo);
        Stock LoadStock(long id);
        void Clear();
        ICollection FindAllStocks();
    }
}