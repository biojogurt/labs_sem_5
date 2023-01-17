using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class CreditRequest
{
    #region Model

    public Guid CreditApplicationId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int InterestRate { get; set; }
    public Guid BorrowerId { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<CreditRequest>
    {
        public Validator()
        {
            RuleFor(x => x.InterestRate)
                    .InclusiveBetween(1, 100)
                    .WithMessage("Must be between 1 and 100 inclusively");
        }
    }

    #endregion Validator
}

public static class CreditRequestExtension
{
    public static ValidationResult Validate(this CreditRequest model)
    {
        return new CreditRequest.Validator().Validate(model);
    }
}