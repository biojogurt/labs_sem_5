using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdatePaymentRequest
{
    #region Model

    public Guid? CreditId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public int? PaymentAmount { get; set; }
    public int? RemainingAmount { get; set; }
    public int? Debt { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdatePaymentRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Debt)
                    .LessThanOrEqualTo(x => x.RemainingAmount)
                    .WithMessage("Must be less than or equal to RemainingAmount");
        }
    }

    #endregion Validator
}

public static class UpdatePaymentRequestExtension
{
    public static ValidationResult Validate(this UpdatePaymentRequest model)
    {
        return new UpdatePaymentRequest.Validator().Validate(model);
    }
}