using System.Collections.Generic;

namespace CBR_Currency.Models
{
    public class CurrenciesResponse
    {
        public int Count { get; set; }

        public int Pages { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<Currency> Valute { get; set; }
    }
}
