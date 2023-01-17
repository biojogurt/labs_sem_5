namespace lab_dotnet.Services.Models;

public class ContributionModel : BaseModel
{
    public Guid ContributorId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime ContributionDate { get; set; }
}