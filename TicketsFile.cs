using NLog;
using NLog.Config;

public class TicketsFile
{
    public string TicketFilePath { get; set; }
    public string EnhancementFilePath { get; set; }
    public string TaskFilePath { get; set; }
    public List<Ticket> TicketList {get; set;}
    public List<Enhancement> EnhancementList {get; set;}
    public List<Task> TaskList {get; set;}
    private static NLog.Logger Logger = LogManager.Setup().LoadConfigurationFromFile(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    public TicketsFile(string ticketFilePath, string enhancementFilePath, string taskFilePath)
    {
        TicketList = new List<Ticket>();
        EnhancementList = new List<Enhancement>();
        TaskList = new List<Task>();

        TicketFilePath = ticketFilePath;
        EnhancementFilePath = enhancementFilePath;
        TaskFilePath = taskFilePath;

        long tid = 0;

        try
        {
            StreamReader tiSR = new StreamReader(ticketFilePath);
            while(!tiSR.EndOfStream)
            {
                Ticket ticket = new Ticket();
                string line = tiSR.ReadLine();
                string[] tiDetails = line.Split(',');
                tid = 0;
                bool firstline = long.TryParse(tiDetails[0], out tid);
                if(!firstline) continue;
                ticket.TicketID = tid;
                ticket.Summary = tiDetails[1];
                ticket.Status  = tiDetails[2];
                ticket.Priority  = tiDetails[3];
                ticket.Submitter  = tiDetails[4];
                ticket.Assigned  = tiDetails[5];
                ticket.Watching = tiDetails[6];
                ticket.Severity = tiDetails[7];

                TicketList.Add(ticket);
            }
            tiSR.Close();
            Logger.Info($"Ticket in file {TicketList.Count}");
        }
        catch (Exception ex)
        {
            Logger.Error($"Ticket error: {ex.Message}");
        }

        try
        {
            StreamReader enSR = new StreamReader(enhancementFilePath);
            while(!enSR.EndOfStream)
            {
                Enhancement enhancement = new Enhancement();
                string line = enSR.ReadLine();
                string[] enDetails = line.Split(',');
                tid = 0;
                bool firstline = long.TryParse(enDetails[0], out tid);
                if(!firstline) continue;
                enhancement.TicketID = tid;
                enhancement.Summary = enDetails[1];
                enhancement.Status  = enDetails[2];
                enhancement.Priority  = enDetails[3];
                enhancement.Submitter  = enDetails[4];
                enhancement.Assigned  = enDetails[5];
                enhancement.Watching = enDetails[6];
                enhancement.Software = enDetails[7];
                enhancement.Cost = enDetails[8];
                enhancement.Reason = enDetails[9];
                enhancement.Estimate = enDetails[10];

                EnhancementList.Add(enhancement);
            }
            enSR.Close();
            Logger.Info($"Enhancement in file {EnhancementList.Count}");
        }
        catch (Exception ex)
        {
            Logger.Error($"Enhancement error: {ex.Message}");
        }

        try
        {
            StreamReader taSR = new StreamReader(taskFilePath);
            while(!taSR.EndOfStream)
            {
                Task task = new Task();
                string line = taSR.ReadLine();
                string[] taDetails = line.Split(',');
                tid = 0;
                bool firstline = long.TryParse(taDetails[0], out tid);
                if(!firstline) continue;
                task.TicketID = tid;
                task.Summary = taDetails[1];
                task.Status  = taDetails[2];
                task.Priority  = taDetails[3];
                task.Submitter  = taDetails[4];
                task.Assigned  = taDetails[5];
                task.Watching = taDetails[6];
                task.ProjectName = taDetails[7];
                task.DueDate = taDetails[8];

                TaskList.Add(task);
            }
            taSR.Close();
            Logger.Info($"Task in file {TaskList.Count}");
        }
        catch (Exception ex)
        {
            Logger.Error($"Task error: {ex.Message}");
        }

    }

    public void AddTicketList(Ticket ticket)
    {
        try
        {
            ticket.TicketID = TicketList.Max(t => t.TicketID) +1;

            StreamWriter sw = new StreamWriter(TicketFilePath, true);
            sw.WriteLine($"\n{ticket.TicketID.ToString()},{ticket.Summary},{ticket.Status},{ticket.Priority},{ticket.Submitter},{ticket.Assigned},{ticket.Watching},{ticket.Severity}");
            sw.Close();

            TicketList.Add(ticket);
        }
        catch(Exception ex)
        {
            Logger.Error($"Add ticket: {ex.Message}");
        }

    }

    public void AddEnhancementList(Enhancement enhancement)
    {
        try
        {
            enhancement.TicketID = TicketList.Max(t => t.TicketID) +1;

            StreamWriter sw = new StreamWriter(TicketFilePath, true);
            sw.WriteLine($"\n{enhancement.TicketID.ToString()},{enhancement.Summary},{enhancement.Status},{enhancement.Priority},{enhancement.Submitter},{enhancement.Assigned},{enhancement.Watching},{enhancement.Software},{enhancement.Cost},{enhancement.Reason},{enhancement.Estimate}");
            sw.Close();

            EnhancementList.Add(enhancement);
        }
        catch(Exception ex)
        {
            Logger.Error($"Add enhancement: {ex.Message}");
        }
    }

    public void AddTaskList(Task task)
    {
        try
        {
            task.TicketID = TicketList.Max(t => t.TicketID) +1;

            StreamWriter sw = new StreamWriter(TicketFilePath, true);
            sw.WriteLine($"\n{task.TicketID.ToString()},{task.Summary},{task.Status},{task.Priority},{task.Submitter},{task.Assigned},{task.Watching},{task.ProjectName},{task.DueDate}");
            sw.Close();

            TaskList.Add(task);
        }
        catch(Exception ex)
        {
            Logger.Error($"Add ticket: {ex.Message}");
        }
    }

}