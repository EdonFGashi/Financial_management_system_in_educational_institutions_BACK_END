using Financial_management_system_in_educational_institutions_API.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Financial_management_system_in_educational_institutions_API.Services.Shared
{
    public class DynamicAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public DynamicAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

    //    public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
    //    {

    //        var token = context.Request.Headers["Authorization"].FirstOrDefault();
    //        Console.WriteLine($"Token: {token}");



    //        // 0. Allow anonymous access for specific endpoints
    //        var path = context.Request.Path.Value?.Trim('/').ToLower();

    //        var anonymousPaths = new[]
    //        {
    //    "api/accounts/login",
    //    "api/accounts/register"
    //};

    //        if (anonymousPaths.Contains(path))
    //        {
    //            await _next(context);
    //            return;
    //        }

    //        // 1. Extract email from JWT
    //        //var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    //        var email = context.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
    //        //var email = "doni@gmail.com";

  
    ////        var email = context.User.Claims.FirstOrDefault(c =>
    ////c.Type == ClaimTypes.Email || c.Type == "email")?.Value;


    //        if (string.IsNullOrEmpty(email))
    //        {
    //            if (!context.Response.HasStarted)
    //            {
    //                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //                context.Response.ContentType = "text/plain";
    //                await context.Response.WriteAsync($"Unauthorized: No email in token. Email value was: {email ?? "null"}");
    //                Console.WriteLine($"Email from token: {email}");
    //            }
    //            return;
    //        }

    //        // 2. Get request path and HTTP method
    //        var method = context.Request.Method.ToUpper();

    //        // 3. Find matching operation
    //        var operation = dbContext.Operations
    //            .FirstOrDefault(op => op.Resource.ToLower() == path && op.Verb.ToUpper() == method);

    //        if (operation == null)
    //        {
    //            context.Response.StatusCode = StatusCodes.Status403Forbidden;
    //            await context.Response.WriteAsync("Forbidden: Operation not found.");
    //            return;
    //        }

    //        // 4. Get user ID from AspNetUsers
    //        var user = dbContext.Users.FirstOrDefault(u => u.Email == email);
    //        if (user == null)
    //        {
    //            context.Response.StatusCode = StatusCodes.Status403Forbidden;
    //            await context.Response.WriteAsync("Forbidden: User not found.");
    //            return;
    //        }

    //        // 5. Get claims for user (ClaimId)
    //        var userClaimIds = dbContext.UserClaims
    //            .Where(c => c.UserId == user.Id)
    //            .Select(c => c.Id)
    //            .ToList();

    //        // 6. Check if any RolePermission links those claims to the operation
    //        var hasPermission = dbContext.RolePermissions
    //            .Any(rp => userClaimIds.Contains(rp.ClaimId) && rp.OperationId == operation.OperationId);

    //        if (!hasPermission)
    //        {
    //            context.Response.StatusCode = StatusCodes.Status403Forbidden;
    //            await context.Response.WriteAsync("Forbidden: You don't have permission.");
    //            return;
    //        }

    //        // 7. All good — continue
    //        await _next(context);
    //    }
public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
    {
            // Proceed with your existing logic
            var method = context.Request.Method.ToUpper();
            var path = context.Request.Path.Value?.Trim('/');


            var anonymousPaths = new[]
            {
            "api/accounts/login",
            "api/accounts/create"
        };

            if (anonymousPaths.Contains(path))
            {
                await _next(context);
                return;
            }

            var tokenHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (string.IsNullOrEmpty(tokenHeader) || !tokenHeader.StartsWith("Bearer "))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Nuk u arrit autorizimi (nuk u gjet tokeni) !");
            return;
        }

        var token = tokenHeader.Substring("Bearer ".Length).Trim();

        // Parse and validate token manually
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var key = Encoding.UTF8.GetBytes("JDJD39FJ9FH39FJ20SJEBFKJDNCBVMWX749948N37JNDNCUWNKVYRUCCC73847NCJKANZAQURHVMDKW83URNFKD"); // Use your real key!

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true // Optional: checks token expiration
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            if (string.IsNullOrEmpty(email))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Nuk u arrit autorizimi, nuk u gjet email në token !");
                return;
            }

            Console.WriteLine($"Extracted email: {email}");



                //var operation = dbContext.Operations
                //    .FirstOrDefault(op => op.Resource.ToLower() == path && op.Verb.ToUpper() == method);
                var normalizedPath = NormalizePath(path);
                Console.WriteLine($"NORMALIZED PATH: {normalizedPath}");
                var operation = dbContext.Operations
    .FirstOrDefault(op => op.Resource == normalizedPath && op.Verb.ToUpper() == method);


                if (operation == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Ky veprim nuk u gjet si veprim i lejushëm në server !");
                return;
            }

            var user = dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Useri me këtë email nuk u gjet në bazën e të dhënave !");
                return;
            }

            var userClaimIds = dbContext.UserClaims
                .Where(c => c.UserId == user.Id)
                .Select(c => c.Id)
                .ToList();

            var hasPermission = dbContext.RolePermissions
                .Any(rp => userClaimIds.Contains(rp.ClaimId) && rp.OperationId == operation.OperationId);

            if (!hasPermission)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Kërkesa u refuzua, ju nuk jeni të autorizuar për ta bërë këtë veprim !");
                return;
            }

            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync($"Unauthorized: Invalid token. {ex.Message}");
        }
    }


        private static string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return "";

            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length > 0 && int.TryParse(segments[^1], out _))
            {
                segments[^1] = "{id:int}";
            }

            return string.Join('/', segments);
        }



    }


}
