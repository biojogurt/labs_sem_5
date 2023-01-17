namespace lab_dotnet.WebAPI.Models;

public class PaymentPreviewResponse : BaseResponse
{
    public Guid CreditId { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentAmount { get; set; }
}