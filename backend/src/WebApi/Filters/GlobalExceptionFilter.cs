using backend.src.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        int statusCode = 500; // default

        if (context.Exception is AppException appEx)
        {
            statusCode = appEx.StatusCode;
        }

        var response = new
        {
            message = context.Exception.Message,
            statusCode = statusCode,
            error = true
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }
}

