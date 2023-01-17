namespace lab_dotnet.WebAPI.Models;

public class ContributionResponse : BaseResponse
{
    public Guid ContributorId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime ContributionDate { get; set; }
}