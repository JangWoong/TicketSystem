public class Ticket
{
    public string summary { get; set; }
    public string status { get; set; }
    public string priority {get; set; }
    public string submitter { get; set; }
    public string assigned { get; set; }
    public string watching { get; set; }

    public string TacketInfo()
    {
        return $"{summary},{status},{priority},{submitter},{assigned},{watching}";
    }
}