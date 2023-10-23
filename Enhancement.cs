public class Enhancement
{
    public string TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority {get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }
    public string Software { get; set; }
    public string Cost { get; set; }
    public string Reason { get; set; }
    public string Estimate { get; set; }

    public string TacketInfo()
    {
        return $"{TicketID}, {Summary}, {Status}, {Priority}, {Submitter}, {Assigned}, {Watching}, {Software}, {Cost}, {Reason}, {Estimate}";
    }
}