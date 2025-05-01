using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.EntityFrameworkCore;

public class TenantSchemaInitializer
{
    private readonly IConfiguration _configuration;

    public TenantSchemaInitializer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task CreateSchemaAndMigrateAsync(string schemaName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));

        // Dynamically use the schema name for migration time
        var tenantProvider = new StaticTenantProvider(schemaName);
        using var context = new ApplicationDbContext(optionsBuilder.Options, tenantProvider);

        var createSchemaSql = $@"
            IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '{schemaName}')
            EXEC('CREATE SCHEMA [{schemaName}]')";

        await context.Database.ExecuteSqlRawAsync(createSchemaSql);
        await context.Database.MigrateAsync();
    }
}
