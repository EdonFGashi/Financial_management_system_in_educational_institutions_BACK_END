using Financial_management_system_in_educational_institutions_API.Data;
using System;
using System.Security.Claims;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class DynamicAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public DynamicAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
        {

            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            Console.WriteLine($"Token: {token}");



            // 0. Allow anonymous access for specific endpoints
            var path = context.Request.Path.Value?.Trim('/').ToLower();

            var anonymousPaths = new[]
            {
        "api/accounts/login",
        "api/accounts/register"
    };

            if (anonymousPaths.Contains(path))
            {
                await _next(context);
                return;
            }

            // 1. Extract email from JWT
            //var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            //var email = context.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            var email = "doni@gmail.com";

  
    //        var email = context.User.Claims.FirstOrDefault(c =>
    //c.Type == ClaimTypes.Email || c.Type == "email")?.Value;


            if (string.IsNullOrEmpty(email))
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync($"Unauthorized: No email in token. Email value was: {email ?? "null"}");
                    Console.WriteLine($"Email from token: {email}");
                }
                return;
            }

            // 2. Get request path and HTTP method
            var method = context.Request.Method.ToUpper();

            // 3. Find matching operation
            var operation = dbContext.Operations
                .FirstOrDefault(op => op.Resource.ToLower() == path && op.Verb.ToUpper() == method);

            if (operation == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Operation not found.");
                return;
            }

            // 4. Get user ID from AspNetUsers
            var user = dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: User not found.");
                return;
            }

            // 5. Get claims for user (ClaimId)
            var userClaimIds = dbContext.UserClaims
                .Where(c => c.UserId == user.Id)
                .Select(c => c.Id)
                .ToList();

            // 6. Check if any RolePermission links those claims to the operation
            var hasPermission = dbContext.RolePermissions
                .Any(rp => userClaimIds.Contains(rp.ClaimId) && rp.OperationId == operation.OperationId);

            if (!hasPermission)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: You don't have permission.");
                return;
            }

            // 7. All good — continue
            await _next(context);
        }

    }

}
