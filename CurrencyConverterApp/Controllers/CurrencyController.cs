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


        [HttpPut("LoadCurrencies")]
        public string LoadCurrencies()
        {
            var load = new CurrencyServices(_dataContext);
            var result = load.LoadCurrency();
            return result;
        }


        [HttpPut("PutCurrencies")]
        public void PutCurrencies([FromBody] CurrencyRequestDTO request)
        {
            
            var load = new CurrencyServices(_dataContext);

            

            load.CreateCurrency(request);

            //var result = load.LoadCurrency();
            //return result;
            //var response = Create(request);
     //       return response;
        
       // new Currency(request);

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
            //.ToArray();
        }


        [HttpGet("GetAllCurrencyQuote")]
        public List<CurrencyQuote> GetAllCurrencyQuote()
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetAllCurrencyQuote();
            //.ToArray();
        }


        [HttpGet("GetCurrencyQuotebyDate")]
        public List<CurrencyQuote> GetCurrencyQuoteByDate(int Currencyid, DateTime data)
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteByDate(Currencyid, data);
            //.ToArray();
        }

        [HttpGet("GetCurrencyQuoteValue")]
        public decimal GetCurrencyQuoteValue([FromQuery]int Currencyid, decimal CurrencyValue, DateTime data, int CurrencyidResult )
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteValue(Currencyid, data, CurrencyidResult, CurrencyValue);
            //.ToArray();
        }

    }






}

