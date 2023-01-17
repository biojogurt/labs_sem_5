using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateJobTitleRequest
{
    #region Model

    public string? Name { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateJobTitleRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateJobTitleRequestExtension
{
    public static ValidationResult Validate(this UpdateJobTitleRequest model)
    {
        return new UpdateJobTitleRequest.Validator().Validate(model);
    }
}