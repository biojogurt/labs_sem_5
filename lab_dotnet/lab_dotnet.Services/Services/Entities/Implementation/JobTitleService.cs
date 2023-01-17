using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class JobTitleService : IJobTitleService
{
    private readonly IPageService<JobTitle, JobTitlePreviewModel> PageService;
    private readonly IRepository<JobTitle> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<JobTitleService> Logger;

    public JobTitleService(IPageService<JobTitle, JobTitlePreviewModel> pageService,
                           IRepository<JobTitle> repository,
                           IMapper mapper,
                           ILogger<JobTitleService> logger)
    {
        PageService = pageService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public JobTitleModel CreateJobTitle(JobTitleModel jobTitleModel)
    {
        JobTitle jobTitle = Mapper.Map<JobTitle>(jobTitleModel);
        Repository.Save(jobTitle);
        return Mapper.Map<JobTitleModel>(jobTitle);
    }

    public void DeleteJobTitle(Guid id)
    {
        var jobTitle = Repository.GetById(id);
        if (jobTitle == null)
        {
            Exception ex = new Exception("Job title not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(jobTitle);
    }

    public JobTitleModel GetJobTitle(Guid id)
    {
        var jobTitle = Repository.GetById(id);
        if (jobTitle == null)
        {
            Exception ex = new Exception("Job title not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<JobTitleModel>(jobTitle);
    }

    public PageModel<JobTitlePreviewModel> GetJobTitles(int limit = 20, int offset = 0)
    {
        var jobTitle = Repository.GetAll();
        return PageService.CreatePage(jobTitle, limit, offset, x => x.Name);
    }

    public JobTitleModel UpdateJobTitle(Guid id, UpdateJobTitleModel jobTitle)
    {
        var existingJobTitle = Repository.GetById(id);
        if (existingJobTitle == null)
        {
            Exception ex = new Exception("Job title not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (jobTitle.Name != null)
        {
            existingJobTitle.Name = jobTitle.Name;
        }

        existingJobTitle = Repository.Save(existingJobTitle);
        return Mapper.Map<JobTitleModel>(existingJobTitle);
    }
}