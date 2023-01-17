using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class JobTitle : BaseEntity
{
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<AppUser> AppUsers { get; set; }
}