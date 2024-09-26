using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Labb_2
{
    internal class Store
    {
        private List<Customer> customers = new List<Customer>();
        private List<Product> products = new List<Product>();

        public Store() 
        {
            customers.Add(new Customer("Knatte", "123"));
            customers.Add(new Customer("Fnatte", "321"));
            customers.Add(new Customer("Tjatte", "213"));

            products.Add(new Product("test1", 123));
            products.Add(new Product("test2", 1234));
            products.Add(new Product("test3", 12345));
            products.Add(new Product("test4", 123456));
        }
        
        public void Start() 
        {
            Title = "Jesper's Essentials";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"
       _                           _         ______                    _   _       _     
      | |                         ( )       |  ____|                  | | (_)     | |    
      | | ___  ___ _ __   ___ _ __|/ ___    | |__   ___ ___  ___ _ __ | |_ _  __ _| |___ 
  _   | |/ _ \/ __| '_ \ / _ \ '__| / __|   |  __| / __/ __|/ _ \ '_ \| __| |/ _` | / __|
 | |__| |  __/\__ \ |_) |  __/ |    \__ \   | |____\__ \__ \  __/ | | | |_| | (_| | \__ \
  \____/ \___||___/ .__/ \___|_|    |___/   |______|___/___/\___|_| |_|\__|_|\__,_|_|___/
                  | |                                                                    
                  |_|                                                                    


Welcome to Jesper's Essentials! What would you like to do?
Please navigate your options using Up & Down arrows and select with Enter/Return.";
            string[] options = { "Log in", "Register new account", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex) 
            {
                case 0:
                    LogIn();
                    break;
                case 1:
                    RegisterNew();
                    break;
                case 2:
                    ExitStore();
                    break;
            }
        }
        private void ExitStore() 
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void RegisterNew() 
        {
            Clear();
            WriteLine("<< Register new account >>");
            Write("Enter your name: ");
            string name = ReadLine();

            if (customers.Exists(c => c.Name == name)) 
            {
                WriteLine("That username is already taken.");
                WriteLine("Press any key to return to the main menu.");
                ReadKey(true);
                return;
            }

            Write("Enter a password: ");
            string password = ReadLine();

            Customer newCustomer = new Customer(name, password);
            customers.Add(newCustomer);

            WriteLine("Account successfully created!");
            WriteLine("Press any key to return to the main menu...");
            ReadKey(true);

        }

        private void LogIn() 
        {
            Clear();
            WriteLine("<< Log In >>");
            Write("Enter your name: ");
            string name = ReadLine();

            Customer customer = customers.Find(c => c.Name == name);

            if (customer == null) 
            {
                WriteLine("Customer not found. Would you like to register a new account? (Y/N)");
                string choice = ReadLine().ToUpper();
                if (choice == "Y")
                {
                    RegisterNew();
                }
                else
                {
                    WriteLine("Returning to main menu...");
                    ReadKey(true);
                }
                return;
            }

            Write("Enter your password: ");
            string password = ReadLine();

            if (customer.VerifyPW(password))
            {
                WriteLine("Successfully logged in!");
            }
            else 
            {
                WriteLine("Incorrect password. Please try again.");
                ReadKey(true);
                LogIn();
            }
        }

        private void LoggedInMenu(Customer customer) 
        {
            string promt = $"Welcome";
            string[] options = {"Shop", "View Cart", "Checkout", "Log out"};
        }
    }
}
