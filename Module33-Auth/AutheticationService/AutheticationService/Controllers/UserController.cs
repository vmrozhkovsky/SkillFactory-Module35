using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutheticationService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private ILogger _logger;
    private IMapper _mapper;
    private IUserRepository _userRepository;
    public UserController(ILogger logger, IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _logger = logger;
        _mapper = mapper;

        logger.WriteEvent("Сообщение о событии в программе");
        logger.WriteError("Сообщение об ошибки в программе");
        

    }

    [HttpGet]
    public User GetUser()
    {
        return new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "Иван",
            LastName = "Иванов",
            Email = "ivan@gmail.com",
            Password = "11111122222qq",
            Login = "ivanov"
        };
    }

    [HttpGet]
    [Route("viewmodel")]
    public UserViewModel GetUserViewModel()
    {
        User user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "Иван",
            LastName = "Иванов",
            Email = "ivan@gmail.com",
            Password = "11111122222qq",
            Login = "ivanov"
        };
        var userViewModel = _mapper.Map<UserViewModel>(User);

        return userViewModel;
    }

    [HttpGet]
    [Route("getallusers")]
    public IEnumerable<User> GetAll()
    {
        var users = _userRepository.GetAllUsers();
        return users;
    }
    
    [HttpGet]
    [Route("getuserbylogin")]
    public User GetUserByLogin()
    {
        Console.WriteLine("Введите логин пользователя:");
        string userLogin = Console.ReadLine();
        var user = _userRepository.GetUserByLogin(userLogin);
        return user;
    }
}