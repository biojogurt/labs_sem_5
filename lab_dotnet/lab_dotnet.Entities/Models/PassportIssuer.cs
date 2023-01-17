using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class PassportIssuer : BaseEntity
{
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Borrower> Borrowers { get; set; }
}