using NLog;

public class TicketsFile
{
    public string FilePath { get; set; }
    public List<Ticket> TicketList {get; set;}
    public List<Enhancement> EnhancementList {get; set;}
    public List<Task> TaskList {get; set;}
    private static NLog.Logger Logger = LogManager.Setup().LoadConfigurationFromFile(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    public TicketsFile(string filePath, string type)
    {

    }
}