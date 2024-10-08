using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }


        public Product(string name, decimal price) 
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            if (price < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(name));

            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price:C}";
        }
    }
}
