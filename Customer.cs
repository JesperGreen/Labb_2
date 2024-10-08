using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    public class Customer
    {
     
        public string Name { get; }
        private string Password { get; }
        public List<Product> Cart { get; }

        public Customer(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));

            Name = name;
            Password = password;
            Cart = new List<Product>();
        }

        public bool VerifyPW(string password) 
        {
            return Password == password;
        }

        public override string ToString()
        {
            return $"Customer: {Name}, Cart: {Cart.Count} items, Total Price: {GetTotalPrice():C}";
        }

        public void AddToCart(Product product) 
        {
            Cart.Add(product);
        }

        public virtual decimal GetTotalPrice()
        {
            return Cart.Sum(x => x.Price);
        }

        public int GetTotalItems() 
        {
            return Cart.Count;
        }

        public string GetCustomerInfo() 
        {
            return $"{Name},{Password}";
        }
    }

    public class GoldCustomer : Customer 
    {
        public GoldCustomer(string name, string password) : base(name, password) 
        {
        
        }
        
        public override decimal GetTotalPrice()
        {
            decimal total = base.GetTotalPrice();
            return total * 0.85m;
        }
    }

    public class SilverCustomer : Customer
    {
        public SilverCustomer(string name, string password) : base(name, password)
        {

        }

        public override decimal GetTotalPrice()
        {
            decimal total = base.GetTotalPrice();
            return total * 0.90m;
        }
    }

    public class BronzeCustomer : Customer
    {
        public BronzeCustomer(string name, string password) : base(name, password)
        {

        }

        public override decimal GetTotalPrice()
        {
            decimal total = base.GetTotalPrice();
            return total * 0.95m;
        }
    }
}
