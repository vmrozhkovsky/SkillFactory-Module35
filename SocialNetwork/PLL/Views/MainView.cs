using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");
            Console.WriteLine("Показать всех (нажмите 3)");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.authenticationView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.registrationView.Show();
                        break;
                    }
                case "3":
                {
                    Program.userInfoView.ShowAll(Program.userRepository.FindAll());
                    break;
                }
            }
        }
    }
}
