namespace CurrencyApi.Domain.Models
{
    public class Currency
    {

        private Currency(Guid id, string code, string fullname, string sign)
        {
            Id = id;
            Code = code;
            FullName = fullname;
            Sign = sign;

        }

        public Guid Id { get; set; }

        public string Code { get; set; }

        public string FullName { get; set; }

        public string Sign { get; set; }



        public static (Currency currency, string Error) Create(Guid id, string code, string fullname, string sign)
        {
            var newCurrency = new Currency(id, code, fullname, sign);

            var error = string.Empty;

            if (string.IsNullOrEmpty(fullname))
            {
                error = "The name of the currency should not be empty";
            }

            return (newCurrency, error);

        }

    }
}
