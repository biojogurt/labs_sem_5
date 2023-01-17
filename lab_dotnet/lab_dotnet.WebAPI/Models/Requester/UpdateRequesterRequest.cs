using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateRequesterRequest
{
    #region Model

    public string? Name { get; set; }
    public string? Inn { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateRequesterRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateRequesterRequestExtension
{
    public static ValidationResult Validate(this UpdateRequesterRequest model)
    {
        return new UpdateRequesterRequest.Validator().Validate(model);
    }
}