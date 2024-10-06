using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    public class ExchangeRates
    {
        public string Base {  get; set; }
        public Dictionary<string, decimal> Rates { get; set; }

        public decimal EUR => Rates["EUR"];
        public decimal USD => Rates["USD"];
    }
}
