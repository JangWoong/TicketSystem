public abstract class Tickets
{
    public long TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority {get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }

    public Tickets()
    {

    }

    public virtual string Display()
    {
        return $"  Ticket ID: {TicketID}\n\tSummary: {Summary}\tStatus: {Status}\tPriority: {Priority}\n\tSubmitter: {Submitter}\tAssigned: {Assigned}\tWatching: {Watching}";
    }
}

// Ticket class is derived from Tickets class
public class Ticket : Tickets
{
    public string Severity { get; set; }

    public override string Display()
    {
        return $"  Ticket ID: {TicketID}\n\tSummary: {Summary}\tStatus: {Status}\tPriority: {Priority}\n\tSubmitter: {Submitter}\tAssigned: {Assigned}\tWatching: {Watching}\n\tSeverity: {Severity}";
    }
}

// Enhancement class is derived from Tickets class
public class Enhancement : Tickets
{
    public string Software { get; set; }
    public string Cost { get; set; }
    public string Reason { get; set; }
    public string Estimate { get; set; }

    public override string Display()
    {
        return $"  Ticket ID: {TicketID}\n\tSummary: {Summary}\tStatus: {Status}\tPriority: {Priority}\n\tSubmitter: {Submitter}\tAssigned: {Assigned}\tWatching: {Watching}\n\tSoftware: {Software}\tCost: {Cost}\tReason: {Reason}\tEstimate: {Estimate}";
    }
}

// Task class is derived from Tickets class
public class Task : Tickets
{
    public string ProjectName { get; set; }
    public string DueDate { get; set; }

    public override string Display()
    {
        return $"  Ticket ID: {TicketID}\n\tSummary: {Summary}\tStatus: {Status}\tPriority: {Priority}\n\tSubmitter: {Submitter}\tAssigned: {Assigned}\tWatching: {Watching}\n\tProject Name: {ProjectName}\tDue Date: {DueDate}";
    }
}