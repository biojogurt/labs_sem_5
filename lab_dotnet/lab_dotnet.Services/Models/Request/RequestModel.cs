namespace lab_dotnet.Services.Models;

public class RequestModel : BaseModel
{
    public Guid RequesterId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime RequestDate { get; set; }
}