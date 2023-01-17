using lab_dotnet.WebAPI.Models;
using lab_dotnet.Exceptions;

namespace lab_dotnet.WebAPI.Extensions;

public static class ExceptionExtensions
{
    public static ErrorResponse ToErrorResponse(this LogicException exception)
    {
        return new ErrorResponse(exception.Code!);
    }

    public static ErrorResponse ToErrorResponse(this RepositoryException exception)
    {
        return new ErrorResponse(exception.Code!);
    }
}