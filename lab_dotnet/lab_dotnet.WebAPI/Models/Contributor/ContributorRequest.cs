using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class ContributorRequest
{
    #region Model

    public string Name { get; set; }
    public string Inn { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<ContributorRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class ContributorRequestExtension
{
    public static ValidationResult Validate(this ContributorRequest model)
    {
        return new ContributorRequest.Validator().Validate(model);
    }
}