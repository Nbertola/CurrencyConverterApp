using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApp
{
    public class CurrencyQuotes
    {
        public int CurrenciesId { get; set; }

        public int CurrencyQuotesId { get; set; }
        public DateTime CurrencyQuoteDate { get; set; }
        public decimal Valor { get; set; }

        public virtual Currencies Currencies { get; set; }

        public CurrencyQuotes(decimal valor, DateTime currencyquotedate, int currencynumber)
        {
            CurrenciesId = currencynumber;
            CurrencyQuoteDate = currencyquotedate;
            Valor = valor;
        }

        public CurrencyQuotes(int currenciesId, int currencyQuotesId, DateTime currencyQuoteDate, decimal valor)
        {
            CurrenciesId = currenciesId;
            CurrencyQuotesId = currencyQuotesId;
            CurrencyQuoteDate = currencyQuoteDate;
            Valor = valor;
        }
    }


}
