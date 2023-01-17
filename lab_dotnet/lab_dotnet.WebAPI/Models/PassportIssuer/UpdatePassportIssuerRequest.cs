using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdatePassportIssuerRequest
{
    #region Model

    public string? Name { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdatePassportIssuerRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdatePassportIssuerRequestExtension
{
    public static ValidationResult Validate(this UpdatePassportIssuerRequest model)
    {
        return new UpdatePassportIssuerRequest.Validator().Validate(model);
    }
}