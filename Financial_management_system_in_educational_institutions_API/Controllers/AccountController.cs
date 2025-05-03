using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// TODO: Delete this 

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Account
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AccountDto>> GetAll()
        {
            var dtos = _db.tblAccounts
                .Select(a => new AccountDto
                {
                    accId = a.accId,
                    organisationName = a.organisationName,
                    role = a.role,
                    username = a.username,
                    passwordHash = a.passwordHash,
                    twoFAcode = a.twoFAcode,
                    twoFAtime = a.twoFAtime
                })
                .ToList();

            return Ok(dtos);
        }

        // GET: api/Account/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AccountDto> Get(int id)
        {
            var a = _db.tblAccounts.FirstOrDefault(x => x.accId == id);
            if (a == null) return NotFound();

            var dto = new AccountDto
            {
                accId = a.accId,
                organisationName = a.organisationName,
                role = a.role,
                username = a.username,
                passwordHash = a.passwordHash,
                twoFAcode = a.twoFAcode,
                twoFAtime = a.twoFAtime
            };
            return Ok(dto);
        }

        // POST: api/Account
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AccountDto> Create([FromBody] AccountDto dto)
        {
            if (_db.tblAccounts.Any(x => x.username.ToLower() == dto.username.ToLower()))
            {
                ModelState.AddModelError("username", "This username already exists.");
                return BadRequest(ModelState);
            }

            var model = new Account
            {
                organisationName = dto.organisationName,
                role = dto.role,
                username = dto.username,
                email = dto.email,
                passwordHash = dto.passwordHash,
                salt = "",               // salti mavon
                twoFAcode = dto.twoFAcode,
                twoFAtime = dto.twoFAtime
            };

            _db.tblAccounts.Add(model);
            _db.SaveChanges();

            var created = new AccountDto
            {
                accId = model.accId,
                organisationName = model.organisationName,
                role = model.role,
                username = model.username,
                email = model.email,
                passwordHash = model.passwordHash,
                twoFAcode = model.twoFAcode,
                twoFAtime = model.twoFAtime
            };

            return CreatedAtAction(nameof(Get), new { id = created.accId }, created);
        }

        // PUT: api/Account/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, [FromBody] AccountDto dto)
        {
            if (id != dto.accId) return BadRequest();

            var model = new Account
            {
                accId = dto.accId,
                organisationName = dto.organisationName,
                role = dto.role,
                username = dto.username,
                passwordHash = dto.passwordHash,
                salt = "",               // salti mavon
                twoFAcode = dto.twoFAcode,
                twoFAtime = dto.twoFAtime
            };

            _db.tblAccounts.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var model = _db.tblAccounts.FirstOrDefault(x => x.accId == id);
            if (model == null) return NotFound();

            _db.tblAccounts.Remove(model);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
