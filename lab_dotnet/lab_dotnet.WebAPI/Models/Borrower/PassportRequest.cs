namespace lab_dotnet.WebAPI.Models;

public class PassportRequest
{
    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
    public Guid PassportIssuerId { get; set; }
    public DateTime PassportIssueDate { get; set; }
}