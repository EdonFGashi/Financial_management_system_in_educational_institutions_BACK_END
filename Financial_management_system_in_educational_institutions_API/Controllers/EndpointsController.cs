using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class EndpointsController : ControllerBase
{
    private readonly EndpointDataSource _endpointDataSource;
    private readonly ApplicationDbContext _db;


    public EndpointsController(EndpointDataSource endpointDataSource, ApplicationDbContext db)
    {
        _endpointDataSource = endpointDataSource;
        _db = db;
    }

    //[HttpGet("all")]
    //public IActionResult GetAllEndpoints()
    //{
    //    var endpoints = _endpointDataSource.Endpoints
    //        .OfType<RouteEndpoint>()
    //        .Select(e =>
    //        {
    //            var actionDescriptor = e.Metadata.OfType<ControllerActionDescriptor>().FirstOrDefault();
    //            var httpMethod = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods.FirstOrDefault() ?? "ANY";

    //            return new
    //            {
    //                Name = actionDescriptor?.ActionName,
    //                Verb = httpMethod,
    //                Resource = e.RoutePattern.RawText
    //            };
    //        })
    //        .ToList();

    //    return Ok(endpoints);
    //}

    //[HttpPost("reload")]
    //public async Task<IActionResult> ReloadEndpointsAsync()
    //{
    //    var existingOperations = await _db.Operations
    //        .Select(o => new { o.Verb, o.Resource })
    //        .ToListAsync();

    //    var existingSet = new HashSet<string>(
    //        existingOperations.Select(e => $"{e.Verb}:{e.Resource}"),
    //        StringComparer.OrdinalIgnoreCase
    //    );

    //    var endpoints = _endpointDataSource.Endpoints
    //        .OfType<RouteEndpoint>()
    //        .Select(e =>
    //        {
    //            var actionDescriptor = e.Metadata.OfType<ControllerActionDescriptor>().FirstOrDefault();
    //            var httpMethod = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods.FirstOrDefault() ?? "ANY";
    //            var resource = e.RoutePattern.RawText;

    //            return new Operations
    //            {
    //                Name = actionDescriptor?.ActionName ?? "Unknown",
    //                Verb = httpMethod,
    //                Resource = resource
    //            };
    //        })
    //        .Where(op => !existingSet.Contains($"{op.Verb}:{op.Resource}"))
    //        .ToList();

    //    if (endpoints.Any())
    //    {
    //        await _db.Operations.AddRangeAsync(endpoints);
    //        await _db.SaveChangesAsync();
    //    }

    //    return Ok(new { message = "Endpoints checked. New endpoints added.", addedCount = endpoints.Count });
    //}

    [HttpPost("reload")]
    public async Task<IActionResult> ReloadEndpointsAsync()
    {
        var existingOperations = await _db.Operations
            .ToListAsync();

        var existingSet = new HashSet<string>(
            existingOperations.Select(e => $"{e.Verb}:{e.Resource}"),
            StringComparer.OrdinalIgnoreCase
        );

        // Get all current endpoints from ASP.NET Core routing
        var currentEndpoints = _endpointDataSource.Endpoints
            .OfType<RouteEndpoint>()
            .Select(e =>
            {
                var actionDescriptor = e.Metadata.OfType<ControllerActionDescriptor>().FirstOrDefault();
                var httpMethod = e.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods.FirstOrDefault() ?? "ANY";
                var resource = e.RoutePattern.RawText;

                return new Operations
                {
                    Name = actionDescriptor?.ActionName ?? "Unknown",
                    Verb = httpMethod,
                    Resource = resource
                };
            })
            .ToList();

        var currentSet = new HashSet<string>(
            currentEndpoints.Select(e => $"{e.Verb}:{e.Resource}"),
            StringComparer.OrdinalIgnoreCase
        );

        // Add new endpoints
        var toAdd = currentEndpoints
            .Where(e => !existingSet.Contains($"{e.Verb}:{e.Resource}"))
            .ToList();

        if (toAdd.Any())
        {
            await _db.Operations.AddRangeAsync(toAdd);
        }

        // Remove deleted endpoints
        var toRemove = existingOperations
            .Where(e => !currentSet.Contains($"{e.Verb}:{e.Resource}"))
            .ToList();

        if (toRemove.Any())
        {
            _db.Operations.RemoveRange(toRemove);
        }

        // Save all changes
        if (toAdd.Any() || toRemove.Any())
        {
            await _db.SaveChangesAsync();
        }

        return Ok(new
        {
            message = "Endpoints synchronized. New endpoints added and deleted ones removed.",
            addedCount = toAdd.Count,
            removedCount = toRemove.Count
        });
    }

}
