using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/MoneyMonitor")]
    [ApiController]
    public class MoneyMonitorController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MoneyMonitorController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<AccountDto>> GetUsers() //Me interfacen ActionResult mund te kthejme qfaredo tipi te te dhenave
        {
            return Ok(_db.tblAccounts); //e kthejme status kodin 200 OK bashk me objektet e kerkuara
        }


        [HttpGet("{id:int}", Name="Getuser")] //per ta dalluar nga metoda tjeter GET specifikojme se kjo metode pret edhe nje id
        //Dokumentimi i status kodeve qe kthen ky endpoint, pergjigjet e mundshme qe ne i kemi trajtuar ne kod se mund ti kthej API
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type=typeof(UserDto))] // mund te caktohet edhe tipi i objektit qe e kthen, morepo kete e kemi caktuar ne metode <UserDto>


        //meqe e kthen vetem nje rekord e largojme IEnumerable
        public ActionResult<AccountDto> GetUser(int id)
        {
            //validime
            if(id == 0)
            {
                return BadRequest(); //kjo metode ofrohet nga ControllerBase class (status kodi 400 per bad request)
            }

            //kur kerkojme user me nje id te caktuar ateher para se ta kthejme e ruajme ne nje variabel dhe e kontrollojme nese esht valid
            var user = _db.tblAccounts.FirstOrDefault(u => u.accId == id);
            if (user == null)
            {
                return NotFound(); //status kodi per 404 not found
            }
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AccountDto> CreateUser([FromBody] AccountDto accountDto)//kete objekt e marrim nga body
        { 
            //kthimi i error-eve te personalizuara, psh nese nuk deshirojme qe useri me emrin e njejte te insertohet 2 here
            if(_db.tblAccounts.FirstOrDefault(u=>u.username.ToLower() == accountDto.username.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "User with this name already exists !");
                return BadRequest(ModelState);
            }
            if (accountDto == null)
            {
                return BadRequest(accountDto);
            }
            if (accountDto.accId > 0) //kur krijohet nje user i ri ID-ja e tij duhet te jete 0 nga fron end-i sepse ne DB e kemi ID-ne autoincrement 
            {
               return StatusCode(StatusCodes.Status500InternalServerError); //kthimi i nje status code qe nuk e ofron ActionResult
            }

            //accountDto.accId = _db.tblAccounts.OrderByDescending(u => u.accId).FirstOrDefault().accId + 1;//(ID llogaritet ketu ne back end)
            Account model = new()
            {
                accId = accountDto.accId,
                organisationName = accountDto.organisationName,
                role = accountDto.role,
                username = accountDto.username,
                passwordHash = accountDto.passwordHash,
                salt = "",
                twoFAcode = accountDto.twoFAcode,
                twoFAtime = DateTime.Now
            };
            _db.tblAccounts.Add(model);
            _db.SaveChanges(); //kjo metode e ruan ne DB dhe e dergon ne DB, mund te insertojme disa rekorde me .Add() dhe ne fund ta therrasim SaveChanges()

            //ne metodat qe krijojne nje resurs (post) nuk mjafton qe te kthehet vetem 200OK, mirepo mundemi qe ta kthejme edhe url se ku u krijua aj objekt
            return CreatedAtRoute("GetUser", new { id = accountDto.accId }, accountDto);
        }


        [HttpDelete("{id:int}", Name ="DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUser(int id) //kur nuk e specifikojme tipin e kthimit (sikur tek endpointi i mesiperm qe e kthen userDto) atehere e perdorim IActionResult. Kur fshijme, nuk deshirojme qe te kthejme asgje prandaj kthejme diqka te ashtuquajtur "No Content"
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var user = _db.tblAccounts.FirstOrDefault(u=>u.accId == id);
            if (user == null)
            {
                return NotFound();
            }
            _db.tblAccounts.Remove(user);
            _db.SaveChanges();
            return NoContent();
        }



        
        [HttpPut("{id:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(int id, [FromBody]AccountDto accountDto)
        {
            if(accountDto == null || id != accountDto.accId)
            {
                return BadRequest();
            }
            //var user = UsersStorage.usersList.FirstOrDefault(u => u.UserId == id);
            //user.FirstName = userDto.FirstName;
            //user.LastName = userDto.LastName;
            //user.BrirthDate = userDto.BrirthDate;
            //user.Gender = userDto.Gender;
            //user.City = userDto.City;
            //user.Nationality = userDto.Nationality;

            //Pa EF eshte dashur qe te nxjerrim nga DB dhe ti bejme update nje nga nje

            //Me EF nuk kemi nevoje, thjesht e konvertojme AccountDto ne Account dhe e ruajme ne DB
            Account model = new()
            {
                accId = accountDto.accId,
                organisationName = accountDto.organisationName,
                role = accountDto.role,
                username = accountDto.username,
                passwordHash = accountDto.passwordHash,
                salt = "",
                twoFAcode = accountDto.twoFAcode,
                twoFAtime = DateTime.Now
            };
            _db.tblAccounts.Update(model); //update e ben EF automatikisht
            _db.SaveChanges();
            return NoContent();
        }


        [HttpPatch("{id:int}", Name = "UpdatePartialUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialUser(int id, JsonPatchDocument<AccountDto> patchDto)
        {
            if(patchDto == null || id == 0)
            {
                return BadRequest();
            }
            //e marrim userin nga DB dhe e ruajme ne nje variabel dhe e konvertojme ne AccountDto
            //ne patch nuk ndryshohet i tere objekti por vetem ndonje vlere e tij.
            var user = _db.tblAccounts.AsNoTracking().FirstOrDefault(u=>u.accId==id);
            AccountDto userDto = new()
            {
                accId = user.accId,
                organisationName = user.organisationName,
                role = user.role,
                username = user.username,   
                passwordHash = user.passwordHash,
                //salt
                twoFAcode = user.twoFAcode,
                twoFAtime = DateTime.Now
            };
            if (user == null)
            {
                return NotFound();
            }
            //qdo ndryshim qe ka ardhur nga front ne pachDto, eshte i tipit AccountDto do ti aplikojme ne kete variablen lokale userDto

            //patchDto.ApplyTo(userDto, ModelState); //apliko ndrshimet ne objektin user, nese ka ndonje error atehere ruaje ne ModelState
            patchDto.ApplyTo(userDto, ModelState);

            //mirepo kur ta bejme udate ne DB, duhet te jete i tipit tblAccounts prandaj e konvertojme prap ne tblAccounts
            Account model = new()
            {
                accId = userDto.accId,
                organisationName = userDto.organisationName,
                role = userDto.role,
                username = userDto.username,
                passwordHash = userDto.passwordHash,
                salt = "",
                twoFAcode = userDto.twoFAcode,
                twoFAtime = DateTime.Now
            };

            _db.tblAccounts.Update(model); //update e ben EF automatikisht
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
