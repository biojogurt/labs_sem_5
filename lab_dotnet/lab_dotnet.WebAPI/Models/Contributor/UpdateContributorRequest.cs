using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateContributorRequest
{
    #region Model

    public string? Name { get; set; }
    public string? Inn { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateContributorRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateContributorRequestExtension
{
    public static ValidationResult Validate(this UpdateContributorRequest model)
    {
        return new UpdateContributorRequest.Validator().Validate(model);
    }
}