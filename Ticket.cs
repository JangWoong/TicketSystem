using NLog;
public class Ticket
{
    public long TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority {get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }
    public string Severity { get; set; }


    public Ticket(string ticketFilePath)
    {

    }

    public string TacketInfo()
    {
        return $"{TicketID}, {Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}, {Severity}";
    }
}