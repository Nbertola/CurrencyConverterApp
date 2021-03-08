using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverterApp.Data;
using CurrencyConverterApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurrencyConverterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController
    {
        public CurrencyController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private readonly DataContext _dataContext;


        [HttpPost("CreateCurrenciesFromList")]
        public string CreateCurrencies()
        {
            var createcurrencies = new CurrencyServices(_dataContext);
            var result = createcurrencies.LoadCurrency();
            return result;
        }


        [HttpPost("CreateCurrency")]
        public string CreateCurrency([FromBody] CurrencyRequestDTO request)
        {
            
            var createcurrency = new CurrencyServices(_dataContext);
            return createcurrency.CreateCurrency(request);
            



        }



        [HttpPost("CreateCurrencieQuotesFromList")]
        public string CreateCurrencieQuotes()
        {

            var createcurrenciequotes = new CurrencyQuoteServices(_dataContext);
            return createcurrenciequotes.LoadCurrencieQuotes();
        }


        [HttpGet("GetAllCurrencies")]
        public List<Currency> GetAllCurrencies()
        {
            var load = new CurrencyServices(_dataContext);
            return load.GetAllCurrency();
              }


        [HttpGet("GetAllCurrencyQuotes")]
        public List<CurrencyQuote> GetAllCurrencyQuotes()
        {
            var load = new CurrencyQuoteServices(_dataContext);
            return load.GetAllCurrencyQuotes();
            
        }


        [HttpGet("GetCurrencyQuotebyDate")]
        public List<CurrencyQuote> GetCurrencyQuoteByDate(int Currencyid, DateTime data)
        {
            var load = new CurrencyQuoteServices(_dataContext);
            return load.GetCurrencyQuoteByDate(Currencyid, data);
            //.ToArray();
        }

        [HttpGet("GetCurrencyQuoteValue")]
        public decimal GetCurrencyQuoteValue([FromQuery]int CurrencyId, decimal CurrencyValue, DateTime Data, int CurrencyIdResult )
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteValue(CurrencyId, Data, CurrencyIdResult, CurrencyValue);
            
        }

    }






}

