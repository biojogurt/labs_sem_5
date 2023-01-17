using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class BorrowerRequest
{
    #region Model

    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
    public Guid PassportIssuerId { get; set; }
    public DateTime PassportIssueDate { get; set; }
    public string FullName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Inn { get; set; }
    public string Snils { get; set; }
    public string RegistrationAddress { get; set; }
    public string? ResidentialAddress { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<BorrowerRequest>
    {
        public Validator()
        {
            RuleFor(x => x.PassportSerial)
                    .InclusiveBetween(1000, 9999)
                    .WithMessage("Must be between 1000 and 9999 inclusively");
            RuleFor(x => x.PassportNumber)
                    .InclusiveBetween(100000, 999999)
                    .WithMessage("Must be between 100000 and 999999 inclusively");
            RuleFor(x => x.Birthdate)
                    .LessThan(x => x.PassportIssueDate)
                    .WithMessage("Must be less than PassportIssueDate");
        }
    }

    #endregion Validator
}

public static class BorrowerRequestExtension
{
    public static ValidationResult Validate(this BorrowerRequest model)
    {
        return new BorrowerRequest.Validator().Validate(model);
    }
}