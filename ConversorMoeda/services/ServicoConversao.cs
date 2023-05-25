using ConversorMoeda.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ConversorMoeda.services
{
    public class ServicoConversao
    {
        private class AllSymbols
        {
            public Dictionary<string, Currency> Symbols { get; set; }
        }

        public class Currency
        {
            public string Description { get; set; }
            public string Code { get; set; }
        }

        public class Convertion
        {
            public bool Success { get; set; }
            public Info? Info { get; set; }
            public double Result { get; set; }
        }

        public class Info
        {
            public double Rate { get; set; }
        }

        public static List<Currency>? GetAllCurrencies()
        {
            var client = new HttpClient();

            var json = client.GetStringAsync("https://api.exchangerate.host/symbols").Result;

            var deserializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var result = JsonSerializer.Deserialize<AllSymbols>(json, deserializeOptions);

            return result?.Symbols.Values.ToList<Currency>();
        }

        public static Convertion? Convert(string origem, string destino, double valor)
        {
            var url = $"https://api.exchangerate.host/convert?from={origem}&to={destino}&amount={valor.ToString("G", CultureInfo.CreateSpecificCulture("en-US"))}";

            var client = new HttpClient();

            var json = client.GetStringAsync(url).Result;

            var deserializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return JsonSerializer.Deserialize<Convertion>(json, deserializeOptions);
        }
    }
}
