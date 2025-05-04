using System.Text.RegularExpressions;
using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class TenantSchemaInitializer
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TenantSchemaInitializer> _logger;

    public TenantSchemaInitializer(IConfiguration configuration, ILogger<TenantSchemaInitializer> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task CreateSchemaAndMigrateAsync(string schemaName)
    {
        if (string.IsNullOrWhiteSpace(schemaName))
            throw new ArgumentException("Schema name cannot be null or empty.", nameof(schemaName));

        schemaName = Regex.Replace(schemaName.Trim().ToLowerInvariant(), @"[^\w]", "");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));

        var tenantProvider = new StaticTenantProvider(schemaName);

        using var context = new ApplicationDbContext(optionsBuilder.Options, tenantProvider);

        var createSchemaSql = $@"
    IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '{schemaName}')
    EXEC('CREATE SCHEMA [{schemaName}]')";

        try
        {
            _logger.LogInformation("Creating schema '{Schema}' if not exists...", schemaName);
            await context.Database.ExecuteSqlRawAsync(createSchemaSql);

            _logger.LogInformation("Replicating tables from 'design' to '{Schema}'...", schemaName);

            // ✅ Fixed version - interpolate directly instead of passing as param
            var copyStructureSql = $@"
DECLARE @sql NVARCHAR(MAX) = '';
DECLARE @schemaName NVARCHAR(128) = '{schemaName}';

SELECT @sql += '
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = ''' + @schemaName + ''' AND TABLE_NAME = ''' + t.name + ''')
SELECT TOP 0 * INTO [' + @schemaName + '].[' + t.name + '] FROM [design].[' + t.name + '];'
FROM sys.tables t
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'design';

EXEC(@sql);";

            await context.Database.ExecuteSqlRawAsync(copyStructureSql);

            _logger.LogInformation("Running EF Core migrations for schema '{Schema}'...", schemaName);
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while initializing schema '{Schema}'", schemaName);
            throw;
        }
    }

}
