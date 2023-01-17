using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IPassportIssuerService
{
    PassportIssuerModel CreatePassportIssuer(PassportIssuerModel passportIssuerModel);

    PassportIssuerModel GetPassportIssuer(Guid id);

    PassportIssuerModel UpdatePassportIssuer(Guid id, UpdatePassportIssuerModel passportIssuer);

    void DeletePassportIssuer(Guid id);

    PageModel<PassportIssuerPreviewModel> GetPassportIssuers(int limit = 20, int offset = 0);
}