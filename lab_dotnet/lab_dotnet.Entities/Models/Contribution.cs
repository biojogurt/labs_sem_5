using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class Contribution : BaseEntity
{
    public Guid ContributorId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime ContributionDate { get; set; }

    [JsonIgnore]
    public virtual Contributor Contributor { get; set; }
    [JsonIgnore]
    public virtual Borrower Borrower { get; set; }
}