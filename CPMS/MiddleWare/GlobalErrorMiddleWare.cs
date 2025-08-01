using Domain.Exceptions;
using Shared.ErrorDetails;

namespace CPMS.MiddleWare
{
    public class GlobalErrorMiddleWare
    {
        private readonly ILogger<GlobalErrorMiddleWare> _logger;
        private readonly RequestDelegate _next;
        public GlobalErrorMiddleWare(ILogger<GlobalErrorMiddleWare> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                await handlingNotFoundEndPoint(context);
               
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
               await handlingNotFoundEndPoint(context, ex);
            }
        }

        private async Task handlingNotFoundEndPoint(HttpContext context,Exception ex)
        {
            var response = new ErrorDetails()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ErrorMessage = ex.Message
            };
            response.StatusCode = ex switch
            {
                UnAuthorizedException => StatusCodes.Status401Unauthorized,
                ValidationException => HandlingValidationException((ValidationException)ex, response),
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.StatusCode = response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
        private static int HandlingValidationException(ValidationException ex, ErrorDetails response)
            {
                response.error = ex.Errors;
                return StatusCodes.Status400BadRequest;
            }
        private async Task handlingNotFoundEndPoint(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                context.Response.ContentType = "application/json";
                var response = new ErrorDetails()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Resource not found"
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
       
    }
}
