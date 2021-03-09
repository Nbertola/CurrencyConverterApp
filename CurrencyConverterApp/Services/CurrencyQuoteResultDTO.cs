using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApp.Services
{
    public class CurrencyQuoteResultDTO
    {
        public CurrencyQuoteResultDTO(string description, string currencyISO4217, DateTime currencyQuoteDate, decimal valor)
        {
            Description = description;
            CurrencyISO4217 = currencyISO4217;
            CurrencyQuoteDate = currencyQuoteDate;
            Valor = valor;
        }

        public string Description { get; set; }

        public string CurrencyISO4217 { get; set; }

        public DateTime CurrencyQuoteDate { get; set; }
        public decimal Valor { get; set; }

    }
}
