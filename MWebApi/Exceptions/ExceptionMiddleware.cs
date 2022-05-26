namespace MWebApi.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (FunctionalException ex)
            {
                context.Response.StatusCode = ex.ErrorCode;
                var response = new
                {
                    errorMessage = ex.Message,
                    functional = true
                };
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                var response = new
                {
                    errorMessage = ex.Message
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
