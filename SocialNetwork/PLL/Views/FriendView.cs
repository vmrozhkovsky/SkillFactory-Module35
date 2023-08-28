using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class FriendView
    {
        UserService userService;
        public FriendView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show(User user)
        {
            try
            {
                var userAddingFriendData = new UserAddingFriendData();

                Console.WriteLine("Введите Email пользователя, которого хотите добавить в друзья:\n");

                userAddingFriendData.FriendEmail = Console.ReadLine();
                userAddingFriendData.UserId = user.Id;

                userService.AddFriend(userAddingFriendData);

                SuccessMessage.Show("Вы добавили пользователя в друзья!");
            }

            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с таким Email не существует!");
            }
            
            catch(Exception)
            {
                AlertMessage.Show("Ошибка при добавлении пользователя в друзья!");
            }
 
        }

        public void Delete(User user)
        {
            Console.WriteLine("Введите id друга для удаления:");
            try
            {
                var userDeleteFriendData = new UserDeleteFriendData();
                userDeleteFriendData.FriendId = int.Parse(Console.ReadLine());
                userService.DeleteFriend(userDeleteFriendData);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный ввод!");
                throw;
            }
           
        }
    }
}
