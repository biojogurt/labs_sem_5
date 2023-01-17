using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateAppUserRequest
{
    #region Model

    public string? FullName { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateAppUserRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateAppUserRequestExtension
{
    public static ValidationResult Validate(this UpdateAppUserRequest model)
    {
        return new UpdateAppUserRequest.Validator().Validate(model);
    }
}