using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class ContributionService : IContributionService
{
    private readonly IPageService<Contribution, ContributionPreviewModel> PageService;
    private readonly IRepository<Contribution> RepositoryContribution;
    private readonly IRepository<Contributor> RepositoryContributor;
    private readonly IRepository<Borrower> RepositoryBorrower;
    private readonly IMapper Mapper;
    private readonly ILogger<ContributionService> Logger;

    public ContributionService(IPageService<Contribution, ContributionPreviewModel> pageService,
                               IRepository<Contribution> repositoryContribution,
                               IRepository<Contributor> repositoryContributor,
                               IRepository<Borrower> repositoryBorrower,
                               IMapper mapper,
                               ILogger<ContributionService> logger)
    {
        PageService = pageService;
        RepositoryContribution = repositoryContribution;
        RepositoryContributor = repositoryContributor;
        RepositoryBorrower = repositoryBorrower;
        Mapper = mapper;
        Logger = logger;
    }

    public ContributionModel CreateContribution(ContributionModel contributionModel)
    {
        var existingBorrower = RepositoryBorrower.GetById(contributionModel.BorrowerId);
        if (existingBorrower == null)
        {
            Exception ex = new Exception("No such borrower");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        var existingContributor = RepositoryContributor.GetById(contributionModel.ContributorId);
        if (existingContributor == null)
        {
            Exception ex = new Exception("No such contributor");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Contribution contribution = Mapper.Map<Contribution>(contributionModel);
        RepositoryContribution.Save(contribution);
        return Mapper.Map<ContributionModel>(contribution);
    }

    public void DeleteContribution(Guid id)
    {
        var contribution = RepositoryContribution.GetById(id);
        if (contribution == null)
        {
            Exception ex = new Exception("Contribution not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        RepositoryContribution.Delete(contribution);
    }

    public ContributionModel GetContribution(Guid id)
    {
        var contribution = RepositoryContribution.GetById(id);
        if (contribution == null)
        {
            Exception ex = new Exception("Contribution not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<ContributionModel>(contribution);
    }

    public PageModel<ContributionPreviewModel> GetContributions(int limit = 20, int offset = 0)
    {
        var contributions = RepositoryContribution.GetAll();
        return PageService.CreatePage(contributions, limit, offset, x => x.ContributionDate);
    }

    public PageModel<ContributionPreviewModel> GetContributionsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0)
    {
        var contributions = RepositoryContribution.GetAll(x => x.BorrowerId == borrowerId);
        return PageService.CreatePage(contributions, limit, offset, x => x.ContributionDate);
    }

    public PageModel<ContributionPreviewModel> GetContributionsByContributorId(Guid contributorId, int limit = 20, int offset = 0)
    {
        var contributions = RepositoryContribution.GetAll(x => x.ContributorId == contributorId);
        return PageService.CreatePage(contributions, limit, offset, x => x.ContributionDate);
    }

    public ContributionModel UpdateContribution(Guid id, UpdateContributionModel contribution)
    {
        var existingContribution = RepositoryContribution.GetById(id);
        if (existingContribution == null)
        {
            Exception ex = new Exception("Contribution not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (contribution.ContributorId != null)
        {
            existingContribution.ContributorId = (Guid)contribution.ContributorId;
        }

        if (contribution.BorrowerId != null)
        {
            existingContribution.BorrowerId = (Guid)contribution.BorrowerId;
        }

        if (contribution.ContributionDate != null)
        {
            existingContribution.ContributionDate = (DateTime)contribution.ContributionDate;
        }

        existingContribution = RepositoryContribution.Save(existingContribution);
        return Mapper.Map<ContributionModel>(existingContribution);
    }
}