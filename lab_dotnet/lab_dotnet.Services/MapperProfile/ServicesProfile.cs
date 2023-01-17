using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region AppUser

        CreateMap<AppUser, AppUserModel>().ReverseMap();
        CreateMap<AppUser, AppUserPreviewModel>();

        #endregion AppUser

        #region Borrower

        CreateMap<Borrower, BorrowerModel>().ReverseMap();
        CreateMap<Borrower, BorrowerPreviewModel>();

        #endregion Borrower

        #region Contribution

        CreateMap<Contribution, ContributionModel>().ReverseMap();
        CreateMap<Contribution, ContributionPreviewModel>();

        #endregion Contribution

        #region Contributor

        CreateMap<Contributor, ContributorModel>().ReverseMap();
        CreateMap<Contributor, ContributorPreviewModel>();

        #endregion Contributor

        #region Credit

        CreateMap<Credit, CreditModel>()
                          .ForMember(x => x.BorrowerId,
                                     y => y.MapFrom(u => u.CreditApplication.BorrowerId))
                          .ReverseMap();
        CreateMap<Credit, CreditPreviewModel>();

        #endregion Credit

        #region CreditApplication

        CreateMap<CreditApplication, CreditApplicationModel>().ReverseMap();
        CreateMap<CreditApplication, CreditApplicationPreviewModel>();

        #endregion CreditApplication

        #region Creditor

        CreateMap<Creditor, CreditorModel>().ReverseMap();
        CreateMap<Creditor, CreditorPreviewModel>();

        #endregion Creditor

        #region CreditType

        CreateMap<CreditType, CreditTypeModel>().ReverseMap();
        CreateMap<CreditType, CreditTypePreviewModel>().ReverseMap();

        #endregion CreditType

        #region JobTitle

        CreateMap<JobTitle, JobTitleModel>().ReverseMap();
        CreateMap<JobTitle, JobTitlePreviewModel>().ReverseMap();

        #endregion JobTitle

        #region PassportIssuer

        CreateMap<PassportIssuer, PassportIssuerModel>().ReverseMap();
        CreateMap<PassportIssuer, PassportIssuerPreviewModel>().ReverseMap();

        #endregion PassportIssuer

        #region Payment

        CreateMap<Payment, PaymentModel>().ReverseMap();
        CreateMap<Payment, PaymentPreviewModel>();

        #endregion Payment

        #region Request

        CreateMap<Request, RequestModel>().ReverseMap();
        CreateMap<Request, RequestPreviewModel>();

        #endregion Request

        #region Requester

        CreateMap<Requester, RequesterModel>().ReverseMap();
        CreateMap<Requester, RequesterPreviewModel>();

        #endregion Requester
    }
}