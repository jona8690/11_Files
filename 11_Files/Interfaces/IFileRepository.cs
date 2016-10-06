namespace _11_Files
{
    internal interface IFileRepository
    {
        string StockFileName(long v);
        string StockFileName(Stock v);
        void SaveStock(Stock yhoo);
    }
}