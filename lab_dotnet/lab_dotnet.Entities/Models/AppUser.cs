using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace lab_dotnet.Entities.Models;

public class AppUser : IdentityUser<Guid>, IBaseEntity
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    public int AccessLevel { get; set; }

    [JsonIgnore]
    public virtual JobTitle JobTitle { get; set; }

    #region BaseEntity

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

    #endregion
}

public class UserRole : IdentityRole<Guid>
{ }