using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class Request : BaseEntity
{
    public Guid RequesterId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime RequestDate { get; set; }

    [JsonIgnore]
    public virtual Requester Requester { get; set; }
    [JsonIgnore]
    public virtual Borrower Borrower { get; set; }
}