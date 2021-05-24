using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverterApp.Data;
using CurrencyConverterApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
//using Microsoft.Extensions.Logging;

namespace CurrencyConverterApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        public CurrencyController(DataContext dataContext, IConfiguration configuration/*,ILogger logger*/)
        {
            _dataContext = dataContext;
            Configuration = configuration;
            //_logger = logger;

            _logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo
            .SQLite(
            //connectionString: Configuration.GetConnectionString("Sqllite"),
            sqliteDbPath: "basesqllite.db"
             //tableName: "Log"

             )
            .CreateLogger();

        }


        public IConfiguration Configuration { get; }



        private readonly ILogger  _logger;

        private readonly DataContext _dataContext;


        

        [HttpPost("CreateCurrenciesFromList")]
        public List<string> CreateCurrencies()
        {

            

            var createcurrencies = new CurrencyServices(_dataContext) ;
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
        public List<Currencies> GetAllCurrencies()
        {
            var load = new CurrencyServices(_dataContext);

            
            var ipremote = HttpContext.Connection.RemoteIpAddress;
            var resultMessage = $"Consulto Currencies { ipremote}";
            _logger.Information(resultMessage);
            return load.GetAllCurrency();
            

        }


        [HttpGet("GetAllCurrencyQuotes")]
        public List<CurrencyQuoteResultDTO> GetAllCurrencyQuotes()
        {

            //var factory = new LoggerFactory();
            //var logger = new Logger<CurrencyController>(factory);
            //var resultMessage = "Hola";
            var load = new CurrencyQuoteServices(_dataContext);

            
            return load.GetAllCurrencyQuotes();
            
            
        }


        [HttpGet("GetCurrencyQuotebyDate")]
        public List<CurrencyQuotes> GetCurrencyQuoteByDate(int Currencyid, DateTime data)
        {
            var load = new CurrencyQuoteServices(_dataContext);
            return load.GetCurrencyQuoteByDate(Currencyid, data);
            
        }

        [HttpGet("GetCurrencyQuoteValue")]
        public decimal GetCurrencyQuoteValue([FromQuery]string CurrencyIsoRequest, decimal CurrencyValue, DateTime Data, string CurrencyIsoResult )
        {
            var resultado = new CurrencyQuoteServices(_dataContext);
            return resultado.GetCurrencyQuoteValue(CurrencyIsoRequest, Data, CurrencyIsoResult, CurrencyValue);
            
        }

    }






}

