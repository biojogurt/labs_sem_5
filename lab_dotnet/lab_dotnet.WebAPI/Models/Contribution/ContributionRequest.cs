using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class ContributionRequest
{
    #region Model

    public Guid ContributorId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime ContributionDate { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<ContributionRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class ContributionRequestExtension
{
    public static ValidationResult Validate(this ContributionRequest model)
    {
        return new ContributionRequest.Validator().Validate(model);
    }
}