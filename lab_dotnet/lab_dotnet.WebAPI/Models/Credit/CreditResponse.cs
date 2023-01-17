namespace lab_dotnet.WebAPI.Models;

public class CreditResponse
{
    public Guid CreditApplicationId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int InterestRate { get; set; }
    public Guid BorrowerId { get; set; }
}