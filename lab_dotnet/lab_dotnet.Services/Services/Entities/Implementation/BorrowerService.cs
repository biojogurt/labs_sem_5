using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.Extensions.Logging;

namespace lab_dotnet.Services.Implementation;

public class BorrowerService : IBorrowerService
{
    private readonly IPageService<Borrower, BorrowerPreviewModel> PageService;
    private readonly IRepository<Borrower> RepositoryBorrower;
    private readonly IRepository<PassportIssuer> RepositoryPassportIssuer;
    private readonly IMapper Mapper;
    private readonly ILogger<BorrowerService> Logger;

    public BorrowerService(IPageService<Borrower, BorrowerPreviewModel> pageService,
                           IRepository<Borrower> repositoryBorrower,
                           IRepository<PassportIssuer> repositoryPassportIssuer,
                           IMapper mapper,
                           ILogger<BorrowerService> logger)
    {
        PageService = pageService;
        RepositoryBorrower = repositoryBorrower;
        RepositoryPassportIssuer = repositoryPassportIssuer;
        Mapper = mapper;
        Logger = logger;
    }

    public BorrowerModel CreateBorrower(BorrowerModel borrowerModel)
    {
        var existingPassportIssuer = RepositoryPassportIssuer.GetById(borrowerModel.PassportIssuerId);
        if (existingPassportIssuer == null)
        {
            Exception ex = new Exception("No such passport issuer");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        Borrower borrower = Mapper.Map<Borrower>(borrowerModel);
        RepositoryBorrower.Save(borrower);
        return Mapper.Map<BorrowerModel>(borrower);
    }

    public void DeleteBorrower(Guid id)
    {
        var borrower = RepositoryBorrower.GetById(id);
        if (borrower == null)
        {
            Exception ex = new Exception("Borrower not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        RepositoryBorrower.Delete(borrower);
    }

    public BorrowerModel GetBorrowerById(Guid id)
    {
        var borrower = RepositoryBorrower.GetById(id);
        if (borrower == null)
        {
            Exception ex = new Exception("Borrower not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<BorrowerModel>(borrower);
    }

    public BorrowerModel GetBorrowerByPassport(PassportModel passport)
    {
        var borrower = RepositoryBorrower.GetAll(x =>
                       x.PassportSerial == passport.PassportSerial &&
                       x.PassportNumber == passport.PassportNumber &&
                       x.PassportIssuerId == passport.PassportIssuerId &&
                       x.PassportIssueDate == passport.PassportIssueDate)
                       .FirstOrDefault();
        if (borrower == null)
        {
            Exception ex = new Exception("Borrower not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        return Mapper.Map<BorrowerModel>(borrower);
    }

    public PageModel<BorrowerPreviewModel> GetBorrowers(int limit = 20, int offset = 0)
    {
        var borrowers = RepositoryBorrower.GetAll();
        return PageService.CreatePage(borrowers, limit, offset, x => x.FullName);
    }

    public BorrowerModel UpdateBorrower(Guid id, UpdateBorrowerModel borrower)
    {
        var existingBorrower = RepositoryBorrower.GetById(id);
        if (existingBorrower == null)
        {
            Exception ex = new Exception("Borrower not found");
            Logger.LogError(ex.ToString());
            throw ex;
        }

        if (borrower.PassportSerial != null)
        {
            existingBorrower.PassportSerial = (int)borrower.PassportSerial;
        }

        if (borrower.PassportNumber != null)
        {
            existingBorrower.PassportNumber = (int)borrower.PassportNumber;
        }

        if (borrower.PassportIssuerId != null)
        {
            existingBorrower.PassportIssuerId = (Guid)borrower.PassportIssuerId;
        }

        if (borrower.PassportIssueDate != null)
        {
            existingBorrower.PassportIssueDate = (DateTime)borrower.PassportIssueDate;
        }

        if (borrower.FullName != null)
        {
            existingBorrower.FullName = borrower.FullName;
        }

        if (borrower.Birthdate != null)
        {
            existingBorrower.Birthdate = (DateTime)borrower.Birthdate;
        }

        if (borrower.Inn != null)
        {
            existingBorrower.Inn = borrower.Inn;
        }

        if (borrower.Snils != null)
        {
            existingBorrower.Snils = borrower.Snils;
        }

        if (borrower.RegistrationAddress != null)
        {
            existingBorrower.RegistrationAddress = borrower.RegistrationAddress;
        }

        if (borrower.ResidentialAddress != null)
        {
            existingBorrower.ResidentialAddress = borrower.ResidentialAddress;
        }

        existingBorrower = RepositoryBorrower.Save(existingBorrower);
        return Mapper.Map<BorrowerModel>(existingBorrower);
    }
}