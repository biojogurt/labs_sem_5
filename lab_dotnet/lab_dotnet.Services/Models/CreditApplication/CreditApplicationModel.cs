namespace lab_dotnet.Services.Models;

public class CreditApplicationModel : BaseModel
{
    public Guid BorrowerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid CreditorId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int CreditAmount { get; set; }
}