using Microsoft.AspNetCore.Mvc;

namespace AutheticationService.Controllers;

[ApiController]
[Route("[controller]")]
public class LoggerController : ControllerBase
{
    private readonly ILogger _logger;

    public LoggerController(ILogger logger)
    {
        _logger = logger;
        logger.WriteError("Error");
        logger.WriteEvent("Event");
    }

    [HttpGet]
    public User GetUser()
    {
        return new User()
        {
            FirstName = "Владимир",
            Id = Guid.NewGuid(),
            Login = "vova"

        };
    }
}