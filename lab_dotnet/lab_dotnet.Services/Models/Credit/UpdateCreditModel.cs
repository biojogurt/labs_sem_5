namespace lab_dotnet.Services.Models;

public class UpdateCreditModel
{
    public Guid? CreditApplicationId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? InterestRate { get; set; }
    public Guid? BorrowerId { get; set; }
}