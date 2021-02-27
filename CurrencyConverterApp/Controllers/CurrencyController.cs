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
            ///TODO: no me mientas, esta variable no contiene un objeto 'load'
            var load = new CurrencyServices(_dataContext);
            var result = load.LoadCurrency();
            return result;
        }


        [HttpPut("LoadCurrencieQuotes")]
        public string LoadCurrencieQuotes()
        {
            ///TODO: no me mientas, esta variable no contiene un objeto 'load'
            var load = new CurrencyQuoteServices(_dataContext);
            var result = load.LoadCurrencieQuotes();
            return result;
        }


        [HttpGet("GetAllCurrencies")]
        public List<Currency> GetAllCurrencies()
        {
            ///TODO: no me mientas, esta variable no contiene un 'resultado'
            var resultado = new CurrencyServices(_dataContext);
            return resultado.GetAllCurrency();
        }


        [HttpGet("GetAllCurrencyQuote")]
        public List<CurrencyQuote> GetAllCurrencyQuote()
        {
            ///TODO: A mi no me engañas chinguenguencha, esta variable no contiene un resultado
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetAllCurrencyQuote();
        }


        [HttpGet("GetCurrencyQuotebyDate")]
        public List<CurrencyQuote> GetCurrencyQuoteByDate(int Currencyid, DateTime data)
        {
            ///TODO: A mi no me engañas chinguenguencha, esta variable no contiene un resultado
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteByDate(Currencyid, data);
        }

        [HttpGet("GetCurrencyQuoteValue")]
        ///TODO: jaja ponete de acuerdo con la capital letter de las variables, o mayúscula o minuscula, (minuscula igual..)
        public decimal GetCurrencyQuoteValue([FromQuery] int Currencyid, decimal CurrencyValue, DateTime data, int CurrencyidResult)
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteValue(Currencyid, data, CurrencyidResult, CurrencyValue);
        }

    }
}

