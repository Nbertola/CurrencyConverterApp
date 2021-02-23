using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApp
{
    public class CurrencyQuote
    {
        public int CurrencyNumber { get; set; }

        public int CurrencyQuoteId { get; set; }
        public DateTime CurrencyQuoteDate { get; set; }
        public decimal Valor { get; set; }


       //public CurrencyQuote (decimal vValor, DateTime vData, int vCurrenyId)
       // { 
       //      Valor= vValor;
       //      CurrencyQuoteDate= vData;
       //      CurrencyId= vCurrenyId;
       //  }

        public CurrencyQuote(decimal valor, DateTime currencyQuoteDate, int currencynumber)
        {
            CurrencyNumber = currencynumber;
            CurrencyQuoteDate = currencyQuoteDate;
            Valor = valor;
        }

        public CurrencyQuote(int currencyNumber, int currencyQuoteId, DateTime currencyQuoteDate, decimal valor)
        {
            CurrencyNumber = currencyNumber;
            CurrencyQuoteId = currencyQuoteId;
            CurrencyQuoteDate = currencyQuoteDate;
            Valor = valor;
        }
    }


}
