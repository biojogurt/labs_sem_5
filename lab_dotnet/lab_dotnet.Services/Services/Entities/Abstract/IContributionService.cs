using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IContributionService
{
    ContributionModel CreateContribution(ContributionModel contributionModel);

    ContributionModel GetContribution(Guid id);

    ContributionModel UpdateContribution(Guid id, UpdateContributionModel contribution);

    void DeleteContribution(Guid id);

    PageModel<ContributionPreviewModel> GetContributions(int limit = 20, int offset = 0);

    PageModel<ContributionPreviewModel> GetContributionsByContributorId(Guid contributorId, int limit = 20, int offset = 0);

    PageModel<ContributionPreviewModel> GetContributionsByBorrowerId(Guid borrowerId, int limit = 20, int offset = 0);
}