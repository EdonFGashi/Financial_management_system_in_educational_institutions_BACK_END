using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Financial_management_system_in_educational_institutions_API.Multitenancy;

namespace Financial_management_system_in_educational_institutions_API.Data.DbContextFactory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultSQLConnection"));

            // Static schema for migration purposes
            var tenantProvider = new StaticTenantProvider("design");

            return new ApplicationDbContext(optionsBuilder.Options, tenantProvider);
        }
    }
}