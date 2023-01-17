using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class CreditType : BaseEntity
{
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<CreditApplication> CreditApplications { get; set; }
}