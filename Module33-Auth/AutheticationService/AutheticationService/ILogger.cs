namespace AutheticationService;

public interface ILogger
{
    public void WriteEvent(string eventMessage);
    public void WriteError(string errorMessage);
}