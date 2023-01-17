namespace lab_dotnet.WebAPI.Models;

public class BorrowerPreviewResponse : BaseResponse
{
    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
    public string FullName { get; set; }
}