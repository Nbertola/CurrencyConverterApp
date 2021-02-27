using CurrencyConverterApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverterApp
{
    public class CurrencyServices
    {

        private readonly DataContext _dataContext;

        public CurrencyServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<Currency> GetAllCurrency()
        {
            var Lista = _dataContext.Currency.ToList();

            return Lista;
        }


        public string LoadCurrency()
        {
            var dato1 = new Currency(1, "Pesos");
            var dato2 = new Currency(2, "Dolares");
            var dato3 = new Currency(3, "Euro");
            _dataContext.Currency.Add(dato1);
            _dataContext.Currency.Add(dato2);
            _dataContext.Currency.Add(dato3);


            _dataContext.SaveChanges();

            return "Load Succesfull!!!";
        }
    }
}
