using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class CreditorRequest
{
    #region Model

    public string Name { get; set; }
    public string Inn { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<CreditorRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class CreditorRequestExtension
{
    public static ValidationResult Validate(this CreditorRequest model)
    {
        return new CreditorRequest.Validator().Validate(model);
    }
}