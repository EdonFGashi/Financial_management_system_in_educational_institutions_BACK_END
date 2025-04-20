using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PersonController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Person
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(_db.tblPersons.ToList());
        }

        // GET: api/Person/123456789
        [HttpGet("{numriPersonal:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Person> Get(int numriPersonal)
        {
            var person = _db.tblPersons.FirstOrDefault(p => p.numriPersonal == numriPersonal);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // POST: api/Person
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person> Create([FromBody] Person person)
        {
            if (_db.tblPersons.Any(p => p.numriPersonal == person.numriPersonal))
            {
                ModelState.AddModelError("numriPersonal", "Person with this numriPersonal already exists.");
                return BadRequest(ModelState);
            }

            _db.tblPersons.Add(person);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { numriPersonal = person.numriPersonal }, person);
        }

        // PUT: api/Person/123456789
        [HttpPut("{numriPersonal:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int numriPersonal, [FromBody] Person person)
        {
            if (numriPersonal != person.numriPersonal)
            {
                return BadRequest();
            }

            _db.tblPersons.Update(person);
            _db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Person/123456789
        [HttpDelete("{numriPersonal:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int numriPersonal)
        {
            var person = _db.tblPersons.FirstOrDefault(p => p.numriPersonal == numriPersonal);
            if (person == null)
            {
                return NotFound();
            }

            _db.tblPersons.Remove(person);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
