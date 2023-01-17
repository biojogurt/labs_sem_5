using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface ICreditTypeService
{
    CreditTypeModel CreateCreditType(CreditTypeModel creditTypeModel);

    CreditTypeModel GetCreditType(Guid id);

    CreditTypeModel UpdateCreditType(Guid id, UpdateCreditTypeModel creditType);

    void DeleteCreditType(Guid id);

    PageModel<CreditTypePreviewModel> GetCreditTypes(int limit = 20, int offset = 0);
}