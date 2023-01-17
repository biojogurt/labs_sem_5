using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class JobTitleRequest
{
    #region Model

    public string Name { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<JobTitleRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class JobTitleRequestExtension
{
    public static ValidationResult Validate(this JobTitleRequest model)
    {
        return new JobTitleRequest.Validator().Validate(model);
    }
}