using System.Security.Authentication;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        var userViewModel = _mapper.Map<UserViewModel>(user);

        return userViewModel;
    }

    [HttpGet]
    [Route("getallusers")]
    public IEnumerable<User> GetAll()
    {
        var users = _userRepository.GetAllUsers();
        return users;
    }
    
    [HttpPost]
    [Route("getuserbylogin")]
    public User GetUserByLogin(string userLogin)
    {
        // Console.WriteLine("Введите логин пользователя:");
        // string userLogin = Console.ReadLine();
        if (String.IsNullOrEmpty(userLogin))
            throw new ArgumentNullException("Запрос не корректен");

        var user = _userRepository.GetUserByLogin(userLogin);
        if (user is null)
            throw new AuthenticationException("Пользователь на найден");

        return user;
    }
    
    [HttpPost]
    [Route("authenticate")]
    public async Task<UserViewModel> Authenticate(string login, string password) 
    {
        if (String.IsNullOrEmpty(login) ||
            String.IsNullOrEmpty(password))
            throw new ArgumentNullException("Запрос не корректен");

        User user = _userRepository.GetUserByLogin(login);
        if (user is null)
            throw new AuthenticationException("Пользователь на найден");

        if (user.Password != password)
            throw new AuthenticationException("Введенный пароль не корректен");

        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AppCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
        return _mapper.Map < UserViewModel > (user);
    }
}