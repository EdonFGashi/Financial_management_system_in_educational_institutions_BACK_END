using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.EntityFrameworkCore;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using AutoMapper;

public class StafiService : IStafiService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<StafiService> _logger;
    private readonly IMapper _mapper;
    public StafiService(IConfiguration configuration, ILogger<StafiService> logger, IMapper mapper)
    {
        _configuration = configuration;
        _logger = logger;
        _mapper = mapper;
    }

    private ApplicationDbContext GetContext(string schemaName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));

        var tenantProvider = new StaticTenantProvider(schemaName);
        return new ApplicationDbContext(optionsBuilder.Options, tenantProvider);
    }

    public async Task<PaginatedResponse<StafiShkollesDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var query = context.tblStafiShkolles
                .Include(s => s.Person)
                .Include(s => s.Shkolla)
                .AsQueryable();

            var totalRecords = await query.CountAsync();
            var pagedData = await query
                .Skip((paginationDto.Page - 1) * paginationDto.RecordsPerPage)
                .Take(paginationDto.RecordsPerPage)
                .ToListAsync();

            return new PaginatedResponse<StafiShkollesDto>(
                _mapper.Map<List<StafiShkollesDto>>(pagedData),
                paginationDto.Page,
                paginationDto.RecordsPerPage,
                totalRecords,
                "Lista e stafit u kthye me sukses"
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while retrieving paginated staff list");
            return new PaginatedResponse<StafiShkollesDto>(
                new List<StafiShkollesDto>(),
                paginationDto.Page,
                paginationDto.RecordsPerPage,
                0
            ).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<bool>> CreateAsync(string schemaName, CreateStafiShkollesDto dto)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var personExists = await context.tblPersons.AnyAsync(p => p.NumriPersonal == dto.numriPersonal);
            if (!personExists)
                return new Response<bool>(false).BadRequest("Personi nuk ekziston.");

            var shkollaExists = await context.tblShkolla.AnyAsync(s => s.shkollaId == dto.shkollaId);
            if (!shkollaExists)
                return new Response<bool>(false).BadRequest("Shkolla nuk ekziston.");

            var stafi = new StafiShkolles
            {
                numriPersonal = dto.numriPersonal,
                pozita = dto.pozita,
                paga = dto.paga,
                numriOreve = dto.numriOreve,
                shkollaId = dto.shkollaId,
                createdAt = DateTime.UtcNow
            };

            context.tblStafiShkolles.Add(stafi);
            await context.SaveChangesAsync();

            _logger.LogInformation("Stafi u krijua me sukses në skemën '{Schema}'", schemaName);
            return new Response<bool>(true, true, "Stafi u krijua me sukses");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë krijimit të stafit në skemën '{Schema}'", schemaName);
            return new Response<bool>(false).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateStafiShkollesDto dto)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var existing = await context.tblStafiShkolles.FindAsync(id);
            if (existing == null)
                return new Response<bool>(false).NotFound("Stafi nuk u gjet");

            existing.numriPersonal = dto.numriPersonal;
            existing.pozita = dto.pozita;
            existing.paga = dto.paga;
            existing.numriOreve = dto.numriOreve;
            existing.updatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return new Response<bool>(true, true, "Stafi u përditësua me sukses");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë përditësimit të stafit me ID {Id} në skemën '{Schema}'", id, schemaName);
            return new Response<bool>(false).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<bool>> DeleteAsync(string schemaName, int id)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var stafi = await context.tblStafiShkolles.FindAsync(id);
            if (stafi == null)
                return new Response<bool>(false).NotFound("Stafi nuk u gjet");

            context.tblStafiShkolles.Remove(stafi);
            await context.SaveChangesAsync();

            _logger.LogInformation("Stafi me ID {Id} u fshi nga skema '{Schema}'", id, schemaName);
            return new Response<bool>(true, true, "Stafi u fshi me sukses");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë fshirjes së stafit me ID {Id} në skemën '{Schema}'", id, schemaName);
            return new Response<bool>(false).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<StafiShkollesDto>> GetByIdAsync(string schemaName, int id)
    {
        await using var context = GetContext(schemaName);

        try
        {
            var stafi = await context.tblStafiShkolles
                .Include(s => s.Person)
                .Include(s => s.Shkolla)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stafi == null)
                return new Response<StafiShkollesDto>(null).NotFound("Stafi nuk u gjet");

            var stafiDto = _mapper.Map<StafiShkollesDto>(stafi);

            return new Response<StafiShkollesDto>(stafiDto, true, "Stafi u gjet me sukses");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gabim gjatë marrjes së stafit me ID {Id} në skemën '{Schema}'", id, schemaName);
            return new Response<StafiShkollesDto>(null).InternalServerError(ex.Message);
        }
    }
}
