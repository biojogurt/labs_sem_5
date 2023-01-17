using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateCreditTypeRequest
{
    #region Model

    public string? Name { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateCreditTypeRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateCreditTypeRequestExtension
{
    public static ValidationResult Validate(this UpdateCreditTypeRequest model)
    {
        return new UpdateCreditTypeRequest.Validator().Validate(model);
    }
}