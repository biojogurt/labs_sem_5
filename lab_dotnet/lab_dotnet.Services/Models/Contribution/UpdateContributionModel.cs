namespace lab_dotnet.Services.Models;

public class UpdateContributionModel
{
    public Guid? ContributorId { get; set; }
    public Guid? BorrowerId { get; set; }
    public DateTime? ContributionDate { get; set; }
}