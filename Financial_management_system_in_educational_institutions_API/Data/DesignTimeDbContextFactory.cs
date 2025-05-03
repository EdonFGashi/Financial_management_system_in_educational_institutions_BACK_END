using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Financial_management_system_in_educational_institutions_API.Data;

namespace Financial_management_system_in_educational_institutions_API.Data.DbContextFactory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Load config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // Build context options
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultSQLConnection"));

            // Use static tenant provider with fixed schema 'design'
            var tenantProvider = new StaticTenantProvider("design");

            return new ApplicationDbContext(optionsBuilder.Options, tenantProvider);
        }
    }
}
