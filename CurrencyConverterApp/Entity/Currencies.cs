using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApp
{
    public class Currencies
    {


        public int CurrenciesId { get; set; }
                   
        public string Description { get; set; }

        public string CurrencyISO4217 { get; set; }

        public Currencies( string description, int currenciesid)
        {
            currenciesid = CurrenciesId;
            Description = description;
        }

        public Currencies( string currencyiso4217, string description)
        {
            CurrencyISO4217 = currencyiso4217;
            Description = description;
            
        }

        public Currencies(int currenciesId, string description, string currencyISO4217)
        {
            CurrenciesId = currenciesId;
            Description = description;
            CurrencyISO4217 = currencyISO4217;
        }
    }
    

    
}
