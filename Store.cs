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

            products.Add(new Product("Sausage", 69.00m));
            products.Add(new Product("Coffee", 39.90m));
            products.Add(new Product("Apple", 9.50m));
            products.Add(new Product("Kebabpizza", 120.00m));
            products.Add(new Product("Wedding cake", 420.00m));
            products.Add(new Product("Snus", 123456.90m));

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
            SaveCustomersToFile();
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void RegisterNew()
        {
            Clear();
            WriteLine("<< Register new account >>");
            Write("Enter your username: ");
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

            WriteLine("Choose your customer type: 1. Gold, 2. Silver, 3. Bronze");
            int customerTypeChoice = int.Parse(ReadLine());

            Customer newCustomer = new Customer(name, password);
            switch (customerTypeChoice)
            {
                case 1:
                    newCustomer = new GoldCustomer(name, password);
                    break;
                case 2:
                    newCustomer = new SilverCustomer(name, password);
                    break;
                case 3:
                    newCustomer = new BronzeCustomer(name, password);
                    break;
                default:
                    WriteLine("Invalid choice, defaulting to Bronze.");
                    break;
            }
            customers.Add(newCustomer);

            WriteLine("Account successfully created!");
            LogIn();
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
                    RunMainMenu();
                    return;
                }
            }

            Write("Enter your password: ");
            string password = ReadLine();

            if (customer.VerifyPW(password))
            {
                WriteLine("Successfully logged in!");
                LoggedInMenu(customer);
            }
            else
            {
                WriteLine("Incorrect password. Please try again.");
                WriteLine("Press any key to return to main menu...");
                ReadKey(true);
                RunMainMenu();
            }
        }

        private void LoggedInMenu(Customer customer)
        {
            string promt = $"Welcome";
            string[] options = { "Shop", "View Cart", "Checkout", "Log out" };

            Menu loggedInMenu = new Menu(promt, options);

            while (true)
            {
                int selectedIndex = loggedInMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Shop(customer);
                        break;
                    case 1:
                        ViewCart(customer);
                        break;
                    case 2:
                        Checkout(customer);
                        break;
                    case 3:
                        WriteLine("Logging out...");
                        RunMainMenu();
                        return;
                }
            }
        }

        private void Shop(Customer customer)
        {
            Clear();
            WriteLine("<< Shop >>");

            for (int i = 0; i < products.Count; i++)
            {
                WriteLine($"{i + 1}. {products[i]}");
            }

            WriteLine("Enter the number of the product to add it to your cart: ");
            int choice = int.Parse(ReadLine()) - 1;

            if (choice >= 0 && choice < products.Count)
            {
                Product selectedProduct = products[choice];
                customer.Cart.Add(selectedProduct);
                WriteLine($"{selectedProduct.Name} added to your cart.");
            }
            else
            {
                WriteLine("That is not an option.");
            }

            WriteLine("Press any key to return to the main menu...");
            ReadKey(true);
        }

        private void ViewCart(Customer customer)
        {
            Clear();
            WriteLine("<< Your Cart >>");

            if (customer.Cart.Count == 0)
            {
                WriteLine("Your cart is empty.");
            }
            else
            {
                decimal total = 0;
                foreach (Product product in customer.Cart)
                {
                    WriteLine(product.Name);
                    total += product.Price;
                }
                WriteLine($"\nTotal: {total:C}");
            }

            WriteLine("Press any key to return to the main menu...");
            ReadKey(true);
        }

        private void Checkout(Customer loggedInCustomer)
        {
            Clear();
            WriteLine("<< Checkout >>");

            if (loggedInCustomer.Cart.Count == 0)
            {
                WriteLine("Your cart is empty.");
            }
            else
            {
                decimal total = loggedInCustomer.GetTotalPrice();
                WriteLine($"Your total is {total:C}");
                WriteLine("Press any key to confirm checkout...");
                ReadKey(true);
                loggedInCustomer.Cart.Clear();
                WriteLine("Checkout complete! Your cart has been cleared, have a nice day!");
            }

            WriteLine("Press any key to return to the main menu...");
            ReadKey(true);
        }

        private void SaveCustomersToFile()
        {
            using (StreamWriter writer = new StreamWriter("customers.txt"))
            {
                foreach (var customer in customers)
                {
                    writer.WriteLine(customer.GetCustomerInfo());
                }
            }
        }
    }
}
