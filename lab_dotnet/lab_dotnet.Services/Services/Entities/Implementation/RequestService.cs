using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class RequestService : IRequestService
{
    private readonly IPageService<Request, RequestPreviewModel> PageService;
    private readonly IRepository<Request> RepositoryRequest;
    private readonly IRepository<Borrower> RepositoryBorrower;
    private readonly IRepository<Requester> RepositoryRequester;
    private readonly IMapper Mapper;
    private readonly ILogger<RequestService> Logger;

    public RequestService(IPageService<Request, RequestPreviewModel> pageService,
                          IRepository<Request> repositoryRequest,
                          IRepository<Borrower> repositoryBorrower,
                          IRepository<Requester> repositoryRequester,
                          IMapper mapper,
                          ILogger<RequestService> logger)
    {
        PageService = pageService;
        RepositoryRequest = repositoryRequest;
        RepositoryBorrower = repositoryBorrower;
        RepositoryRequester = repositoryRequester;
        Mapper = mapper;
        Logger = logger;
    }

    public RequestModel CreateRequest(RequestModel requestModel)
    {
        var existingBorrower = RepositoryBorrower.GetById(requestModel.BorrowerId);
        if (existingBorrower == null)
        {
            Exception ex = new Exception("No such borrower");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        var existingRequester = RepositoryRequester.GetById(requestModel.RequesterId);
        if (existingRequester == null)
        {
            Exception ex = new Exception("No such requester");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Request request = Mapper.Map<Request>(requestModel);
        RepositoryRequest.Save(request);
        return Mapper.Map<RequestModel>(request);
    }

    public void DeleteRequest(Guid id)
    {
        var request = RepositoryRequest.GetById(id);
        if (request == null)
        {
            Exception ex = new Exception("Request not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        RepositoryRequest.Delete(request);
    }

    public RequestModel GetRequest(Guid id)
    {
        var request = RepositoryRequest.GetById(id);
        if (request == null)
        {
            Exception ex = new Exception("Request not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<RequestModel>(request);
    }

    public PageModel<RequestPreviewModel> GetRequests(int limit = 20, int offset = 0)
    {
        var requests = RepositoryRequest.GetAll();
        return PageService.CreatePage(requests, limit, offset, x => x.RequestDate);
    }

    public PageModel<RequestPreviewModel> GetRequestsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var requests = RepositoryRequest.GetAll(x => x.BorrowerId == borrowerId);
        return PageService.CreatePage(requests, limit, offset, x => x.RequestDate);
    }

    public PageModel<RequestPreviewModel> GetRequestsByRequesterId(Guid requesterId, int limit = 20, int offset = 0)
    {
        var requests = RepositoryRequest.GetAll(x => x.RequesterId == requesterId);
        return PageService.CreatePage(requests, limit, offset, x => x.RequestDate);
    }

    public RequestModel UpdateRequest(Guid id, UpdateRequestModel request)
    {
        var existingRequest = RepositoryRequest.GetById(id);
        if (existingRequest == null)
        {
            Exception ex = new Exception("Request not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (request.RequesterId != null)
        {
            existingRequest.RequesterId = (Guid)request.RequesterId;
        }

        if (request.BorrowerId != null)
        {
            existingRequest.BorrowerId = (Guid)request.BorrowerId;
        }

        if (request.RequestDate != null)
        {
            existingRequest.RequestDate = (DateTime)request.RequestDate;
        }

        existingRequest = RepositoryRequest.Save(existingRequest);
        return Mapper.Map<RequestModel>(existingRequest);
    }
}