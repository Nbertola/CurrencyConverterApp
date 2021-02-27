namespace CurrencyConverterApp
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Description { get; set; }

        public int CurrencyNumber { get; set; }

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
