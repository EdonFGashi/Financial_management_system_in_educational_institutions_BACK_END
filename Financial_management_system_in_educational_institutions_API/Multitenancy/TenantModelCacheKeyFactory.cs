using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Financial_management_system_in_educational_institutions_API.Data;

namespace Financial_management_system_in_educational_institutions_API.Multitenancy
{
    public class TenantModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context, bool designTime)
        {
            return Create(context);
        }

        public object Create(DbContext context)
        {
            if (context is ApplicationDbContext ctx)
            {
                return (context.GetType(), ctx.Model.GetDefaultSchema());
            }

            return context.GetType();
        }
    }
}
