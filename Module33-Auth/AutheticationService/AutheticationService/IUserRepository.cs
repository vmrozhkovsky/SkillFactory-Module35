using AutheticationService.Controllers;

namespace AutheticationService;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User GetUserByLogin(string userLogin);
}