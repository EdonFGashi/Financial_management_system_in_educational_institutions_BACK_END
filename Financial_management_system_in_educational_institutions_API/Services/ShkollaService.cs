using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class ShkollaService : IShkollaService
    {
        private readonly ApplicationDbContext _context;

        public ShkollaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Shkolla>>> GetAllAsync()
        {
            try
            {
                var shkollat = await _context.tblShkolla
                    .Include(s => s.Person)
                    .Include(s => s.Account)
                    .ToListAsync();

                return new Response<List<Shkolla>>(shkollat, true, "Shkollat u kthyen me sukses");
            }
            catch (Exception ex)
            {
                return new Response<List<Shkolla>>(null).InternalServerError($"Gabim gjatë marrjes së shkollave: {ex.Message}");
            }
        }

        public async Task<Response<Shkolla>> GetByIdAsync(int id)
        {
            try
            {
                var shkolla = await _context.tblShkolla
                    .Include(s => s.Person)
                    .Include(s => s.Account)
                    .FirstOrDefaultAsync(s => s.shkollaId == id);

                if (shkolla == null)
                    return new Response<Shkolla>(null).NotFound("Shkolla nuk u gjet.");

                return new Response<Shkolla>(shkolla, true, "Shkolla u gjet me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Shkolla>(null).InternalServerError($"Gabim gjatë kërkimit të shkollës: {ex.Message}");
            }
        }

        public async Task<Response<Shkolla>> CreateAsync(ShkollaDto shkollaDto)
        {
            try
            {
                var directorExists = await _context.tblPersons.AnyAsync(p => p.numriPersonal == shkollaDto.drejtori);

                if (!directorExists)
                    return new Response<Shkolla>(null).BadRequest("Drejtori i dhënë nuk ekziston.");

                var shkolla = new Shkolla
                {
                    emriShkolles = shkollaDto.emriShkolles,
                    drejtori = shkollaDto.drejtori,
                    lokacioni = shkollaDto.lokacioni,
                    nrNxenesve = shkollaDto.nrNxenesve,
                    buxhetiAktual = shkollaDto.buxhetiAktual,
                    autoNdarja = shkollaDto.autoNdarja,
                    accId = shkollaDto.accId,
                    createdAt = DateTime.UtcNow
                };

                _context.tblShkolla.Add(shkolla);
                await _context.SaveChangesAsync();

                return new Response<Shkolla>(shkolla, true, "Shkolla u krijua me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Shkolla>(null).InternalServerError($"Gabim gjatë krijimit të shkollës: {ex.Message}");
            }
        }

        public async Task<Response<Shkolla>> UpdateAsync(int id, UpdateShkollaDto updatedShkolla)
        {
            try
            {
                var existing = await _context.tblShkolla.FindAsync(id);
                if (existing == null)
                    return new Response<Shkolla>(null).NotFound("Shkolla nuk u gjet.");

                existing.drejtori = updatedShkolla.drejtori;
                existing.lokacioni = updatedShkolla.lokacioni;
                existing.nrNxenesve = updatedShkolla.nrNxenesve;
                existing.buxhetiAktual = updatedShkolla.buxhetiAktual;
                existing.autoNdarja = updatedShkolla.autoNdarja;
                existing.updatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new Response<Shkolla>(existing, true, "Shkolla u përditësua me sukses.");
            }
            catch (Exception ex)
            {
                return new Response<Shkolla>(null).InternalServerError($"Gabim gjatë përditësimit të shkollës: {ex.Message}");
            }
        }

        public async Task<Response<string>> DeleteAsync(int id)
        {
            try
            {
                var shkolla = await _context.tblShkolla.FindAsync(id);
                if (shkolla == null)
                    return new Response<string>(null).NotFound("Shkolla nuk u gjet.");

                _context.tblShkolla.Remove(shkolla);
                await _context.SaveChangesAsync();

                return new Response<string>("Shkolla u fshi me sukses.", true);
            }
            catch (Exception ex)
            {
                return new Response<string>(null).InternalServerError($"Gabim gjatë fshirjes së shkollës: {ex.Message}");
            }
        }
    }
}

