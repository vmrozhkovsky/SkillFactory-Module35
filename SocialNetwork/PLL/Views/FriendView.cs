using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using SocialNetwork.DAL.Entities;

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
            Console.WriteLine("Введите Email друга для удаления:");
            try
            {
                var userDeleteFriendData = new UserDeleteFriendData();
                userDeleteFriendData.UserId = user.Id;
                userDeleteFriendData.FriendEmail = Console.ReadLine();
                // userDeleteFriendData.FriendId = int.Parse(Console.ReadLine());
                userService.DeleteFriend(userDeleteFriendData);
                SuccessMessage.Show("Вы удалили пользователя из друзей!");
            }
            catch (FormatException)
            {
                AlertMessage.Show("Неверный ввод!");
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с таким Email не существует, либо его нет у вас в друзьях!");
            }
            catch(Exception)
            {
                AlertMessage.Show("Ошибка при удалении пользователя!");
            }
           
        }
    }
}
