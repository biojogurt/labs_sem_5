using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class PassportIssuerRequest
{
    #region Model

    public string Name { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<PassportIssuerRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class PassportIssuerRequestExtension
{
    public static ValidationResult Validate(this PassportIssuerRequest model)
    {
        return new PassportIssuerRequest.Validator().Validate(model);
    }
}