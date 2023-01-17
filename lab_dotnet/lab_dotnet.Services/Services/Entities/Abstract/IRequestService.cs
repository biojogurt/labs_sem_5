using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IRequestService
{
    RequestModel CreateRequest(RequestModel requestModel);

    RequestModel GetRequest(Guid id);

    RequestModel UpdateRequest(Guid id, UpdateRequestModel request);

    void DeleteRequest(Guid id);

    PageModel<RequestPreviewModel> GetRequests(int limit = 20, int offset = 0);

    PageModel<RequestPreviewModel> GetRequestsByRequesterId(Guid requesterId, int limit = 20, int offset = 0);

    PageModel<RequestPreviewModel> GetRequestsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0);
}