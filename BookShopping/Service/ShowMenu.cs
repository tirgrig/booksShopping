using System;

using BookShopping.Controller;

namespace BookShopping.Service
{
    public class ShowMenu: ExceptionAndInfo
    {
        protected int value = 0;
        public ShowMenu()
        {
            Titel();
        }
        public ShowMenu(int value)
        {
            this.value = value;
        }

        public void ShowMainMenu()
        {
            MenuText();
            int read = 0;

            SwitchToMenu(InputValidation(read, 4, value));
        }

        public int InputValidation(int read, int menuLength, int Excepvalue)
        {
            value = Excepvalue;
            while (!Int32.TryParse(Console.ReadLine(),out read))
            {
                value++;
                if (value < menuLength)
                {
                    ShowMainMenu();
                }
                else
                {
                    ShowMainMenuException(value);   
                }
            }

            return read;
        }

        private void SwitchToMenu(int menu)
        {
            switch (menu)
            {
                case 1:
                    var logIn = new LogIn();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    value++;
                    SwitchToMenuException(menu,value);
                    ShowMainMenu();
                    break;
            }
        }
    }
}