using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Labb_2
{
    internal class Store
    {
        static List<Customer> customers = new List<Customer>();
        static List<Product> products = new List<Product>();

        public Store() 
        {
            customers.Add(new Customer("Knatte", "123"));
            customers.Add(new Customer("Knatte", "123"));
            customers.Add(new Customer("Knatte", "123"));

            products.Add(new Product("test", 123));
            products.Add(new Product("test", 123));
            products.Add(new Product("test", 123));
            products.Add(new Product("test", 123));
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
        }

        private void LogIn() 
        {
            
        }
    }
}
