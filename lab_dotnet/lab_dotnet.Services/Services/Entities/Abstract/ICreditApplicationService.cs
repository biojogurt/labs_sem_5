using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface ICreditApplicationService
{
    CreditApplicationModel CreateCreditApplication(CreditApplicationModel creditApplicationModel);

    CreditApplicationModel GetCreditApplication(Guid id);

    CreditApplicationModel UpdateCreditApplication(Guid id, UpdateCreditApplicationModel creditApplication);

    void DeleteCreditApplication(Guid id);

    PageModel<CreditApplicationPreviewModel> GetCreditApplications(int limit = 20, int offset = 0);

    PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0);

    PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByCreditTypeId(Guid creditTypeId, int limit = 20, int offset = 0);

    PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByCreditorId(Guid creditorId, int limit = 20, int offset = 0);
}