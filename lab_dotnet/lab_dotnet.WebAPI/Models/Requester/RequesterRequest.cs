using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class RequesterRequest
{
    #region Model

    public string Name { get; set; }
    public string Inn { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<RequesterRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class RequesterRequestExtension
{
    public static ValidationResult Validate(this RequesterRequest model)
    {
        return new RequesterRequest.Validator().Validate(model);
    }
}