using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class LoginUserRequest
{
    #region Model

    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<LoginUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                    .EmailAddress()
                    .WithMessage("Must be email");
        }
    }

    #endregion Validator
}

public static class LoginUserRequestExtension
{
    public static ValidationResult Validate(this LoginUserRequest model)
    {
        return new LoginUserRequest.Validator().Validate(model);
    }
}