using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace Labb_2
{
    public class CurrencyService
    {
        private static readonly HttpClient client = new HttpClient();

        private async Task<ExchangeRates> GetExchangeRatesAsync() 
        {
            string url = "https://api.currencyapi.com/v3/latest?apikey=cur_live_4Nv0XzB6XS0cOLwfFEA5XFvjCxT3KPb9hJZBHVLw";
            string json = await client.GetStringAsync(url);

            var rates = JsonSerializer.Deserialize<ExchangeRates>(json);
            return rates;
        }
    }

    public class ExchangeRates
    {
        public decimal EUR {  get; set; }
        public decimal USD { get; set; }
    }
}
