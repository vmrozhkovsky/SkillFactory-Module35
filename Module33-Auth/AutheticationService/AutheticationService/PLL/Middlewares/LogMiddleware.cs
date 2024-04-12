namespace AutheticationService;

public class LogMiddleware
{
    private readonly ILogger _logger;
    private readonly RequestDelegate _next;

    public LogMiddleware(RequestDelegate next, ILogger logger) 
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext) 
    {
        //_logger.WriteEvent("Test");
        _logger.WriteEvent("Remote IP - " + httpContext.Connection.RemoteIpAddress.ToString());
        await _next(httpContext);
    }
}
