using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class ApiResponseFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {}

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var statusCode = objectResult.StatusCode ?? 200;

            var wrappedResponse = new
            {
                data = objectResult.Value,
                statusCode = statusCode,
                timestamp = DateTime.UtcNow.ToString("o")
            };

            context.Result = new ObjectResult(wrappedResponse)
            {
                StatusCode = statusCode
            };
        }
        else if (context.Result is EmptyResult)
        {
            var wrappedResponse = new
            {
                data = (object)null,
                statusCode = 204,
                timestamp = DateTime.UtcNow.ToString("o")
            };

            context.Result = new ObjectResult(wrappedResponse)
            {
                StatusCode = 204
            };
        }
    }
}
