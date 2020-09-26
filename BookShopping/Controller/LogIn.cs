using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BookShopping.Model;
using BookShopping.Repository;
using ExceptionAndInfo = BookShopping.Service.ExceptionAndInfo;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BookShopping.Controller
{
    public class LogIn: ExceptionAndInfo

    {
    private static string Username;
    private static string Password;
    private static int value;
    private static ImportDateFromTextToDB _connection;
    internal LogIn()
    {
        Console.WriteLine("\n***Nun sollen Sie Ihre username und password eingeben***\n");
        UserDate();
    }

    private static void UserDate()
    {
        
        try
        {
            /*Dashboard(new PersonDBEntitys().Persons.FirstOrDefault(
                s => s.Username == InputUserName() && 
                            s.Password == ImportDateFromTextToDB.PasswordHashing(InputPassword())));*/
            Dashboard(new PersonsEntitys().Persons.FirstOrDefault(
                s => s.Username == "Fromork" && s.Password == ImportDateFromTextToDB.PasswordHashing("aeth7auKo8")));
        }
        catch (NullReferenceException e)
        {
            value++;
            InvalidUserPasswordName();
            if (value>4)
            {
                ShowMainMenuException(value);
            }
            UserDate();
        }
    }
 
    private static void Dashboard(Person person)
    {
        DashboardMenu(person.Gender,person.Lastname,person.Surname);
        SwitchToMenu();

    }

    private static void SwitchToMenu()
    {
        int read = 0;
        while (!Int32.TryParse(Console.ReadLine(),out read))
        {
            value++;
            if (value < 4)
            {
                InvalidMenu();
                SwitchToMenu();
            }
            else
            {
                ShowMainMenuException(value);   
            }
        }
        switch (read)
        {
            case 1:
                new SearchBook();
                break;
            default:
                break;
        } 
    }

    private static void UserInfo()
    {

    }

    private static void ShoppingCardInfo()
    {

    }

    private static void StartShop()
    {
        
    }

    }
}