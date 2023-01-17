using FluentValidation;
using FluentValidation.Results;

namespace lab_dotnet.WebAPI.Models;

public class RequestRequest
{
    #region Model

    public Guid RequesterId { get; set; }
    public Guid BorrowerId { get; set; }
    public DateTime RequestDate { get; set; }

    #endregion Model

    #region Validator

    public class Validator : AbstractValidator<RequestRequest>
    {
        public Validator()
        { }
    }

    #endregion Validator
}

public static class RequestRequestExtension
{
    public static ValidationResult Validate(this RequestRequest model)
    {
        return new RequestRequest.Validator().Validate(model);
    }
}