using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Kompania;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class KompaniaService : IKompaniaService
    {
        private readonly ApplicationDbContext _context;

        public KompaniaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Kompania>>> GetAllAsync()
        {
            try
            {
                var kompania = await _context.tblKompania
                    .Include(s => s.Person)
                    .Include(s => s.User)
                    .ToListAsync();

                return new Response<List<Kompania>>(kompania, true, "Kompanit u kthyen me sukses");
            }
            catch (Exception ex)
            {
                return new Response<List<Kompania>>(null).InternalServerError($"Gabim gjatë marrjes së Kompanive: {ex.Message}");
            }
        }

        public async Task<Response<Kompania>> GetByIdAsync(int id)
        {
            try
            {
                var kompania = await _context.tblKompania
                    .Include(s => s.Person)
                    .Include(s => s.User)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (kompania == null)
                    return new Response<Kompania>(null).NotFound("Kompania nuk u gjet.");

                return new Response<Kompania>(kompania, true, "Kompania u gjet me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Kompania>(null).InternalServerError($"Gabim gjatë kërkimit të kompanis: {ex.Message}");
            }
        }

        public async Task<Response<Kompania>> CreateAsync(KompaniaDto kompaniaDto)
        {
            try
            {
                var directorExists = await _context.tblPersons.AnyAsync(p => p.NumriPersonal == kompaniaDto.PronariId);

                if (!directorExists)
                    return new Response<Kompania>(null).BadRequest("Pronari i dhënë nuk ekziston.");

                var kompania = new Kompania
                {
                    EmriKompanis = kompaniaDto.Emri,
                    PronariId = kompaniaDto.PronariId,
                    Sherbimi = kompaniaDto.Sherbimi,
                    NrXhirologaris = kompaniaDto.NrXhirologaris,
                    AdresaId = kompaniaDto.AdresaId,
                    UserId = kompaniaDto.UserId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.tblKompania.Add(kompania);
                await _context.SaveChangesAsync();

                return new Response<Kompania>(kompania, true, "Kompania u krijua me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Kompania>(null).InternalServerError($"Gabim gjatë krijimit të shkollës: {ex.Message}");
            }
        }

        public async Task<Response<Kompania>> UpdateAsync(int id, UpdateKompaniaDto updatedtKompania)
        {
            try
            {
                var existing = await _context.tblKompania.FindAsync(id);
                if (existing == null)
                    return new Response<Kompania>(null).NotFound("Kompania nuk u gjet.");

                existing.PronariId = updatedtKompania.PronariId;
                existing.EmriKompanis = updatedtKompania.Emri;
                existing.AdresaId = updatedtKompania.AdresaId;
                existing.Sherbimi = updatedtKompania.Sherbimi;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new Response<Kompania>(existing, true, "Kompania u përditësua me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Kompania>(null).InternalServerError($"Gabim gjatë përditësimit të kompanis: {ex.Message}");
            }
        }

        public async Task<Response<string>> DeleteAsync(int id)
        {
            try
            {
                var kompania = await _context.tblKompania.FindAsync(id);
                if (kompania == null)
                    return new Response<string>(null).NotFound("Kompania nuk u gjet.");

                _context.tblKompania.Remove(kompania);
                await _context.SaveChangesAsync();

                return new Response<string>("kompania u fshi me sukses.", true);
            }
            catch (Exception ex)
            {
                return new Response<string>(null).InternalServerError($"Gabim gjatë fshirjes së kompanis: {ex.Message}");
            }
        }
    }
}

