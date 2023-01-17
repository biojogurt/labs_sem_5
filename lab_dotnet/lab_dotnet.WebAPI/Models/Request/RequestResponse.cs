namespace lab_dotnet.WebAPI.Models;

public class RequestResponse : BaseResponse
{
    public Guid RequesterId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime RequestDate { get; set; }
}