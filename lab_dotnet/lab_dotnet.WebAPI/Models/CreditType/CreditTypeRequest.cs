using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class CreditTypeRequest
{
    #region Model

    public string Name { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<CreditTypeRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class CreditTypeRequestExtension
{
    public static ValidationResult Validate(this CreditTypeRequest model)
    {
        return new CreditTypeRequest.Validator().Validate(model);
    }
}