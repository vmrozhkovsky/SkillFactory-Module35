using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class UserDataUpdateView
    {
        UserService userService;
        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.Write("Ваше имя:");
            user.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия:");
            user.LastName = Console.ReadLine();

            Console.Write("Ссылка на фото:");
            user.Photo = Console.ReadLine();

            Console.Write("Ваш любимый фильм:");
            user.FavoriteMovie = Console.ReadLine();

            Console.Write("Ваша любимая книга:");
            user.FavoriteBook = Console.ReadLine();

            this.userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
