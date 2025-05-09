using AutoMapper;
using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.EntityFrameworkCore;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi.OretShtese;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.DTOs;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class OretShteseService : IOretShteseService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<OretShteseService> _logger;
        private readonly IMapper _mapper;

        public OretShteseService(IConfiguration configuration, ILogger<OretShteseService> logger, IMapper mapper)
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

        public async Task<PaginatedResponse<OretShteseDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var query = context.tblOretShtese
                    .Include(o => o.StafiShkolles)
                    .AsQueryable();

                var totalRecords = await query.CountAsync();
                var pagedData = await query
                    .Skip((paginationDto.Page - 1) * paginationDto.RecordsPerPage)
                    .Take(paginationDto.RecordsPerPage)
                    .ToListAsync();

                var mapped = _mapper.Map<List<OretShteseDto>>(pagedData);

                return new PaginatedResponse<OretShteseDto>(
                    mapped,
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    totalRecords,
                    "Lista e orëve shtesë u kthye me sukses"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë marrjes së orëve shtesë në mënyrë të paginuar në skemën '{Schema}'", schemaName);
                return new PaginatedResponse<OretShteseDto>(
                    new List<OretShteseDto>(),
                    paginationDto.Page,
                    paginationDto.RecordsPerPage,
                    0
                ).InternalServerError(ex.Message);
            }
        }


        public async Task<Response<bool>> CreateAsync(string schemaName, CreateOretShteseDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var stafiExists = await context.tblStafiShkolles.AnyAsync(s => s.Id == dto.StafiShkollesId);
                if (!stafiExists)
                    return new Response<bool>(false).BadRequest("Stafi nuk ekziston.");

                var oreShtese = _mapper.Map<OretShtese>(dto);
                oreShtese.CreatedAt = DateTime.UtcNow;

                context.tblOretShtese.Add(oreShtese);
                await context.SaveChangesAsync();

                return new Response<bool>(true, true, "Oret shtesë u shtuan me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë krijimit të orëve shtesë në skemën '{Schema}'", schemaName);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var ore = await context.tblOretShtese.FindAsync(id);
                if (ore == null)
                    return new Response<bool>(false).NotFound("Ora shtesë nuk u gjet.");

                context.tblOretShtese.Remove(ore);
                await context.SaveChangesAsync();

                return new Response<bool>(true, true, "Ora shtesë u fshi me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë fshirjes së orës shtesë me ID {Id}", id);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<OretShteseDto>> GetByIdAsync(string schemaName, int id)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var ore = await context.tblOretShtese
                    .Include(o => o.StafiShkolles)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (ore == null)
                    return new Response<OretShteseDto>(null).NotFound("Ora shtesë nuk u gjet.");

                var oreDto = _mapper.Map<OretShteseDto>(ore);
                return new Response<OretShteseDto>(oreDto, true, "Ora shtesë u gjet me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë marrjes së orës shtesë me ID {Id}", id);
                return new Response<OretShteseDto>(null).InternalServerError(ex.Message);
            }
        }

        public async Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateOretShteseDto dto)
        {
            await using var context = GetContext(schemaName);

            try
            {
                var existing = await context.tblOretShtese.FindAsync(id);
                if (existing == null)
                    return new Response<bool>(false).NotFound("Ora shtesë nuk u gjet.");

                existing.DataAngazhimit = dto.DataAngazhimit;
                existing.NrOreve = dto.NrOreve;
                existing.PagesaPerOre = dto.PagesaPerOre;
                existing.Shenime = dto.Shenime;
                existing.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();
                return new Response<bool>(true, true, "Ora shtesë u përditësua me sukses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Gabim gjatë përditësimit të orës shtesë me ID {Id}", id);
                return new Response<bool>(false).InternalServerError(ex.Message);
            }
        }
    }
}

