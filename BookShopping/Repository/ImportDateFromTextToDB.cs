using System;
using System.Collections;
using System.Collections.Generic;
using BookShopping.Model;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BookShopping.Repository
{
    public class ImportDateFromTextToDB
    { 
        public ImportDateFromTextToDB()
        {
            ImportPersonFromTextData();
            ImportBookFromTextData();
        }

        public static string PasswordHashing(string password)
        {
            byte[] salt = new byte[128 / 8];
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
        public static void ImportPersonFromTextData()
        {
            using (StreamReader sr = new StreamReader(@"/home/tiran/RiderProjects/BookShopping/BookShopping/Source/fake-persons.txt", Encoding.Default))
            {
                List<Person> persons = new List<Person>();
                
                while (!sr.EndOfStream)
                {
                    Person person = new Person();
                    
                    string userDateString = sr.ReadLine();
                    try
                    {
                        if (userDateString != null)
                        {
                            string[] parameters = userDateString.Split(',');
                            person.Gender = parameters[0];
                            person.Lastname = parameters[1];
                            person.Surname = parameters[2];
                            person.StreetAddress = parameters[3];
                            person.ZipCode = parameters[4];
                            person.City = parameters[5];
                            person.Email = parameters[6];
                            person.Username = parameters[7];
                            person.Password = PasswordHashing(parameters[8]);
                            person.Birthday = DateTime.Parse(parameters[9], new CultureInfo("en-US", true));
                        }
                        persons.Add(person);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                    
                }
                foreach (var VARIABLE in persons)
                {
                    AddPersonToDb(VARIABLE);
                }
            }
        }
        public static void ImportBookFromTextData()
        {
            string path = @"/home/tiran/RiderProjects/BookShopping/BookShopping/Source/spiegel-bestseller-v2.txt";
            List<Category> categories = new List<Category>();
            List<Format> formats = new List<Format>();
            List<Book> books = new List<Book>();
            int key = 0;
            using (StreamReader sr =new StreamReader(path,Encoding.Default))
            {
                string bookstring;
                while ((bookstring=sr.ReadLine()) != null)
                {
                    string [] newBooks = bookstring.Split(";");
                    Category category = new Category()
                    {
                        CategoryName = newBooks[0].Split(":")[1],
                    }; 
                    categories.Add(category);
                    Format format = new Format()
                    {
                        FormatName = newBooks[1].Split(":")[1],
                    };
                    formats.Add(format);
                    Hashtable temp = new Hashtable();
                    int filds = 7;
                    int bookcount = 0;
                    for (int i = 1; i < newBooks.Length; i++)
                    {
                        if (bookcount % filds == 0)
                        {
                            Book book = new Book();
                            if (temp.Count != 0)
                            {
                                book.Category = newBooks[0].Split(":")[1];
                                book.Format = newBooks[1].Split(":")[1];
                                book.Author = temp["AUTHOR"]?.ToString();
                                book.Titel = temp["TITLE"]?.ToString();
                                book.Ean = temp["EAN"]?.ToString();
                                book.Publisher = temp["PUBLISHER"]?.ToString();
                                book.Data = temp["DATE"]?.ToString();
                                book.Prise = temp["PRICE"]?.ToString();
                                
                                bookcount = 0;
                                temp.Clear();
                                books.Add(book);
                            }
                            bookcount++;
                        }
                        else
                        {
                            
                            string keys = "";
                            string temporal = "";
                            if (format.FormatName == "DVD" && bookcount == 5)
                            {
                                filds = 6;
                                keys = "DATE";
                                temporal = null;
                            }
                            else
                            {
                                keys = newBooks[i].Split(":")[0];
                                temporal = newBooks[i].Split(":")[1];
                            }
                            temp.Add(keys,temporal);
                            bookcount++;
                        }
                    }
                }
            }

            foreach (var VARIABLE in books)
            {
                AddBooksToDb(VARIABLE);
            }
        }
        
        public static void AddPersonToDb(Person person)
        {
            using (var database = new PersonsEntitys())
            {
                database.Add(person);
                database.SaveChanges();
            }
        }
        public static void AddBooksToDb(Book book)
        {
            using (var database = new BooksEntitys())
            {
                database.Add(book);
                database.SaveChanges();
            }
        }
    }
}