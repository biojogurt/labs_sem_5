using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class CreditApplicationRequest
{
    #region Model

    public Guid BorrowerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid CreditorId { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int CreditAmount { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<CreditApplicationRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class CreditApplicationRequestExtension
{
    public static ValidationResult Validate(this CreditApplicationRequest model)
    {
        return new CreditApplicationRequest.Validator().Validate(model);
    }
}