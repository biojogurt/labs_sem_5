namespace lab_dotnet.Services.Models;

public class PaymentPreviewModel : BasePreviewModel
{
    public Guid CreditId { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentAmount { get; set; }
}