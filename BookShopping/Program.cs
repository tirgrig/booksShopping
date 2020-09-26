using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BookShopping.Model;
using BookShopping.Service;
using ConsoleTables;

namespace BookShopping
{
    class Program
    {
        /**
         * Hiermit wird eine Überschrift erstellt!
         */
        protected static ShowMenu showMenu = new ShowMenu();
        
        static void Main(string[] args)
        {
            showMenu.ShowMainMenu();
        }
    }
}