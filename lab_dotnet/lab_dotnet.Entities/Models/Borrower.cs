using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class Borrower : BaseEntity
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

    [JsonIgnore]
    public virtual PassportIssuer PassportIssuer { get; set; }
    [JsonIgnore]
    public virtual ICollection<CreditApplication> CreditApplications { get; set; }
    [JsonIgnore]
    public virtual ICollection<Contribution> Contributions { get; set; }
    [JsonIgnore]
    public virtual ICollection<Request> Requests { get; set; }
}