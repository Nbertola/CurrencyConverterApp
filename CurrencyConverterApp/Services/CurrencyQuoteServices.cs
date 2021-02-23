using CurrencyConverterApp.Data;
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

            var Lista = _dataContext.CurrencyQuote.ToList();

            return Lista;

            
            }

        public List<CurrencyQuote> GetCurrencyQuoteByDate(int Currencynumber, DateTime data)
        {

            //result.FindAll(x => x.CurrencyId == currencyid);

            //result.Where(x => x.CurrencyId == currencyid);

            //return result.Where(x => x.CurrencyId == currencyid);
            //x => x.CurrencyQuoteDate == data

            //****filtra por Currencyid



            var result = _dataContext.CurrencyQuote.Where(x => x.CurrencyNumber == Currencynumber && x.CurrencyQuoteDate == data).ToList();


            //            var resultA = result.FindAll(x => x.CurrencyNumber == Currencynumber);

            //**** filtra por CurrencyQuoteDate

            //var resultB = resultA.FindAll(x => x.CurrencyQuoteDate == data);

            return result;

        }

        public decimal GetCurrencyQuoteValue(int currencynumber, DateTime data, int currencyidResult, decimal CurrencyValue)
        {
            //List<CurrencyQuote> currencyresult = new List<CurrencyQuote>();

            //currencyresult.Add(new CurrencyQuote(1, new DateTime(2020, 01, 01), 1));
            //currencyresult.Add(new CurrencyQuote(1, new DateTime(2020, 01, 02), 1));
            //currencyresult.Add(new CurrencyQuote(1, new DateTime(2020, 01, 03), 1));
            //currencyresult.Add(new CurrencyQuote(1, new DateTime(2020, 01, 04), 1));
            //currencyresult.Add(new CurrencyQuote(150, new DateTime(2020, 01, 01), 2));
            //currencyresult.Add(new CurrencyQuote(160, new DateTime(2020, 01, 02), 2));
            //currencyresult.Add(new CurrencyQuote(170, new DateTime(2020, 01, 03), 2));
            //currencyresult.Add(new CurrencyQuote(180, new DateTime(2020, 01, 04), 2));
            //currencyresult.Add(new CurrencyQuote(200, new DateTime(2020, 01, 01), 3));
            //currencyresult.Add(new CurrencyQuote(210, new DateTime(2020, 01, 02), 3));
            //currencyresult.Add(new CurrencyQuote(220, new DateTime(2020, 01, 03), 3));
            //currencyresult.Add(new CurrencyQuote(230, new DateTime(2020, 01, 04), 3));


            //100 *      230/150

            //75       200
            //150

            //100      150
            //       200

            //100         150
            //            1


            //var currencyresultA = currencyresult.Where(x => x.CurrencyNumber == currencyidResult);

            //var currencyresultB = currencyresultA.Where(y => y.CurrencyQuoteDate == data).FirstOrDefault();

            var currencyresult = _dataContext.CurrencyQuote.Where(x => x.CurrencyNumber == currencyidResult && x.CurrencyQuoteDate == data).FirstOrDefault();


            //var currencyinformA = currencyresult.Where(x => x.CurrencyNumber == currencynumber);

            //var currencyinformB = currencyinformA.Where(y => y.CurrencyQuoteDate == data).FirstOrDefault();

            var currencyinform = _dataContext.CurrencyQuote.Where(x => x.CurrencyNumber == currencynumber && x.CurrencyQuoteDate == data).FirstOrDefault();


            return ((CurrencyValue * currencyinform.Valor) / currencyresult.Valor);

            //return ((CurrencyValue * currencyinformB.Valor)/ currencyresultB.Valor);

            //return ((CurrencyValue* currencyresultB.Valor) / currencyinformB.Valor);



        }



    }
}
