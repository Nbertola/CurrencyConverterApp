using CurrencyConverterApp.Data;
using CurrencyConverterApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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

                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(1, new DateTime(2020, 01, 01), 1));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(1, new DateTime(2020, 01, 02), 1));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(1, new DateTime(2020, 01, 03), 1));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(1, new DateTime(2020, 01, 04), 1));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(150, new DateTime(2020, 01, 01), 2));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(160, new DateTime(2020, 01, 02), 2));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(170, new DateTime(2020, 01, 03), 2));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(180, new DateTime(2020, 01, 04), 2));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(200, new DateTime(2020, 01, 01), 3));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(210, new DateTime(2020, 01, 02), 3));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(220, new DateTime(2020, 01, 03), 3));
                _dataContext.CurrencyQuotes.Add(new CurrencyQuotes(230, new DateTime(2020, 01, 04), 3));

            _dataContext.SaveChanges();
            
            return "Load Succesfull!!!";

            }

        public List<CurrencyQuoteResultDTO> GetAllCurrencyQuotes()
            {

            var Lista = _dataContext.CurrencyQuotes
                .Include(c => c.Currencies )
                .ToList();

            var result = new List<CurrencyQuoteResultDTO>();

            foreach (var currencyquoteslist in Lista)
            {
                var currencyquote = new CurrencyQuoteResultDTO(currencyquoteslist.Currencies.Description,currencyquoteslist.Currencies.CurrencyISO4217, currencyquoteslist.CurrencyQuoteDate, currencyquoteslist.Valor);
                
                result.Add(currencyquote);

            }

            return result;

            
            }

        public List<CurrencyQuotes> GetCurrencyQuoteByDate(int CurrenciesId, DateTime data)
        {

            //result.FindAll(x => x.CurrencyId == currencyid);

            //result.Where(x => x.CurrencyId == currencyid);

            //return result.Where(x => x.CurrencyId == currencyid);
            //x => x.CurrencyQuoteDate == data

            //****filtra por Currencyid



            var result = _dataContext.CurrencyQuotes.Where(x => x.CurrenciesId == CurrenciesId && x.CurrencyQuoteDate == data).ToList();


            //            var resultA = result.FindAll(x => x.CurrencyNumber == Currencynumber);

            //**** filtra por CurrencyQuoteDate

            //var resultB = resultA.FindAll(x => x.CurrencyQuoteDate == data);

            return result;

        }

        public decimal GetCurrencyQuoteValue(string currencyisorequest, DateTime data, string currencyisoresult, decimal CurrencyValue)
        {
            var currencyresult = _dataContext.CurrencyQuotes
                                 .Include(x => x.Currencies)
                                 .Where(x => x.Currencies.CurrencyISO4217 == currencyisoresult && x.CurrencyQuoteDate == data).FirstOrDefault();

            var currencyinform = _dataContext.CurrencyQuotes
                                .Include(x => x.Currencies)
                                .Where(x => x.Currencies.CurrencyISO4217 == currencyisorequest && x.CurrencyQuoteDate == data).FirstOrDefault();

            if (currencyresult !=null && currencyinform !=null) 
            {
                return ((CurrencyValue * currencyinform.Valor) / currencyresult.Valor);
            }
            else
            {
                return 0;
            }



        }



    }
}
