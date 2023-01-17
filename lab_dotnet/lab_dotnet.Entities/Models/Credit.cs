using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class Credit : BaseEntity
{
    public Guid CreditApplicationId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int InterestRate { get; set; }

    [JsonIgnore]
    public virtual CreditApplication CreditApplication { get; set; }
    [JsonIgnore]
    public virtual ICollection<Payment> Payments { get; set; }
}