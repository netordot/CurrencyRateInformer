namespace CurrencyApi.Domain.Models
{
    public class Currency
    {
        const int CURRENCY_CODE_LETTERS = 3;
        private Currency(Guid id, string code, string fullname, string sign)
        {
            Id = id;
            Code = code;
            FullName = fullname;
            Sign = sign;

        }

        public Guid Id { get;  }

        public string Code { get;  }

        public string FullName { get;  }

        public string Sign { get;  }

        public static (Currency currency, string Error) Create(Guid id, string code, string fullname, string sign)
        {
            var newCurrency = new Currency(id, code, fullname, sign);

            var error = string.Empty;

            if (string.IsNullOrEmpty(fullname))
            {
                error = "The name of the currency should not be empty";
            }

            if(code.Length != CURRENCY_CODE_LETTERS)
            {
                error = "The code of the currency should contain only 3 symbols";
            }

            return (newCurrency, error);

        }

    }
}
