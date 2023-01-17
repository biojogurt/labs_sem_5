using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateCreditorRequest
{
    #region Model

    public string? Name { get; set; }
    public string? Inn { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateCreditorRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateCreditorRequestExtension
{
    public static ValidationResult Validate(this UpdateCreditorRequest model)
    {
        return new UpdateCreditorRequest.Validator().Validate(model);
    }
}