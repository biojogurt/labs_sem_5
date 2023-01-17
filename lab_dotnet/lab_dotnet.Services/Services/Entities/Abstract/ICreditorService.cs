using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface ICreditorService
{
    CreditorModel CreateCreditor(CreditorModel creditorModel);

    CreditorModel GetCreditor(Guid id);

    CreditorModel UpdateCreditor(Guid id, UpdateCreditorModel creditor);

    void DeleteCreditor(Guid id);

    PageModel<CreditorPreviewModel> GetCreditors(int limit = 20, int offset = 0);
}