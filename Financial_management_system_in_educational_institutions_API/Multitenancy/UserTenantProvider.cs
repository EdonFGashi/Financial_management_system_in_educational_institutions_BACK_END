using System.Security.Claims;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Financial_management_system_in_educational_institutions_API.Multitenancy
{
    public class UserTenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserTenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetSchema()
        {
            var tenant = _httpContextAccessor.HttpContext?.User?.FindFirst("tenant")?.Value;
            return tenant?.ToLowerInvariant() ?? "default"; // fallback to 'default' schema if not found
        }

        public string GetMunicipalityName() => GetSchema();
    }
}
