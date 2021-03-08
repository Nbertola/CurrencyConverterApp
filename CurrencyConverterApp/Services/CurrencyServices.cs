using CurrencyConverterApp.Data;
using CurrencyConverterApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            //List<Currency> Lista =   new List<Currency>();
            //Lista.Add(new Currency("Pesos", 1));
            //Lista.Add(new Currency("Dolares", 2));
            //Lista.Add(new Currency("Euro", 3));

            //_dataContext.Add(Lista);
            var Lista =_dataContext.Currency.ToList();

            return Lista;
                    }

        public string LoadCurrency()
        {


            //List<string> Lista = new List<string>();
            //Lista.Add("Pesos");
            //Lista.Add("Dolares");
            //Lista.Add("Euro");
            //_dataContext.Add(Lista);

            var dato1 = new Currency(1,"Pesos");
            var dato2 = new Currency(2,"Dolares");
            var dato3 = new Currency(3,"Euro");
            _dataContext.Currency.Add(dato1);
            _dataContext.Currency.Add(dato2);
            _dataContext.Currency.Add(dato3);

                       
            _dataContext.SaveChanges();

            return "Load Succesfull!!!";
        }

        public string CreateCurrency(CurrencyRequestDTO request)
        {

            var dato1 = new Currency(request.CurrencyNumber, request.Description) { };
            _dataContext.Currency.Add(dato1);
            _dataContext.SaveChanges();

           return "Load Succesfull!!!";
        }


    }



}
