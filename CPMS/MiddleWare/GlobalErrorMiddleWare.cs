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
                if(context.Response.StatusCode == StatusCodes.Status404NotFound)
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
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                var response = new ErrorDetails()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message
                };
                response.StatusCode =ex switch
                {
                    _ => StatusCodes.Status500InternalServerError
                };
                context.Response.StatusCode = response.StatusCode;
                await context.Response.WriteAsJsonAsync(response);
            }
        }

    }
}
