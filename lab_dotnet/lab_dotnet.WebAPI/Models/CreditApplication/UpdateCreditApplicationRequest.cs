using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateCreditApplicationRequest
{
    #region Model

    public Guid? BorrowerId { get; set; }
    public Guid? CreditTypeId { get; set; }
    public Guid? CreditorId { get; set; }
    public DateTime? ApplicationDate { get; set; }
    public int? CreditAmount { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateCreditApplicationRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateCreditApplicationRequestExtension
{
    public static ValidationResult Validate(this UpdateCreditApplicationRequest model)
    {
        return new UpdateCreditApplicationRequest.Validator().Validate(model);
    }
}