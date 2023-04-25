using BlazorServerApp_Stocks.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServerApp_Stocks.Hubs
{
    public class StockUpdatesHub : Hub
    {
        private StockUpdater _stockUpdater;
        public const string HubUrl = "/stockupdater";
        public StockUpdatesHub(StockUpdater stockUpdater)
        {
            _stockUpdater = stockUpdater;
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            return _stockUpdater.GetAllStocks();
        }

        public async Task AddStock(Stock stock)
        {
            _stockUpdater.AddStock(stock);
            await Clients.All.SendAsync("StockAdded", stock);
        }
       
        public async Task RemoveStock(Stock stock)
        {
            _stockUpdater.RemoveStock(stock);
            await Clients.All.SendAsync("StockRemoved", stock);
        }
    }
}
