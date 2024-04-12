namespace AutheticationService;

public class Logger : ILogger
{
    private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

    private string logDirectory { get; set; }

    public Logger()
    {
        logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

        if (!Directory.Exists(logDirectory))
            Directory.CreateDirectory(logDirectory);
    }

    public void WriteEvent(string eventMessage)
    {
        _lock.EnterWriteLock();
        try
        {
            using (StreamWriter writer = new StreamWriter(logDirectory + "events.txt", append: true))
            {
                writer.WriteLine(eventMessage);
            }
        }
        finally
        {
            _lock.ExitWriteLock();
        }

    }

    public void WriteError(string errorMessage)
    {
        _lock.EnterWriteLock();
        try
        {
            using (StreamWriter writer = new StreamWriter(logDirectory + "errors.txt", append: true))
            {
                writer.WriteLine(errorMessage);
            }
        }
        finally
        {
            _lock.ExitWriteLock();
        }

    }
}