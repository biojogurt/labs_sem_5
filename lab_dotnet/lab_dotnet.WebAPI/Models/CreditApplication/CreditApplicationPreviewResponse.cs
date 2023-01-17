namespace lab_dotnet.WebAPI.Models;

public class CreditApplicationPreviewResponse : BaseResponse
{
    public Guid BorrowerId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int CreditAmount { get; set; }
}