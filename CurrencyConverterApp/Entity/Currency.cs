namespace CurrencyConverterApp
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Description { get; set; }

        public int CurrencyNumber { get; set; } ///Este dato cumpliría la misma funcionalidad del id, identificar un recurso, por qué se repite?
        ///Supongo es porque si se te repite data de 'currencyId' al no controlar duplicados con éste dato si identificas posta

        public Currency(string description, int currencyId)
        {
            CurrencyId = currencyId;
            Description = description;
        }

        public Currency(int currencynumber, string description)
        {
            CurrencyNumber = currencynumber;
            Description = description;

        }

    }
}
