using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IContributorService
{
    ContributorModel CreateContributor(ContributorModel contributorModel);

    ContributorModel GetContributor(Guid id);

    ContributorModel UpdateContributor(Guid id, UpdateContributorModel contributor);

    void DeleteContributor(Guid id);

    PageModel<ContributorPreviewModel> GetContributors(int limit = 20, int offset = 0);
}