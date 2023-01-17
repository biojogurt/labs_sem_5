namespace lab_dotnet.Services.Models;

public class BorrowerModel : BaseModel
{
    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
    public Guid PassportIssuerId { get; set; }
    public DateTime PassportIssueDate { get; set; }
    public string FullName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Inn { get; set; }
    public string Snils { get; set; }
    public string RegistrationAddress { get; set; }
    public string? ResidentialAddress { get; set; }
}