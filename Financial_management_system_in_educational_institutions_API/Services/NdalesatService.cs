using AutoMapper;
using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi.Ndalesat;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class NdalesatService : INdalesatService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<NdalesatService> _logger;
        private readonly IMapper _mapper;

        public NdalesatService(IConfiguration configuration, ILogger<NdalesatService> logger, IMapper mapper)
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

        public async Task<PaginatedResponse<NdalesatDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var query = context.tblNdalesat.Include(n => n.StafiShkolles).AsQueryable();

                var totalRecords = await query.CountAsync();
                var pagedData = await query
                    .Skip((paginationDto.Page - 1) * paginationDto.RecordsPerPage)
                    .Take(paginationDto.RecordsPerPage)
                    .ToListAsync();

                return new PaginatedResponse<NdalesatDto>(
                    _mapper.Map<List<NdalesatDto>>(pagedData),
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    totalRecords,
                    "Lista e ndalesave u kthye me sukses"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë marrjes së ndalesave.");
                return new PaginatedResponse<NdalesatDto>(
                    new List<NdalesatDto>(),
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    0
                ).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<NdalesatDto>> GetByIdAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var ndalesa = await context.tblNdalesat
                    .Include(n => n.StafiShkolles)
                    .FirstOrDefaultAsync(n => n.Id == id);

                if (ndalesa == null)
                    return new Response<NdalesatDto>(null).NotFound("Ndalesa nuk u gjet.");

                var ndalesaDto = _mapper.Map<NdalesatDto>(ndalesa);
                return new Response<NdalesatDto>(ndalesaDto, true, "Ndalesa u gjet me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë marrjes së ndalesës me ID {Id}", id);
                return new Response<NdalesatDto>(null).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> CreateAsync(string schemaName, CreateNdalesatDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var stafiExists = await context.tblStafiShkolles.AnyAsync(s => s.Id == dto.StafiShkollesId);
                if (!stafiExists)
                    return new Response<bool>(false).BadRequest("Stafi nuk ekziston.");

                var ndalesa = _mapper.Map<Ndalesat>(dto);
                ndalesa.CreatedAt = DateTime.UtcNow;

                context.tblNdalesat.Add(ndalesa);
                await context.SaveChangesAsync();

                return new Response<bool>(true, true, "Ndalesa u shtua me sukses.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë krijimit të ndalesës.");
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateNdalesatDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var ndalesa = await context.tblNdalesat.FindAsync(id);
                if (ndalesa == null)
                    return new Response<bool>(false).NotFound("Ndalesa nuk u gjet.");

                ndalesa.Arsyeja = dto.Arsyeja;
                ndalesa.ShumaNdaleses = dto.ShumaNdaleses;
                ndalesa.Data = dto.Data;
                ndalesa.Aprovuari = dto.Aprovuari;
                ndalesa.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();
                return new Response<bool>(true, true, "Ndalesa u përditësua me sukses.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë përditësimit të ndalesës me ID {Id}", id);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var ndalesa = await context.tblNdalesat.FindAsync(id);
                if (ndalesa == null)
                    return new Response<bool>(false).NotFound("Ndalesa nuk u gjet.");

                context.tblNdalesat.Remove(ndalesa);
                await context.SaveChangesAsync();

                return new Response<bool>(true, true, "Ndalesa u fshi me sukses.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë fshirjes së ndalesës me ID {Id}", id);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }
    }

}
