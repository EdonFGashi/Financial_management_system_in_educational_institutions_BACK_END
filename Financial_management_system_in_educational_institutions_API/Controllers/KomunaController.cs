using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.AspNetCore.Mvc;


namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KomunaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly TenantSchemaInitializer _initializer;

        public KomunaController(ApplicationDbContext db, TenantSchemaInitializer initializer)
        {
            _db = db;
            _initializer = initializer;
        }

        // GET: api/Komuna
        [HttpGet]
        public ActionResult<IEnumerable<KomunaDto>> GetAll()
        {
            var list = _db.tblKomuna
                .Select(k => new KomunaDto
                {
                    KomunaId = k.KomunaId,
                    Qyteti = k.Qyteti,
                    NrPopullsis = k.NrPopullsis,
                    BuxhetiAktual = k.BuxhetiAktual,
                    DitaNdarjesAuto = k.DitaNdarjesAuto,
                    UserId = k.UserId
                })
                .ToList();
            return Ok(list);
        }

        // GET: api/Komuna/5
        [HttpGet("{id:int}")]
        public ActionResult<KomunaDto> Get(int id)
        {
            var k = _db.tblKomuna.FirstOrDefault(x => x.KomunaId == id);
            if (k == null) return NotFound();

            var dto = new KomunaDto
            {
                KomunaId = k.KomunaId,
                Qyteti = k.Qyteti,
                NrPopullsis = k.NrPopullsis,
                BuxhetiAktual = k.BuxhetiAktual,
                DitaNdarjesAuto = k.DitaNdarjesAuto,
                UserId = k.UserId
            };
            return Ok(dto);
        }

        // POST: api/Komuna
        [HttpPost]
        public async Task<ActionResult<KomunaDto>> Create([FromBody] KomunaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Qyteti))
                return BadRequest("Komuna name (qyteti) is required.");

            // Step 1: Add to shared table
            var model = new Komuna
            {
                Qyteti = dto.Qyteti,
                NrPopullsis = dto.NrPopullsis,
                BuxhetiAktual = dto.BuxhetiAktual,
                DitaNdarjesAuto = dto.DitaNdarjesAuto,
                UserId = dto.UserId
            };

            _db.tblKomuna.Add(model);
            await _db.SaveChangesAsync();

            dto.KomunaId = model.KomunaId;

            // Step 2: Create schema + run migration
            
            var schema = dto.Qyteti.Trim().ToLowerInvariant().Replace(" ", "_");
            Console.WriteLine($"[KomunaController] Creating schema: {schema}");
            await _initializer.CreateSchemaAndMigrateAsync(schema);

            return CreatedAtAction(nameof(Get), new { id = dto.KomunaId }, dto);
        }

        // PUT: api/Komuna/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] KomunaDto dto)
        {
            if (id != dto.KomunaId) return BadRequest();

            var model = new Komuna
            {
                KomunaId = dto.KomunaId,
                Qyteti = dto.Qyteti,
                NrPopullsis = dto.NrPopullsis,
                BuxhetiAktual = dto.BuxhetiAktual,
                DitaNdarjesAuto = dto.DitaNdarjesAuto,
                UserId = dto.UserId
            };

            _db.tblKomuna.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Komuna/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var model = _db.tblKomuna.FirstOrDefault(x => x.KomunaId == id);
            if (model == null) return NotFound();

            _db.tblKomuna.Remove(model);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
