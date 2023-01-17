using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class CreditApplication : BaseEntity
{
    public Guid BorrowerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid CreditorId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int CreditAmount { get; set; }

    [JsonIgnore]
    public virtual Borrower Borrower { get; set; }
    [JsonIgnore]
    public virtual CreditType CreditType { get; set; }
    [JsonIgnore]
    public virtual Creditor Creditor { get; set; }
    [JsonIgnore]
    public virtual Credit Credit { get; set; }
}