using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateContributionRequest
{
    #region Model

    public Guid? ContributorId { get; set; }
    public Guid? BorrowerId { get; set; }
    public DateTime? ContributionDate { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateContributionRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateContributionRequestExtension
{
    public static ValidationResult Validate(this UpdateContributionRequest model)
    {
        return new UpdateContributionRequest.Validator().Validate(model);
    }
}