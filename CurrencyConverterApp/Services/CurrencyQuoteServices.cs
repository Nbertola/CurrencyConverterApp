using CurrencyConverterApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverterApp
{
    public class CurrencyQuoteServices
    {
        private readonly DataContext _dataContext;

        public CurrencyQuoteServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public string LoadCurrencieQuotes()
        {
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(1, new DateTime(2020, 01, 01), 1));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(1, new DateTime(2020, 01, 02), 1));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(1, new DateTime(2020, 01, 03), 1));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(1, new DateTime(2020, 01, 04), 1));
            
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(150, new DateTime(2020, 01, 01), 2));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(160, new DateTime(2020, 01, 02), 2));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(170, new DateTime(2020, 01, 03), 2));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(180, new DateTime(2020, 01, 04), 2));
            
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(200, new DateTime(2020, 01, 01), 3));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(210, new DateTime(2020, 01, 02), 3));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(220, new DateTime(2020, 01, 03), 3));
            _dataContext.CurrencyQuote.Add(new CurrencyQuote(230, new DateTime(2020, 01, 04), 3));

            _dataContext.SaveChanges();

            return "Load Succesfull!!!";
        }


        public List<CurrencyQuote> GetAllCurrencyQuote()
        {
            ///TODO: Ver si se puede incluir el nombre de la moneda en la respuesta, no solo el id
            var Lista = _dataContext.CurrencyQuote.ToList();

            return Lista;
        }


        public List<CurrencyQuote> GetCurrencyQuoteByDate(int Currencynumber, DateTime data)
        {
            var result = _dataContext.CurrencyQuote
                .Where(x => x.CurrencyNumber == Currencynumber && x.CurrencyQuoteDate == data)
                .ToList();

            return result;
        }


        public decimal GetCurrencyQuoteValue(int currencynumber, DateTime data, int currencyidResult, decimal CurrencyValue)
        {
            ///TODO: Doble consulta al mismo dataset
            var currencyresult = _dataContext.CurrencyQuote
                .Where(x => x.CurrencyNumber == currencyidResult && x.CurrencyQuoteDate == data)
                .FirstOrDefault();

            var currencyinform = _dataContext.CurrencyQuote
                .Where(x => x.CurrencyNumber == currencynumber && x.CurrencyQuoteDate == data)
                .FirstOrDefault();
            
            ///TODO: Error, nullReferenceException cuando todavía no hay datos en la base
            return ((CurrencyValue * currencyinform.Valor) / currencyresult.Valor);
        }
    }
}
