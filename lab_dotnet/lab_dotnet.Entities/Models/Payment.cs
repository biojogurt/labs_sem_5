using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class Payment : BaseEntity
{
    public Guid CreditId { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentAmount { get; set; }
    public int RemainingAmount { get; set; }
    public int Debt { get; set; }

    [JsonIgnore]
    public virtual Credit Credit { get; set; }
}