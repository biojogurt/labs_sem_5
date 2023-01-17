namespace lab_dotnet.Services.Models;

public class UpdateRequestModel
{
    public Guid? RequesterId { get; set; }
    public Guid? BorrowerId { get; set; }
    public DateTime? RequestDate { get; set; }
}