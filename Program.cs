using System;
using System.Collections.Generic;

namespace Labb_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Store myStore = new Store();
                myStore.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
