using System;
using System.ComponentModel.Design;

namespace BookShopping.Repository
{
    public class SearchBook 
    {
      public SearchBook()
        {
            Menu();
        }
      public void Menu()
      {
          Console.WriteLine("Um ein Buch zu finden, geben sie hier ein Suchwort ein. Oder einfach Enter drücken, um alle Bücher zu sehen.");
          if (Console.ReadLine()=="")
          {
             FindAllBooks(); 
          }
      }

      public void FindAllBooks()
      {
         ImportDateFromTextToDB.ImportBookFromTextData(); 
      }
      
    }
}