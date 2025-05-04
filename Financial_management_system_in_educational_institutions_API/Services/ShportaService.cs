using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shporta;
using Microsoft.EntityFrameworkCore;
using System;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class ShportaService : IShportaService
    {
        private readonly ApplicationDbContext _context;

        public ShportaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShportaDto>> GetShportaByShkollaIdAsync(int shkollaId)
        {
            return await _context.Shportat
                .Where(s => s.ShkollaId == shkollaId)
                .Include(s => s.Produkti)
                .Select(s => new ShportaDto
                {
                    Id = s.Id,
                    ProduktiId = s.ProduktiId,
                    EmriProduktit = s.Produkti.Emri,
                    Sasia = s.Sasia,
                    foto = s.foto,
                    Statusi = s.Statusi
                }).ToListAsync();
        }

        public async Task AddToShportaAsync(int shkollaId, CreateShportaDto dto)
        {
            var shporta = new Shporta
            {
                ProduktiId = dto.ProduktiId,
                ShkollaId = shkollaId,
                Sasia = dto.Sasia,
                Statusi = "Jo Aprovuar"
            };

            _context.Shportat.Add(shporta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShportaAsync(UpdateShportaDto dto)
        {
            var shporta = await _context.Shportat.FindAsync(dto.Id);
            if (shporta == null) throw new Exception("Nuk u gjet");

            shporta.Sasia = dto.Sasia;
            shporta.Statusi = dto.Statusi;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteFromShportaAsync(int id)
        {
            var shporta = await _context.Shportat.FindAsync(id);
            if (shporta == null) throw new Exception("Nuk u gjet");

            _context.Shportat.Remove(shporta);
            await _context.SaveChangesAsync();
        }
    }
}
