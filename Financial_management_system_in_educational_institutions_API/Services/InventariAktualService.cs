using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi;
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

        public async Task<Response<InventariAktualDto>> CreateAsync(string schemaName, CreateStafiShkollesDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var shkollaExists = await context.tblShkolla.AnyAsync(s => s.shkollaId == dto.shkollaId);
                if (!shkollaExists)
                    return new Response<InventariAktualDto>(null).BadRequest("Shkolla nuk ekziston.");

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
                return new Response<InventariAktualDto>(stafi, true, "Stafi u krijua me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë krijimit të stafit në skemën '{Schema}'", schemaName);
                return new Response<InventariAktualDto>(null).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<InventariAktualDto>> UpdateAsync(string schemaName, int id, UpdateInventariAktualDto dto)
        {
            await using var context = GetContext(schemaName);

            var existing = await context.tblInventariAktual.FindAsync(id);
            if (existing == null)
                return new Response<InventariAktualDto>(null).NotFound("Stafi nuk u gjet");

            existing.Emri = dto.Emri;
            existing.Pershkrimi = dto.Pershkrimi;
            existing.Sasia = dto.Sasia;
            existing.Shifra = dto.Shifra;
            existing.ShkollaId = dto.ShkollaId;
            existing.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            var existingDto = _mapper.Map<InventariAktualDto>(existing);
            return new Response<InventariAktualDto>(existingDto, true, "Stafi u përditësua me sukses");
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

        public async Task<Response<List<InventariAktualDto>>> GetAllAsync(string schemaName)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var data = await context.tblStafiShkolles
                    .Include(s => s.Person)
                    .Include(s => s.Shkolla)
                    .ToListAsync();

                var inventariDto = _mapper.Map<List<InventariAktualDto>>(data);

                return new Response<List<InventariAktualDto>>(inventariDto, true, "Lista u kthye me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë marrjes së listës së stafit për skemën '{Schema}'", schemaName);
                return new Response<List<InventariAktualDto>>(null).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<InventariAktualDto>> GetByIdAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            var inventari = await context.tblInventariAktual
                .Include(s => s.Shkolla)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (inventari == null)
                return new Response<InventariAktualDto>(null).NotFound("Stafi nuk u gjet");

            var inventariDto = _mapper.Map<InventariAktualDto>(inventari);

            return new Response<InventariAktualDto>(inventariDto, true, "Stafi u gjet me sukses");
        }
    }
}
