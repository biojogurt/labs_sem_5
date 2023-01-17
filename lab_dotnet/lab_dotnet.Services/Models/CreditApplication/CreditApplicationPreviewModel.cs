namespace lab_dotnet.Services.Models;

public class CreditApplicationPreviewModel : BasePreviewModel
{
    public Guid BorrowerId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int CreditAmount { get; set; }
}