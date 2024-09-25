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
        public void Start() 
        {
            /*           WriteLine("Log in");

                       WriteLine("Register new account");
            */

            string prompt = "Welcome to Jesper's Essentials! What would you like to do? Please navigate your options using Up & Down arrows and select with Enter/Return.";
            string[] options = { "Log in", "Register new account", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();


            ReadKey(true);
        }
    }
}
