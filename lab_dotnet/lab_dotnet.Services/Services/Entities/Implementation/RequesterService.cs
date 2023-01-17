using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class RequesterService : IRequesterService
{
    private readonly IPageService<Requester, RequesterPreviewModel> PageService;
    private readonly IRepository<Requester> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<RequesterService> Logger;

    public RequesterService(IPageService<Requester, RequesterPreviewModel> pageService,
                            IRepository<Requester> repository,
                            IMapper mapper,
                            ILogger<RequesterService> logger)
    {
        PageService = pageService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public RequesterModel CreateRequester(RequesterModel requesterModel)
    {
        Requester requester = Mapper.Map<Requester>(requesterModel);
        Repository.Save(requester);
        return Mapper.Map<RequesterModel>(requester);
    }

    public void DeleteRequester(Guid id)
    {
        var requester = Repository.GetById(id);
        if (requester == null)
        {
            Exception ex = new Exception("Requester not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(requester);
    }

    public RequesterModel GetRequester(Guid id)
    {
        var requester = Repository.GetById(id);
        if (requester == null)
        {
            Exception ex = new Exception("Requester not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<RequesterModel>(requester);
    }

    public PageModel<RequesterPreviewModel> GetRequesters(int limit = 20, int offset = 0)
    {
        var requesters = Repository.GetAll();
        return PageService.CreatePage(requesters, limit, offset, x => x.Name);
    }

    public RequesterModel UpdateRequester(Guid id, UpdateRequesterModel requester)
    {
        var existingRequester = Repository.GetById(id);
        if (existingRequester == null)
        {
            Exception ex = new Exception("Requester not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (requester.Name != null)
        {
            existingRequester.Name = requester.Name;
        }

        if (requester.Inn != null)
        {
            existingRequester.Inn = requester.Inn;
        }

        existingRequester = Repository.Save(existingRequester);
        return Mapper.Map<RequesterModel>(existingRequester);
    }
}