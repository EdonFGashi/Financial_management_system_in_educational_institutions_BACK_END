using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class RaportiService : IRaportiService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RaportiService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<List<RaportetDto>>> GetAllRaportetAsync(
            string? kompania,
            string? shkolla,
            DateTime? ngaData,
            DateTime? deriData,
            List<string>? statuset
            )
        {
            try
            {
                var query = _context.tblPorosite
                    .Include(p => p.Shkolla)
                    .Include(p => p.Produkti)
                        .ThenInclude(pr => pr.Kompania)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(kompania))
                    query = query.Where(p => p.Produkti.Kompania.EmriKompanis.Contains(kompania));

                if (!string.IsNullOrEmpty(shkolla))
                    query = query.Where(p => p.Shkolla.emriShkolles.Contains(shkolla));

                if (ngaData.HasValue)
                    query = query.Where(p => p.DataPorosise >= ngaData.Value);

                if (deriData.HasValue)
                    query = query.Where(p => p.DataPorosise <= deriData.Value);

                if (statuset != null && statuset.Any())
                    query = query.Where(p => statuset.Contains(p.Statusi));

                var porosite = await query.ToListAsync();
                var mapped = _mapper.Map<List<RaportetDto>>(porosite);

                return new Response<List<RaportetDto>>(mapped, true, "Raportet u kthyen me sukses.");

            }
            catch (Exception ex)
            {
                return new Response<List<RaportetDto>>(null).InternalServerError($"Gabim gjatë filtrimit të raporteve: {ex.Message}");
            }
        }


        public async Task<Response<string>> GenerateRaportAsync(List<int> selectedIds, string emriRaportit, string pathRaportit)
        {
            try
            {
                // Simulate, qetu duhet logjika
                

                
                var porosite = await _context.tblPorosite
                    .Where(p => selectedIds.Contains(p.Id))
                    .ToListAsync();

                if (!porosite.Any())
                    return new Response<string>(null).NotFound("Nuk u gjetën të dhëna për raport.");

                return new Response<string>($"Raporti '{emriRaportit}' u gjenerua me sukses në {pathRaportit}.", true);
            }
            catch (Exception ex)
            {
                return new Response<string>(null).InternalServerError($"Gabim gjatë gjenerimit të raportit: {ex.Message}");
            }
        }
    }
}
