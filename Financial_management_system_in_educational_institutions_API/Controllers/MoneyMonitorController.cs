using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/MoneyMonitor")]
    [ApiController]
    public class MoneyMonitorController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<UserDto>> GetUsers() //Me interfacen ActionResult mund te kthejme qfaredo tipi te te dhenave
        {
            return Ok(UsersStorage.usersList); //e kthejme status kodin 200 OK bashk me objektet e kerkuara
        }


        [HttpGet("{id:int}", Name="Getuser")] //per ta dalluar nga metoda tjeter GET specifikojme se kjo metode pret edhe nje id
        //Dokumentimi i status kodeve qe kthen ky endpoint, pergjigjet e mundshme qe ne i kemi trajtuar ne kod se mund ti kthej API
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type=typeof(UserDto))] // mund te caktohet edhe tipi i objektit qe e kthen, morepo kete e kemi caktuar ne metode <UserDto>


        //meqe e kthen vetem nje rekors e largojme IEnumerable
        public ActionResult<UserDto> GetUser(int id)
        {
            //validime
            if(id == 0)
            {
                return BadRequest(); //kjo metode ofrohet nga ControllerBase class (status kodi 400 per bad request)
            }

            //kur kerkojme user me nje id te caktuar ateher para se ta kthejme e ruajme ne nje variabel dhe e kontrollojme nese esht valid
            var user = UsersStorage.usersList.FirstOrDefault(u => u.UserId == id);
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
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)//kete objekt e marrim nga body
        { 
            //kthimi i error-eve te personalizuara, psh nese nuk deshirojme qe useri me emrin e njejte te insertohet 2 here
            if(UsersStorage.usersList.FirstOrDefault(u=>u.FirstName.ToLower() == userDto.FirstName.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "User with this name already exists !");
                return BadRequest(ModelState);
            }
            if (userDto == null)
            {
                return BadRequest(userDto);
            }
            if (userDto.UserId > 0) //kur krijohet nje user i ri ID-ja e tij duhet te jete 0 nga fron end-i sepse ne DB e kemi ID-ne autoincrement 
            {
               return StatusCode(StatusCodes.Status500InternalServerError); //kthimi i nje status code qe nuk e ofron ActionResult
            }
            userDto.UserId = UsersStorage.usersList.OrderByDescending(u => u.UserId).FirstOrDefault().UserId + 1;//(ID llogaritet ketu ne back end)
            UsersStorage.usersList.Add(userDto);

            //ne metodat qe krijojne nje resurs (post) nuk mjafton qe te kthehet vetem 200OK, mirepo mundemi qe ta kthejme edhe url se ku u krijua aj objekt
            return CreatedAtRoute("GetUser", new { id = userDto.UserId }, userDto);
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
            var user = UsersStorage.usersList.FirstOrDefault(u=>u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            UsersStorage.usersList.Remove(user);
            return NoContent();
        }



        
        [HttpPut("{id:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(int id, [FromBody]UserDto userDto)
        {
            if(userDto == null || id != userDto.UserId)
            {
                return BadRequest();
            }
            var user = UsersStorage.usersList.FirstOrDefault(u => u.UserId == id);
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.BrirthDate = userDto.BrirthDate;
            user.Gender = userDto.Gender;
            user.City = userDto.City;
            user.Nationality = userDto.Nationality;
            
            return NoContent();
        }


        [HttpPatch("{id:int}", Name = "UpdatePartialUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialUser(int id, JsonPatchDocument<UserDto> patchDto)
        {
            if(patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var user = UsersStorage.usersList.FirstOrDefault(u=>u.UserId==id);
            if(user == null)
            {
                return NotFound();
            }
            patchDto.ApplyTo(user, ModelState); //apliko ndrshimet ne objektin user, nese ka ndonje error atehere ruaje ne ModelState
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
