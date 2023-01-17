using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class CreditApplicationService : ICreditApplicationService
{
    private readonly IPageService<CreditApplication, CreditApplicationPreviewModel> PageService;
    private readonly IRepository<CreditApplication> RepositoryCreditApplication;
    private readonly IRepository<Borrower> RepositoryBorrower;
    private readonly IRepository<CreditType> RepositoryCreditType;
    private readonly IRepository<Creditor> RepositoryCreditor;
    private readonly IMapper Mapper;
    private readonly ILogger<CreditApplicationService> Logger;

    public CreditApplicationService(IPageService<CreditApplication, CreditApplicationPreviewModel> pageService,
                                    IRepository<CreditApplication> repositoryCreditApplication,
                                    IRepository<Borrower> repositoryBorrower,
                                    IRepository<CreditType> repositoryCreditType,
                                    IRepository<Creditor> repositoryCreditor,
                                    IMapper mapper,
                                    ILogger<CreditApplicationService> logger)
    {
        PageService = pageService;
        RepositoryCreditApplication = repositoryCreditApplication;
        RepositoryBorrower = repositoryBorrower;
        RepositoryCreditType = repositoryCreditType;
        RepositoryCreditor = repositoryCreditor;
        Mapper = mapper;
        Logger = logger;
    }

    public CreditApplicationModel CreateCreditApplication(CreditApplicationModel creditApplicationModel)
    {
        var existingBorrower = RepositoryBorrower.GetById(creditApplicationModel.BorrowerId);
        if (existingBorrower == null)
        {
            Exception ex = new Exception("No such borrower");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        var existingCreditType = RepositoryCreditType.GetById(creditApplicationModel.CreditTypeId);
        if (existingCreditType == null)
        {
            Exception ex = new Exception("No such credit type");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        var existingCreditor = RepositoryCreditor.GetById(creditApplicationModel.CreditorId);
        if (existingCreditor == null)
        {
            Exception ex = new Exception("No such creditor");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        CreditApplication creditapplication = Mapper.Map<CreditApplication>(creditApplicationModel);
        RepositoryCreditApplication.Save(creditapplication);
        return Mapper.Map<CreditApplicationModel>(creditapplication);
    }

    public void DeleteCreditApplication(Guid id)
    {
        var application = RepositoryCreditApplication.GetById(id);
        if (application == null)
        {
            Exception ex = new Exception("Credit application not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        RepositoryCreditApplication.Delete(application);
    }

    public CreditApplicationModel GetCreditApplication(Guid id)
    {
        var application = RepositoryCreditApplication.GetById(id);
        if (application == null)
        {
            Exception ex = new Exception("Credit application not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<CreditApplicationModel>(application);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplications(int limit = 20, int offset = 0)
    {
        var applications = RepositoryCreditApplication.GetAll();
        return PageService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var applications = RepositoryCreditApplication.GetAll(x => x.BorrowerId == borrowerId);
        return PageService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByCreditorId(Guid creditorId, int limit = 20, int offset = 0)
    {
        var applications = RepositoryCreditApplication.GetAll(x => x.CreditorId == creditorId);
        return PageService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public PageModel<CreditApplicationPreviewModel> GetCreditApplicationsByCreditTypeId(Guid creditTypeId, int limit = 20, int offset = 0)
    {
        var applications = RepositoryCreditApplication.GetAll(x => x.CreditTypeId == creditTypeId);
        return PageService.CreatePage(applications, limit, offset, x => x.ApplicationDate);
    }

    public CreditApplicationModel UpdateCreditApplication(Guid id, UpdateCreditApplicationModel creditApplication)
    {
        var existingApplication = RepositoryCreditApplication.GetById(id);
        if (existingApplication == null)
        {
            Exception ex = new Exception("Credit application not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (creditApplication.BorrowerId != null)
        {
            existingApplication.BorrowerId = (Guid)creditApplication.BorrowerId;
        }

        if (creditApplication.CreditTypeId != null)
        {
            existingApplication.CreditTypeId = (Guid)creditApplication.CreditTypeId;
        }

        if (creditApplication.CreditorId != null)
        {
            existingApplication.CreditorId = (Guid)creditApplication.CreditorId;
        }

        if (creditApplication.ApplicationDate != null)
        {
            existingApplication.ApplicationDate = (DateTime)creditApplication.ApplicationDate;
        }

        if (creditApplication.CreditAmount != null)
        {
            existingApplication.CreditAmount = (int)creditApplication.CreditAmount;
        }

        existingApplication = RepositoryCreditApplication.Save(existingApplication);
        return Mapper.Map<CreditApplicationModel>(existingApplication);
    }
}