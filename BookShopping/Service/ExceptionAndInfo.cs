using System;
using System.Runtime.InteropServices;
using System.Security;
using BookShopping.Controller;

namespace BookShopping.Service
{
    public class ExceptionAndInfo : Exception
    {
        public static void exit()
        {
            Environment.Exit(-1);
        }
        #region MeinMenuRegion

        public void Titel()
        {
            Console.WriteLine("*** Buch kaufen ***\n");
        }

        public void MenuText()
        {
            Console.WriteLine("Damit Sie ein Buch online kaufen können, sollen Sie sich einlogen\n");
            
            Console.WriteLine("1. Einlogen");
            Console.WriteLine("2. Buch finden nach ...");
            Console.WriteLine("3. Sich über das Program mehr informiren");
            Console.WriteLine("4. Das Programm abschliessen!");
        }
        public static void ShowMainMenuException(int value)
        {
            Console.WriteLine("Sie haben die Eingabewert "+ value +" Mal"+" nicht korrekt eingegeben!");
            Console.WriteLine("Deswegen brecht gerade das Program ab!!");
            exit();
        } 
        public void SwitchToMenuException(int menu, int value)
        {
            Console.WriteLine("Sie sollen 1 bis 4 eine Nummer eingeben!");
            Console.WriteLine($"Sie haben {menu} eingegeben, aber das in unserem System existiert nicht!\n");
            if (value > 3)
            {
                Console.WriteLine("Sie haben die Eingabewert "+ value +" Mal"+" nicht korrekt eingegeben!");
                Console.WriteLine("Deswegen brecht gerade das Program ab!!");
                exit();  
            }
        }

        #endregion

        #region Username und Pasword
        public static string InputUserName()
        {
            Console.Write("Username: ");
            return Console.ReadLine();
            
        }

        public static void InvalidUserPasswordName()
        {
            Console.WriteLine("Sie haben eine falsche Username oder Password eingetragen: Tragen Sie sie bitte erneut ein.");
        }

        public static string ToNormalString(SecureString input)
        {
            IntPtr strptr = Marshal.SecureStringToBSTR(input);
            string normal = Marshal.PtrToStringBSTR(strptr);
            Marshal.ZeroFreeBSTR(strptr);
            return normal;
        }
        public static string InputPassword()
        {
            
            Console.Write("Password: ");
            return ToNormalString(GetPassword());
        }
        public static SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000' ) // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return pwd;
        }
        

        #endregion

        #region Dashboard Menu

        public static void DashboardMenu(string gender, string Name, string Surname)
        {
            if (gender == "M")
            {
                gender = "Herr";
            }
            else
            { 
                gender = "Frau";
            }
            Console.WriteLine("\nHallo " + gender + " " + Name + " " + Surname);
            Console.WriteLine("\nWir freuen uns dass Sie wieder zurück sind \n");
            Console.WriteLine("1. Eine Angebot durchsuchen");
            Console.WriteLine("2. Warnekorb" + "("+ "0" + ")");
            Console.WriteLine("3. Kaufhistorie einsehen");
            Console.WriteLine("4. Peronliche Daten");
            Console.WriteLine("5. Ausloggen");      
        }

        public static void InvalidMenu()
        {
            Console.WriteLine("Sie sollen von 1 bis 4 eine Nummer eingeben!");
        }

        #endregion
       
        
    }
}