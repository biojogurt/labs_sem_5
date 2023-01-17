namespace lab_dotnet.Services.Models;

public class BorrowerPreviewModel : BasePreviewModel
{
    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
    public string FullName { get; set; }
}