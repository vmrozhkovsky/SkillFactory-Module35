using AutheticationService.Controllers;

namespace AutheticationService;

public class UserRepository : IUserRepository
{
    List<User> userList = new List<User>();
    public UserRepository()
    {
        User user1 = new User()
        {
            Email = "user1@mail.ru",
            FirstName = "Иван",
            Id = Guid.NewGuid(),
            LastName = "Иванов",
            Login = "ivanov",
            Password = "ivanov"
        };
        User user2 = new User()
        {
            Email = "user2@mail.ru",
            FirstName = "Петр",
            Id = Guid.NewGuid(),
            LastName = "Петров",
            Login = "petrov",
            Password = "petrov"
        };
        User user3 = new User()
        {
            Email = "user3@mail.ru",
            FirstName = "Василий",
            Id = Guid.NewGuid(),
            LastName = "Васильев",
            Login = "vasilev",
            Password = "vasilev"
        };
        userList.Add(user1);
        userList.Add(user2);
        userList.Add(user3);
    }
    public IEnumerable<User> GetAllUsers()
    {
        return userList;
    }

    public User GetUserByLogin(string userLogin)
    {
        foreach (var user in userList)
        {
            if (user.Login == userLogin)
                return user;
        }

        return null;
    }
}