using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KomunaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public KomunaController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Komuna
        [HttpGet]
        public ActionResult<IEnumerable<KomunaDto>> GetAll()
        {
            var list = _db.tblKomuna
                .Select(k => new KomunaDto
                {
                    komunaId = k.komunaId,
                    qyteti = k.qyteti,
                    nrPopullsis = k.nrPopullsis,
                    buxhetiAktual = k.buxhetiAktual,
                    ditaNdarjesAuto = k.ditaNdarjesAuto,
                    accId = k.accId
                })
                .ToList();
            return Ok(list);
        }

        // GET: api/Komuna/5
        [HttpGet("{id:int}")]
        public ActionResult<KomunaDto> Get(int id)
        {
            var k = _db.tblKomuna.FirstOrDefault(x => x.komunaId == id);
            if (k == null) return NotFound();

            var dto = new KomunaDto
            {
                komunaId = k.komunaId,
                qyteti = k.qyteti,
                nrPopullsis = k.nrPopullsis,
                buxhetiAktual = k.buxhetiAktual,
                ditaNdarjesAuto = k.ditaNdarjesAuto,
                accId = k.accId
            };
            return Ok(dto);
        }

        // POST: api/Komuna
        [HttpPost]
        public ActionResult<KomunaDto> Create([FromBody] KomunaDto dto)
        {
            var model = new Komuna
            {
                qyteti = dto.qyteti,
                nrPopullsis = dto.nrPopullsis,
                buxhetiAktual = dto.buxhetiAktual,
                ditaNdarjesAuto = dto.ditaNdarjesAuto,
                accId = dto.accId
            };

            _db.tblKomuna.Add(model);
            _db.SaveChanges();

            dto.komunaId = model.komunaId;
            return CreatedAtAction(nameof(Get),
                                   new { id = dto.komunaId },
                                   dto);
        }

        // PUT: api/Komuna/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] KomunaDto dto)
        {
            if (id != dto.komunaId) return BadRequest();

            var model = new Komuna
            {
                komunaId = dto.komunaId,
                qyteti = dto.qyteti,
                nrPopullsis = dto.nrPopullsis,
                buxhetiAktual = dto.buxhetiAktual,
                ditaNdarjesAuto = dto.ditaNdarjesAuto,
                accId = dto.accId
            };

            _db.tblKomuna.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Komuna/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var model = _db.tblKomuna.FirstOrDefault(x => x.komunaId == id);
            if (model == null) return NotFound();

            _db.tblKomuna.Remove(model);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
