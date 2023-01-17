using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class RegisterUserRequest
{
    #region Model

    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    public int AccessLevel { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<RegisterUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                    .EmailAddress()
                    .WithMessage("Must be email");

            RuleFor(x => x.AccessLevel)
                    .InclusiveBetween(1, 3)
                    .WithMessage("Must be between 1 and 3 inclusively");
        }
    }

    #endregion Validator
}

public static class RegisterUserRequestExtension
{
    public static ValidationResult Validate(this RegisterUserRequest model)
    {
        return new RegisterUserRequest.Validator().Validate(model);
    }
}