namespace lab_dotnet.Services.Models;

public class UpdatePaymentModel
{
    public Guid? CreditId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public int? PaymentAmount { get; set; }
    public int? RemainingAmount { get; set; }
    public int? Debt { get; set; }
}