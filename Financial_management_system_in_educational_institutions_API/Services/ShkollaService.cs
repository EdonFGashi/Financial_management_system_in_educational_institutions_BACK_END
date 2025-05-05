using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.EntityFrameworkCore;

public class ShkollaService : IShkollaService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ShkollaService> _logger;

    public ShkollaService(IConfiguration configuration, ILogger<ShkollaService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    private ApplicationDbContext GetContext(string schemaName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));

        var tenantProvider = new StaticTenantProvider(schemaName);
        return new ApplicationDbContext(optionsBuilder.Options, tenantProvider);
    }

    public async Task<Response<List<Shkolla>>> GetAllAsync(string schemaName)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var shkollat = await context.tblShkolla
                .Include(s => s.Person)
                .Include(s => s.User)
                .ToListAsync();

            return new Response<List<Shkolla>>(shkollat, true, "Shkollat u kthyen me sukses");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë marrjes së shkollave");
            return new Response<List<Shkolla>>(null).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<Shkolla>> GetByIdAsync(string schemaName, int id)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var shkolla = await context.tblShkolla
                .Include(s => s.Person)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.shkollaId == id);

            if (shkolla == null)
                return new Response<Shkolla>(null).NotFound("Shkolla nuk u gjet.");

            return new Response<Shkolla>(shkolla, true, "Shkolla u gjet me sukses.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë kërkimit të shkollës");
            return new Response<Shkolla>(null).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<Shkolla>> CreateAsync(string schemaName, ShkollaDto shkollaDto)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var directorExists = await context.tblPersons.AnyAsync(p => p.NumriPersonal == shkollaDto.drejtori);
            if (!directorExists)
                return new Response<Shkolla>(null).BadRequest("Drejtori i dhënë nuk ekziston.");

            var shkolla = new Shkolla
            {
                emriShkolles = shkollaDto.emriShkolles,
                drejtori = shkollaDto.drejtori,
                AdresaId = shkollaDto.AdresaId,
                nrNxenesve = shkollaDto.nrNxenesve,
                buxhetiAktual = shkollaDto.buxhetiAktual,
                autoNdarja = shkollaDto.autoNdarja,
                UserId = shkollaDto.UserId,
                createdAt = DateTime.UtcNow
            };

            context.tblShkolla.Add(shkolla);
            await context.SaveChangesAsync();

            return new Response<Shkolla>(shkolla, true, "Shkolla u krijua me sukses.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë krijimit të shkollës");
            return new Response<Shkolla>(null).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<Shkolla>> UpdateAsync(string schemaName, int id, UpdateShkollaDto dto)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var existing = await context.tblShkolla.FindAsync(id);
            if (existing == null)
                return new Response<Shkolla>(null).NotFound("Shkolla nuk u gjet.");

            existing.drejtori = dto.drejtori;
            existing.AdresaId = dto.AdresaId;
            existing.nrNxenesve = dto.nrNxenesve;
            existing.buxhetiAktual = dto.buxhetiAktual;
            existing.autoNdarja = dto.autoNdarja;
            existing.updatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return new Response<Shkolla>(existing, true, "Shkolla u përditësua me sukses.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë përditësimit të shkollës");
            return new Response<Shkolla>(null).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<string>> DeleteAsync(string schemaName, int id)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var shkolla = await context.tblShkolla.FindAsync(id);
            if (shkolla == null)
                return new Response<string>(null).NotFound("Shkolla nuk u gjet.");

            context.tblShkolla.Remove(shkolla);
            await context.SaveChangesAsync();

            return new Response<string>("Shkolla u fshi me sukses.", true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë fshirjes së shkollës");
            return new Response<string>(null).InternalServerError(ex.Message);
        }
    }
}
