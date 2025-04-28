// Services/PorositeService.cs
using System;
using System.Collections.Generic;
using System.Linq;                    // for .Where(), .Contains()
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore; // for .Include()/.ThenInclude()
using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Services.Interfaces;

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

        public async Task<IEnumerable<PorositeDto>> GetPorositeAsync(
            string? pershkrimi,
            string? kompania,
            string? shkolla,
            DateTime? data,
            string? status)
        {
            var query = _context.tblPorosite
                .Include(p => p.Shkolla)
                .Include(p => p.Produkti)
                    .ThenInclude(pr => pr.Kompania)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pershkrimi))
                query = query.Where(p =>
                    p.Produkti.Emri.Contains(pershkrimi));

            if (!string.IsNullOrWhiteSpace(kompania))
                query = query.Where(p =>
                    p.Produkti.Kompania.Emri.Contains(kompania));

            if (!string.IsNullOrWhiteSpace(shkolla))
                query = query.Where(p =>
                    p.Shkolla.emriShkolles.Contains(shkolla));

            if (data.HasValue)
                query = query.Where(p =>
                    p.DataPorosise.Date == data.Value.Date);

            if (!string.IsNullOrWhiteSpace(status))
            {
                if (status.Equals("paguar", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(p => p.Paguar);
                else if (status.Equals("fshire", StringComparison.OrdinalIgnoreCase))
                    query = query.Where(p => !p.Paguar);
            }

            var entities = await query.ToListAsync();
            return _mapper.Map<IEnumerable<PorositeDto>>(entities);
        }
    }
}
