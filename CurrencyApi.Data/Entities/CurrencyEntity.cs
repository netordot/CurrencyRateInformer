using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApi.Data.Entities
{
    public class CurrencyEntity
    {
        

        public Guid Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Sign { get; set; } = string.Empty;

        
    }
}
