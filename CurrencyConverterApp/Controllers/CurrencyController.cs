using CurrencyConverterApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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


        [HttpPut("LoadCurrencies")]
        public string LoadCurrencies()
        {
            var load = new CurrencyServices(_dataContext);
            var result = load.LoadCurrency();
            return result;
        }


        [HttpPut("LoadCurrencieQuotes")]
        public string LoadCurrencieQuotes()
        {

            var load = new CurrencyQuoteServices(_dataContext);
            var result = load.LoadCurrencieQuotes();
            return result;
        }


        [HttpGet("GetAllCurrencies")]
        public List<Currency> GetAllCurrencies()
        {
            var resultado = new CurrencyServices(_dataContext);
            return resultado.GetAllCurrency();
        }


        [HttpGet("GetAllCurrencyQuote")]
        public List<CurrencyQuote> GetAllCurrencyQuote()
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetAllCurrencyQuote();
        }


        [HttpGet("GetCurrencyQuotebyDate")]
        public List<CurrencyQuote> GetCurrencyQuoteByDate(int Currencyid, DateTime data)
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteByDate(Currencyid, data);
        }

        [HttpGet("GetCurrencyQuoteValue")]
        public decimal GetCurrencyQuoteValue([FromQuery] int Currencyid, decimal CurrencyValue, DateTime data, int CurrencyidResult)
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteValue(Currencyid, data, CurrencyidResult, CurrencyValue);
        }

    }
}

