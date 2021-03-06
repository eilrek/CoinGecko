using System.Linq;
using System.Threading.Tasks;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using Xunit;

namespace CoinGecko.Test
{
    public class ExchangesClientTests
    {
        private readonly ICoinGeckoClient _client;

        public ExchangesClientTests()
        {
            _client = CoinGeckoClient.Instance;
        }

        [Fact]
        public async Task Exchanges_Count_Greater_Than_Hundred()
        {
            var result = await _client.ExchangesClient.GetExchanges();
            Assert.True(result.Count > 100);
        }

        [Fact]
        public async Task Exchanges_Images_Url_Count_Must_Equal_Total_Count()
        {
            var result = await _client.ExchangesClient.GetExchanges();
            var notNullImages = result.Where(x => x.Image != "").ToList();
            var notNullUrl = result.Where(x => x.Url != "").ToList();
            Assert.Equal(result.Count, notNullImages.Count);
            Assert.Equal(result.Count, notNullUrl.Count);
        }

        [Fact]
        public async Task Exchanges_For_Bitfinex()
        {
            var result = await _client.ExchangesClient.GetExchangesByExchangeId("bitfinex");
            Assert.Equal("Bitfinex",result.Name);
        }

        [Fact]
        public async Task Exchanges_Bitfinex_Tickers()
        {
            var result = await _client.ExchangesClient.GetTickerByExchangeId("bitfinex");
            Assert.Equal("Bitfinex",result.Name);
        }

        [Fact]
        public async Task Exchanges_List_Not_Null()
        {
            var result = await _client.ExchangesClient.GetExchangesList();
            Assert.NotNull(result);
        }
    }
}