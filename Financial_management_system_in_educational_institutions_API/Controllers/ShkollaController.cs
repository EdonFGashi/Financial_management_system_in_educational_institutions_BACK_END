using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShkollaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ShkollaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shkolla>> GetAll()
        {
            return Ok(_db.tblShkolla.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Shkolla> Get(int id)
        {
            var shkolla = _db.tblShkolla.FirstOrDefault(s => s.shkollaId == id);
            if (shkolla == null) return NotFound();
            return Ok(shkolla);
        }

        [HttpPost]
        public ActionResult<Shkolla> Create([FromBody] ShkollaDto dto)
        {
            Shkolla model = new()
            {
                emriShkolles = dto.emriShkolles,
                drejtori = dto.drejtori,
                lokacioni = dto.lokacioni,
                nrNxenesve = dto.nrNxenesve,
                buxhetiAktual = dto.buxhetiAktual,
                autoNdarja = dto.autoNdarja,
                accId = dto.accId
            };

            _db.tblShkolla.Add(model);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = model.shkollaId }, model);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] ShkollaDto dto)
        {
            if (id != dto.shkollaId) return BadRequest();

            var model = new Shkolla
            {
                shkollaId = dto.shkollaId,
                emriShkolles = dto.emriShkolles,
                drejtori = dto.drejtori,
                lokacioni = dto.lokacioni,
                nrNxenesve = dto.nrNxenesve,
                buxhetiAktual = dto.buxhetiAktual,
                autoNdarja = dto.autoNdarja,
                accId = dto.accId
            };

            _db.tblShkolla.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var shkolla = _db.tblShkolla.FirstOrDefault(s => s.shkollaId == id);
            if (shkolla == null) return NotFound();

            _db.tblShkolla.Remove(shkolla);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
