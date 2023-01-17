using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class PassportIssuerService : IPassportIssuerService
{
    private readonly IPageService<PassportIssuer, PassportIssuerPreviewModel> PageService;
    private readonly IRepository<PassportIssuer> Repository;
    private readonly IMapper Mapper;
    private readonly ILogger<PassportIssuerService> Logger;

    public PassportIssuerService(IPageService<PassportIssuer, PassportIssuerPreviewModel> pageService,
                                 IRepository<PassportIssuer> repository,
                                 IMapper mapper,
                                 ILogger<PassportIssuerService> logger)
    {
        PageService = pageService;
        Repository = repository;
        Mapper = mapper;
        Logger = logger;
    }

    public PassportIssuerModel CreatePassportIssuer(PassportIssuerModel passportIssuerModel)
    {
        PassportIssuer passportIssuer = Mapper.Map<PassportIssuer>(passportIssuerModel);
        Repository.Save(passportIssuer);
        return Mapper.Map<PassportIssuerModel>(passportIssuer);
    }

    public void DeletePassportIssuer(Guid id)
    {
        var passportIssuer = Repository.GetById(id);
        if (passportIssuer == null)
        {
            Exception ex = new Exception("Passport issuer not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Repository.Delete(passportIssuer);
    }

    public PassportIssuerModel GetPassportIssuer(Guid id)
    {
        var passportIssuer = Repository.GetById(id);
        if (passportIssuer == null)
        {
            Exception ex = new Exception("Passport issuer not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<PassportIssuerModel>(passportIssuer);
    }

    public PageModel<PassportIssuerPreviewModel> GetPassportIssuers(int limit = 20, int offset = 0)
    {
        var passportIssuer = Repository.GetAll();
        return PageService.CreatePage(passportIssuer, limit, offset, x => x.Name);
    }

    public PassportIssuerModel UpdatePassportIssuer(Guid id, UpdatePassportIssuerModel passportIssuer)
    {
        var existingPassportIssuer = Repository.GetById(id);
        if (existingPassportIssuer == null)
        {
            Exception ex = new Exception("Passport issuer not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (passportIssuer.Name != null)
        {
            existingPassportIssuer.Name = passportIssuer.Name;
        }

        existingPassportIssuer = Repository.Save(existingPassportIssuer);
        return Mapper.Map<PassportIssuerModel>(existingPassportIssuer);
    }
}