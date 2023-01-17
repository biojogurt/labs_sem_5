using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class CreditService : ICreditService
{
    private readonly IPageService<Credit, CreditPreviewModel> PageService;
    private readonly IRepository<Credit> RepositoryCredit;
    private readonly IRepository<CreditApplication> RepositoryCreditApplication;
    private readonly IMapper Mapper;
    private readonly ILogger<CreditService> Logger;

    public CreditService(IPageService<Credit, CreditPreviewModel> pageService,
                         IRepository<Credit> repositoryCredit,
                         IRepository<CreditApplication> repositoryCreditApplication,
                         IMapper mapper,
                         ILogger<CreditService> logger)
    {
        PageService = pageService;
        RepositoryCredit = repositoryCredit;
        RepositoryCreditApplication = repositoryCreditApplication;
        Mapper = mapper;
        Logger = logger;
    }

    public CreditModel CreateCredit(CreditModel creditModel)
    {
        var existingCreditApplication = RepositoryCreditApplication.GetById(creditModel.CreditApplicationId);
        if (existingCreditApplication == null)
        {
            Exception ex = new Exception("No such credit application");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Credit credit = Mapper.Map<Credit>(creditModel);
        RepositoryCredit.Save(credit);
        return Mapper.Map<CreditModel>(credit);
    }

    public void DeleteCredit(Guid id)
    {
        var credit = RepositoryCredit.GetById(id);
        if (credit == null)
        {
            Exception ex = new Exception("Credit not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        RepositoryCredit.Delete(credit);
    }

    public CreditModel GetCredit(Guid id)
    {
        var credit = RepositoryCredit.GetAll(x => x.CreditApplicationId == id).FirstOrDefault();
        if (credit == null)
        {
            Exception ex = new Exception("Credit not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<CreditModel>(credit);
    }

    public PageModel<CreditPreviewModel> GetCredits(int limit = 20, int offset = 0)
    {
        var credits = RepositoryCredit.GetAll();
        return PageService.CreatePage(credits, limit, offset, x => x.StartDate);
    }

    public PageModel<CreditPreviewModel> GetCreditsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var credits = RepositoryCredit.GetAll(x => x.CreditApplication.BorrowerId == borrowerId);
        return PageService.CreatePage(credits, limit, offset, x => x.StartDate);
    }

    public CreditModel UpdateCredit(Guid id, UpdateCreditModel credit)
    {
        var existingCredit = RepositoryCredit.GetById(id);
        if (existingCredit == null)
        {
            Exception ex = new Exception("Credit not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (credit.CreditApplicationId != null)
        {
            existingCredit.CreditApplicationId = (Guid)credit.CreditApplicationId;
        }

        if (credit.IsActive != null)
        {
            existingCredit.IsActive = (bool)credit.IsActive;
        }

        if (credit.StartDate != null)
        {
            existingCredit.StartDate = (DateTime)credit.StartDate;
        }

        if (credit.EndDate != null)
        {
            existingCredit.EndDate = credit.EndDate;
        }

        if (credit.InterestRate != null)
        {
            existingCredit.InterestRate = (int)credit.InterestRate;
        }

        if (credit.BorrowerId != null)
        {
            existingCredit.CreditApplication.BorrowerId = (Guid)credit.BorrowerId;
        }

        existingCredit = RepositoryCredit.Save(existingCredit);
        return Mapper.Map<CreditModel>(existingCredit);
    }
}