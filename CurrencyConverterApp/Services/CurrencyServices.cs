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


        public List<Currencies> GetAllCurrency()
                    {

        
            return _dataContext.Currencies.ToList();
        }



        public List<string> LoadCurrency()
        {


            List<Currencies> lista =  new List<Currencies> ();


            var dato1 = new Currencies("ARS", "Pesos");
            var dato2 = new Currencies("USD", "Dolares");
            var dato3 = new Currencies("EUR", "Euro");

            lista.Add(dato1);
            lista.Add(dato2);
            lista.Add(dato3);
            
            var datadb = _dataContext.Currencies.ToList();

            List<String> listresult = new List<string>();

            foreach (var currenciesinsert in lista)
            {

                var exist = datadb.Where(x => x.CurrencyISO4217.Contains(currenciesinsert.CurrencyISO4217)).Count();
                

                if (exist==0)
                {
                    _dataContext.Currencies.Add(currenciesinsert);
                    _dataContext.SaveChanges();
                     listresult.Add($"{currenciesinsert.Description} inserted Succesfull!!!");
                }
                else
                {
                    listresult.Add($"{currenciesinsert.Description}  already exist!!!"); 
                }

            }

            return listresult.ToList();

        }

        public string CreateCurrency(CurrencyRequestDTO request)
        {

            var datadb = _dataContext.Currencies.ToList();
            var exist = datadb.Where(x => x.CurrencyISO4217.Contains(request.CurrencyISO4217)).Count();

            if (exist==0)
            {
                _dataContext.Currencies.Add(new Currencies(request.CurrencyISO4217, request.Description) { });
                _dataContext.SaveChanges();

                return $"{request.Description} insrted Succesfull!!!";
            }
            else
            {
                return $"{request.Description} already exist!!!";
            }
        }


    }



}
