using AutoMapper;
using lab_dotnet.WebAPI.Models;
using lab_dotnet.Services.Models;

namespace lab_dotnet.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region Paging

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>)).ReverseMap();

        #endregion Paging

        #region Base

        CreateMap<BaseModel, BaseResponse>().ReverseMap();

        #endregion Base

        #region Auth

        CreateMap<RegisterUserRequest, RegisterUserModel>().ReverseMap();
        CreateMap<LoginUserRequest, LoginUserModel>().ReverseMap();

        #endregion Auth

        #region AppUser

        CreateMap<AppUserModel, AppUserResponse>().ReverseMap();
        CreateMap<UpdateAppUserRequest, UpdateAppUserModel>().ReverseMap();
        CreateMap<AppUserPreviewModel, AppUserPreviewResponse>().ReverseMap();

        #endregion AppUser

        #region Borrower

        CreateMap<BorrowerModel, BorrowerRequest>().ReverseMap();
        CreateMap<BorrowerModel, BorrowerResponse>().ReverseMap();
        CreateMap<UpdateBorrowerRequest, UpdateBorrowerModel>().ReverseMap();
        CreateMap<BorrowerPreviewModel, BorrowerPreviewResponse>().ReverseMap();

        #endregion Borrower

        #region Contribution

        CreateMap<ContributionModel, ContributionRequest>().ReverseMap();
        CreateMap<ContributionModel, ContributionResponse>().ReverseMap();
        CreateMap<UpdateContributionRequest, UpdateContributionModel>().ReverseMap();
        CreateMap<ContributionPreviewModel, ContributionPreviewResponse>().ReverseMap();

        #endregion Contribution

        #region Contributor

        CreateMap<ContributorModel, ContributorRequest>().ReverseMap();
        CreateMap<ContributorModel, ContributorResponse>().ReverseMap();
        CreateMap<UpdateContributorRequest, UpdateContributorModel>().ReverseMap();
        CreateMap<ContributorPreviewModel, ContributorPreviewResponse>().ReverseMap();

        #endregion Contributor

        #region Credit

        CreateMap<CreditModel, CreditRequest>().ReverseMap();
        CreateMap<CreditModel, CreditResponse>().ReverseMap();
        CreateMap<UpdateCreditRequest, UpdateCreditModel>().ReverseMap();
        CreateMap<CreditPreviewModel, CreditPreviewResponse>().ReverseMap();

        #endregion Credit

        #region CreditApplication

        CreateMap<CreditApplicationModel, CreditApplicationRequest>().ReverseMap();
        CreateMap<CreditApplicationModel, CreditApplicationResponse>().ReverseMap();
        CreateMap<UpdateCreditApplicationRequest, UpdateCreditApplicationModel>().ReverseMap();
        CreateMap<CreditApplicationPreviewModel, CreditApplicationPreviewResponse>().ReverseMap();

        #endregion CreditApplication

        #region Creditor

        CreateMap<CreditorModel, CreditorRequest>().ReverseMap();
        CreateMap<CreditorModel, CreditorResponse>().ReverseMap();
        CreateMap<UpdateCreditorRequest, UpdateCreditorModel>().ReverseMap();
        CreateMap<CreditorPreviewModel, CreditorPreviewResponse>().ReverseMap();

        #endregion Creditor

        #region CreditType

        CreateMap<CreditTypeModel, CreditTypeRequest>().ReverseMap();
        CreateMap<CreditTypeModel, CreditTypeResponse>().ReverseMap();
        CreateMap<UpdateCreditTypeRequest, UpdateCreditTypeModel>().ReverseMap();
        CreateMap<CreditTypePreviewModel, CreditTypePreviewResponse>().ReverseMap();

        #endregion CreditType

        #region JobTitle

        CreateMap<JobTitleModel, JobTitleRequest>().ReverseMap();
        CreateMap<JobTitleModel, JobTitleResponse>().ReverseMap();
        CreateMap<UpdateJobTitleRequest, UpdateJobTitleModel>().ReverseMap();
        CreateMap<JobTitlePreviewModel, JobTitlePreviewResponse>().ReverseMap();

        #endregion JobTitle

        #region PassportIssuer

        CreateMap<PassportIssuerModel, PassportIssuerRequest>().ReverseMap();
        CreateMap<PassportIssuerModel, PassportIssuerResponse>().ReverseMap();
        CreateMap<UpdatePassportIssuerRequest, UpdatePassportIssuerModel>().ReverseMap();
        CreateMap<PassportIssuerPreviewModel, PassportIssuerPreviewResponse>().ReverseMap();

        #endregion PassportIssuer

        #region Payment

        CreateMap<PaymentModel, PaymentRequest>().ReverseMap();
        CreateMap<PaymentModel, PaymentResponse>().ReverseMap();
        CreateMap<UpdatePaymentRequest, UpdatePaymentModel>().ReverseMap();
        CreateMap<PaymentPreviewModel, PaymentPreviewResponse>().ReverseMap();

        #endregion Payment

        #region Request

        CreateMap<RequestModel, RequestRequest>().ReverseMap();
        CreateMap<RequestModel, RequestResponse>().ReverseMap();
        CreateMap<UpdateRequestRequest, UpdateRequestModel>().ReverseMap();
        CreateMap<RequestPreviewModel, RequestPreviewResponse>().ReverseMap();

        #endregion Request

        #region Requester

        CreateMap<RequesterModel, RequesterRequest>().ReverseMap();
        CreateMap<RequesterModel, RequesterResponse>().ReverseMap();
        CreateMap<UpdateRequesterRequest, UpdateRequesterModel>().ReverseMap();
        CreateMap<RequesterPreviewModel, RequesterPreviewResponse>().ReverseMap();

        #endregion Requester
    }
}