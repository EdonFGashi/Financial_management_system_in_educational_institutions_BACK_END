namespace Financial_management_system_in_educational_institutions_API.Services.Shared
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log headers
            foreach (var header in context.Request.Headers)
            {
                Console.WriteLine($"Header: {header.Key}, Value: {header.Value}");
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

}
