using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Inventari;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class InventariAktualService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StafiService> _logger;
        private readonly IMapper _mapper;

        public InventariAktualService(IConfiguration configuration, ILogger<StafiService> logger, IMapper mapper)
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

        public async Task<PaginatedResponse<InventariAktualDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var query = context.tblInventariAktual
                    .Include(s => s.Shkolla)
                    .AsQueryable();

                var totalRecords = await query.CountAsync();
                var pagedData = await query
                    .Skip((paginationDto.Page - 1) * paginationDto.RecordsPerPage)
                    .Take(paginationDto.RecordsPerPage)
                    .ToListAsync();

                return new PaginatedResponse<InventariAktualDto>(
                   _mapper.Map<List<InventariAktualDto>>(pagedData),
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    totalRecords,
                    "Lista e inventarit aktual u kthye me sukses"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving paginated inventari list");
                return new PaginatedResponse<InventariAktualDto>(
                    new List<InventariAktualDto>(),
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    0
                ).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> CreateAsync(string schemaName, CreateInventariAktualDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var shkollaExists = await context.tblShkolla.AnyAsync(s => s.shkollaId == dto.ShkollaId);
                if (!shkollaExists)
                    return new Response<bool>(false).BadRequest("Shkolla nuk ekziston.");

                var inventari = new InventariAktual
                {
                    Emri = dto.Emri,
                    Pershkrimi = dto.Pershkrimi,
                    Sasia = dto.Sasia,
                    Shifra = dto.Shifra,
                    ShkollaId = dto.ShkollaId,
                    CreatedAt = DateTime.UtcNow
                };

                context.tblInventariAktual.Add(inventari);
                await context.SaveChangesAsync();

                _logger.LogInformation("Inventari u krijua me sukses në skemën '{Schema}'", schemaName);
                return new Response<bool>(true, true, "Inventari u krijua me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë krijimit të inventarit në skemën '{Schema}'", schemaName);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateInventariAktualDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var existing = await context.tblInventariAktual.FindAsync(id);
                if (existing == null)
                    return new Response<bool>(false).NotFound("Inventari nuk u gjet");

                existing.Emri = dto.Emri;
                existing.Pershkrimi = dto.Pershkrimi;
                existing.Sasia = dto.Sasia;
                existing.Shifra = dto.Shifra;
                existing.ShkollaId = dto.ShkollaId;
                existing.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();

                return new Response<bool>(true, true, "Inventari u përditësua me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë përditësimit të inventarit me ID {Id} në skemën '{Schema}'", id, schemaName);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var inventari = await context.tblInventariAktual.FindAsync(id);
                if (inventari == null)
                    return new Response<bool>(false).NotFound("Inventari nuk u gjet");

                context.tblInventariAktual.Remove(inventari);
                await context.SaveChangesAsync();

                _logger.LogInformation("Inventari me ID {Id} u fshi nga skema '{Schema}'", id, schemaName);
                return new Response<bool>(true, true, "Inventari aktual u fshi me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë fshirjes së inventarit me ID {Id} në skemën '{Schema}'", id, schemaName);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<InventariAktualDto>> GetByIdAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var inventari = await context.tblInventariAktual
                    .Include(s => s.Shkolla)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (inventari == null)
                    return new Response<InventariAktualDto>(null).NotFound("Inventari nuk u gjet");

                var inventariDto = _mapper.Map<InventariAktualDto>(inventari);

                return new Response<InventariAktualDto>(inventariDto, true, "Inventari u gjet me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë marrjes së inventarit me ID {Id} në skemën '{Schema}'", id, schemaName);
                return new Response<InventariAktualDto>(null).InternalServerError(ex.Message);
            }
        }
    }
}
