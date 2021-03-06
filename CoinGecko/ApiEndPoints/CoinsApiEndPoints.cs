namespace CoinGecko.ApiEndPoints
{
    public static class CoinsApiEndPoints
    {
        public static readonly string Coins = "coins";
        public static readonly string CoinList = "coins/list";
        public static readonly string CoinMarkets = "coins/markets";
        public static string AllDataByCoinId(string id) => "coins/" + id;
        public static string TickerByCoinId(string id) => "coins/" + id + "/tickers";
        public static string HistoryByCoinId(string id) => "coins/" + id + "/history";
        public static string MarketChartByCoinId(string id) => "coins/" + id + "/market_chart";
        
    }
}