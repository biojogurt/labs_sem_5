using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IJobTitleService
{
    JobTitleModel CreateJobTitle(JobTitleModel jobTitleModel);

    JobTitleModel GetJobTitle(Guid id);

    JobTitleModel UpdateJobTitle(Guid id, UpdateJobTitleModel jobTitle);

    void DeleteJobTitle(Guid id);

    PageModel<JobTitlePreviewModel> GetJobTitles(int limit = 20, int offset = 0);
}