using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class InventariAktualService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StafiService> _logger;

        public InventariAktualService(IConfiguration configuration, ILogger<StafiService> logger)
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

        public async Task<PaginatedResponse<StafiShkolles>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto)
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

                return new PaginatedResponse<StafiShkolles>(
                    pagedData,
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    totalRecords,
                    "Lista e stafit u kthye me sukses"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving paginated staff list");
                return new PaginatedResponse<StafiShkolles>(
                    new List<StafiShkolles>(),
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    0
                ).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<StafiShkolles>> CreateAsync(string schemaName, CreateStafiShkollesDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var personExists = await context.tblPersons.AnyAsync(p => p.NumriPersonal == dto.numriPersonal);
                if (!personExists)
                    return new Response<StafiShkolles>(null).BadRequest("Personi nuk ekziston.");

                var shkollaExists = await context.tblShkolla.AnyAsync(s => s.shkollaId == dto.shkollaId);
                if (!shkollaExists)
                    return new Response<StafiShkolles>(null).BadRequest("Shkolla nuk ekziston.");

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
                return new Response<StafiShkolles>(stafi, true, "Stafi u krijua me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë krijimit të stafit në skemën '{Schema}'", schemaName);
                return new Response<StafiShkolles>(null).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<StafiShkolles>> UpdateAsync(string schemaName, int id, UpdateStafiShkollesDto dto)
        {
            await using var context = GetContext(schemaName);

            var existing = await context.tblStafiShkolles.FindAsync(id);
            if (existing == null)
                return new Response<StafiShkolles>(null).NotFound("Stafi nuk u gjet");

            existing.numriPersonal = dto.numriPersonal;
            existing.pozita = dto.pozita;
            existing.paga = dto.paga;
            existing.numriOreve = dto.numriOreve;
            existing.updatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();
            return new Response<StafiShkolles>(existing, true, "Stafi u përditësua me sukses");
        }

        public async Task<Response<string>> DeleteAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            var stafi = await context.tblStafiShkolles.FindAsync(id);
            if (stafi == null)
                return new Response<string>(null).NotFound("Stafi nuk u gjet");

            context.tblStafiShkolles.Remove(stafi);
            await context.SaveChangesAsync();

            _logger.LogInformation("Stafi me ID {Id} u fshi nga skema '{Schema}'", id, schemaName);
            return new Response<string>("Stafi u fshi me sukses", true);
        }

        public async Task<Response<List<StafiShkolles>>> GetAllAsync(string schemaName)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var data = await context.tblStafiShkolles
                    .Include(s => s.Person)
                    .Include(s => s.Shkolla)
                    .ToListAsync();

                return new Response<List<StafiShkolles>>(data, true, "Lista u kthye me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë marrjes së listës së stafit për skemën '{Schema}'", schemaName);
                return new Response<List<StafiShkolles>>(null).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<StafiShkolles>> GetByIdAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            var stafi = await context.tblStafiShkolles
                .Include(s => s.Person)
                .Include(s => s.Shkolla)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stafi == null)
                return new Response<StafiShkolles>(null).NotFound("Stafi nuk u gjet");

            return new Response<StafiShkolles>(stafi, true, "Stafi u gjet me sukses");
        }
    }
}
