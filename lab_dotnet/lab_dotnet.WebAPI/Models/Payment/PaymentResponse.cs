namespace lab_dotnet.WebAPI.Models;

public class PaymentResponse : BaseResponse
{
    public Guid CreditId { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentAmount { get; set; }
    public int RemainingAmount { get; set; }
    public int Debt { get; set; }
}