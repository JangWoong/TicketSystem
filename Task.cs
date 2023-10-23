public class Task
{
    public string TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority {get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }
    public string ProjectName { get; set; }
    public string DueDate { get; set; }

    public string TacketInfo()
    {
        return $"{TicketID}, {Summary},{Status},{Priority},{Submitter},{Assigned},{Watching}, {ProjectName}, {DueDate}";
    }
}