using System;
using System.Collections.Generic;

namespace Labb_2
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            Store myStore = new Store();
            myStore.Start();

            products.Add(new Product("test", 123));
            products.Add(new Product("test", 123));
            products.Add(new Product("test", 123));
            products.Add(new Product("test", 123));
            products.Add(new Product("test", 123));


            customers.Add(new Customer("Knatte", "123"));
            customers.Add(new Customer("Fnatte", "321"));
            customers.Add(new Customer("Tjatte", "213"));

        }
    }
}
