using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Interfaces;

public class StafiService : IStafiService
{
    private readonly ApplicationDbContext _context;

    public StafiService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Response<List<StafiShkolles>>> GetAllAsync()
    {
        try
        {
            var data = await _context.tblStafiShkolles
                .Include(s => s.Person)
                .Include(s => s.Shkolla)
                .ToListAsync();

            return new Response<List<StafiShkolles>>(data, true, "Lista u kthye me sukses");
        }
        catch (Exception ex)
        {
            return new Response<List<StafiShkolles>>(null).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<StafiShkolles>> GetByIdAsync(int id)
    {
        var stafi = await _context.tblStafiShkolles
            .Include(s => s.Person)
            .Include(s => s.Shkolla)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (stafi == null)
            return new Response<StafiShkolles>(null).NotFound("Stafi nuk u gjet");

        return new Response<StafiShkolles>(stafi, true, "Stafi u gjet me sukses");
    }

    public async Task<Response<StafiShkolles>> CreateAsync(StafiShkollesDto dto)
    {
        try
        {
            var stafi = new StafiShkolles
            {
                numriPersonal = dto.numriPersonal,
                pozita = dto.pozita,
                paga = dto.paga,
                numriOreve = dto.numriOreve,
                shkollaId = dto.shkollaId,
                createdAt = DateTime.UtcNow
            };

            _context.tblStafiShkolles.Add(stafi);
            await _context.SaveChangesAsync();

            return new Response<StafiShkolles>(stafi, true, "Stafi u krijua me sukses");
        }
        catch (Exception ex)
        {
            return new Response<StafiShkolles>(null).InternalServerError(ex.Message);
        }
    }

    public async Task<Response<StafiShkolles>> UpdateAsync(int id, UpdateStafiShkollesDto dto)
    {
        var existing = await _context.tblStafiShkolles.FindAsync(id);
        if (existing == null)
            return new Response<StafiShkolles>(null).NotFound("Stafi nuk u gjet");

        existing.numriPersonal = dto.numriPersonal;
        existing.pozita = dto.pozita;
        existing.paga = dto.paga;
        existing.numriOreve = dto.numriOreve;
        existing.shkollaId = dto.shkollaId;
        existing.updatedAt = dto.updatedAt ?? DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return new Response<StafiShkolles>(existing, true, "Stafi u përditësua me sukses");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var stafi = await _context.tblStafiShkolles.FindAsync(id);
        if (stafi == null)
            return new Response<string>(null).NotFound("Stafi nuk u gjet");

        _context.tblStafiShkolles.Remove(stafi);
        await _context.SaveChangesAsync();

        return new Response<string>("Stafi u fshi me sukses", true);
    }
}
