namespace BlazorServerApp_Stocks.Shared
{
    public class StockUpdater
    {
        public List<Stock> _stocks;

        public StockUpdater()
        {
            _stocks = new List<Stock>
        {
            new Stock { Symbol = "CSCO", Price = 135.39m },
            new Stock { Symbol = "GOOG", Price = 242.35m },
            new Stock { Symbol = "ORCL", Price = 2295.87m },
            new Stock { Symbol = "APPL", Price = 3399.44m },
            new Stock { Symbol = "INFY", Price = 301.87m },
        };
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stocks;
        }

        public void AddStock(Stock stock)
        {
            _stocks.Add(stock);
        }

        public void RemoveStock(Stock stock)
        {
            Stock stockToRemove = _stocks.Find(x => x.Symbol == stock.Symbol && x.Price == stock.Price);
            if(stockToRemove != null)
            {
                _stocks.Remove(stockToRemove);
            }
        }
    }
}
