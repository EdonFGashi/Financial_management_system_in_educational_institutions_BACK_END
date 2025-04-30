using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Interfaces;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class PorositeService : IPorositeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PorositeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<List<PorositeDto>>> GetPorositeAsync(
            string? pershkrimi,
            string? kompania,
            string? shkolla,
            DateTime? data,
            string? status)
        {
            try
            {
                var query = _context.tblPorosite
                    .Include(p => p.Shkolla)
                    .Include(p => p.Produkti)
                        .ThenInclude(pr => pr.Kompania)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(pershkrimi))
                    query = query.Where(p => p.Produkti.Emri.Contains(pershkrimi));

                if (!string.IsNullOrWhiteSpace(kompania))
                    query = query.Where(p => p.Produkti.Kompania.Emri.Contains(kompania));

                if (!string.IsNullOrWhiteSpace(shkolla))
                    query = query.Where(p => p.Shkolla.emriShkolles.Contains(shkolla));

                if (data.HasValue)
                    query = query.Where(p => p.DataPorosise.Date == data.Value.Date);

                if (!string.IsNullOrWhiteSpace(status))
                    query = query.Where(p => p.Statusi.Equals(status, StringComparison.OrdinalIgnoreCase));

                var porosite = await query.ToListAsync();
                var resultDto = _mapper.Map<List<PorositeDto>>(porosite);

                return new Response<List<PorositeDto>>(resultDto, true, "Porositë u kthyen me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<List<PorositeDto>>(null).InternalServerError($"Gabim gjatë marrjes së porosive: {ex.Message}");
            }
        }

        public async Task<Response<string>> PaguajPorosiAsync(int id)
        {
            try
            {
                var porosi = await _context.tblPorosite.FindAsync(id);
                if (porosi == null)
                    return new Response<string>(null).NotFound("Porosia nuk u gjet.");

                porosi.Statusi = "Paguar";
                porosi.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return new Response<string>("Porosia u pagua me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<string>(null).InternalServerError($"Gabim gjatë pagesës: {ex.Message}");
            }
        }

        public async Task<Response<string>> FshijPorosiAsync(int id)
        {
            try
            {
                var porosi = await _context.tblPorosite.FindAsync(id);
                if (porosi == null)
                    return new Response<string>(null).NotFound("Porosia nuk u gjet.");

                porosi.Statusi = "Fshire";
                porosi.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return new Response<string>("Porosia u fshi me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<string>(null).InternalServerError($"Gabim gjatë fshirjes: {ex.Message}");
            }
        }
    }
}
