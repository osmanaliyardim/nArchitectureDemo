using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using ValidationProblemDetails = Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.ValidationProblemDetails;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;
    
    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string problemDetails = new BusinessProblemDetails(businessException.Message).AsJson();

        return Response.WriteAsync(problemDetails);
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string problemDetails = new InternalServerErrorProblemDetails(exception.Message).AsJson();

        return Response.WriteAsync(problemDetails);
    }

    protected override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string problemDetails = new ValidationProblemDetails(validationException.Errors).AsJson();

        return Response.WriteAsync(problemDetails);
    }
}