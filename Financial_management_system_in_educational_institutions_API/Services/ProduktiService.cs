using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class ProduktiService : IProduktiService
    {
        private readonly ApplicationDbContext _context;

        public ProduktiService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Produkti>>> GetAllAsync()
        {
            try
            {
                var produktet = await _context.tblProdukti.ToListAsync();
                return new Response<List<Produkti>>(produktet, true, "Produktet u kthyen me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<List<Produkti>>(null).InternalServerError($"Gabim gjatë marrjes së produkteve: {ex.Message}");
            }
        }

        public async Task<Response<Produkti>> GetByIdAsync(int id)
        {
            try
            {
                var produkti = await _context.tblProdukti.FindAsync(id);
                if (produkti == null)
                    return new Response<Produkti>(null).NotFound("Produkti nuk u gjet.");

                return new Response<Produkti>(produkti, true, "Produkti u gjet me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Produkti>(null).InternalServerError($"Gabim gjatë kërkimit të produktit: {ex.Message}");
            }
        }

        public async Task<Response<Produkti>> CreateAsync(ProduktiDto produktiDto)
        {
            try
            {
                var produkti = new Produkti
                {
                    Emri = produktiDto.Emri,
                    Pershkrimi = produktiDto.Pershkrimi,
                    Cmimi = produktiDto.Cmimi,
                    SasiaNeStok = produktiDto.SasiaNeStok,
                    Origjina = produktiDto.Origjina,
                    Prodhuesi = produktiDto.Prodhuesi,
                    Fotografia = produktiDto.Fotografia,
                    KompaniaId = produktiDto.KompaniaId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.tblProdukti.Add(produkti);
                await _context.SaveChangesAsync();

                return new Response<Produkti>(produkti, true, "Produkti u shtua me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Produkti>(null).InternalServerError($"Gabim gjatë shtimit të produktit: {ex.Message}");
            }
        }

        public async Task<Response<Produkti>> UpdateAsync(int id, ProduktiDto produktiDto)
        {
            try
            {
                var produkti = await _context.tblProdukti.FindAsync(id);
                if (produkti == null)
                    return new Response<Produkti>(null).NotFound("Produkti nuk u gjet.");

                produkti.Emri = produktiDto.Emri;
                produkti.Pershkrimi = produktiDto.Pershkrimi;
                produkti.Cmimi = produktiDto.Cmimi;
                produkti.SasiaNeStok = produktiDto.SasiaNeStok;
                produkti.Origjina = produktiDto.Origjina;
                produkti.Prodhuesi = produktiDto.Prodhuesi;
                produkti.Fotografia = produktiDto.Fotografia;
                produkti.KompaniaId = produktiDto.KompaniaId;
                produkti.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new Response<Produkti>(produkti, true, "Produkti u përditësua me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Produkti>(null).InternalServerError($"Gabim gjatë përditësimit të produktit: {ex.Message}");
            }
        }

        public async Task<Response<string>> DeleteAsync(int id)
        {
            try
            {
                var produkti = await _context.tblProdukti.FindAsync(id);
                if (produkti == null)
                    return new Response<string>(null).NotFound("Produkti nuk u gjet.");

                _context.tblProdukti.Remove(produkti);
                await _context.SaveChangesAsync();

                return new Response<string>("Produkti u fshi me sukses.", true);
            }
            catch (Exception ex)
            {
                return new Response<string>(null).InternalServerError($"Gabim gjatë fshirjes së produktit: {ex.Message}");
            }
        }
    }
}

