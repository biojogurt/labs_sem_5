using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class UpdateRequestRequest
{
    #region Model

    public Guid? RequesterId { get; set; }
    public Guid? BorrowerId { get; set; }
    public DateTime? RequestDate { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<UpdateRequestRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class UpdateRequestRequestExtension
{
    public static ValidationResult Validate(this UpdateRequestRequest model)
    {
        return new UpdateRequestRequest.Validator().Validate(model);
    }
}