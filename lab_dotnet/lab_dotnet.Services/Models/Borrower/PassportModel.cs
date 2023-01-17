namespace lab_dotnet.Services.Models;

public class PassportModel
{
    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
    public Guid PassportIssuerId { get; set; }
    public DateTime PassportIssueDate { get; set; }
}