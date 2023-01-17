using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IRequesterService
{
    RequesterModel CreateRequester(RequesterModel requesterModel);

    RequesterModel GetRequester(Guid id);

    RequesterModel UpdateRequester(Guid id, UpdateRequesterModel requester);

    void DeleteRequester(Guid id);

    PageModel<RequesterPreviewModel> GetRequesters(int limit = 20, int offset = 0);
}