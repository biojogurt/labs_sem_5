using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface ICreditService
{
    CreditModel CreateCredit(CreditModel creditModel);

    CreditModel GetCredit(Guid id);

    CreditModel UpdateCredit(Guid id, UpdateCreditModel credit);

    void DeleteCredit(Guid id);

    PageModel<CreditPreviewModel> GetCredits(int limit = 20, int offset = 0);

    PageModel<CreditPreviewModel> GetCreditsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0);
}