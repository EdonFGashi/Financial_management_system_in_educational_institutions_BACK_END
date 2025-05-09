using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Authorization;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{


    [Route("api/operations")]
    [ApiController]
    public class OperationsController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public OperationsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("getOperations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OperationDto>> GetOperations() //Me interfacen ActionResult mund te kthejme qfaredo tipi te te dhenave
        {
            return Ok(_db.Operations); //e kthejme status kodin 200 OK bashk me objektet e kerkuara
        }


        [HttpPost("createOperation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Operations> CreateOperation([FromBody] OperationDto operationDto)//kete objekt e marrim nga body
        {
            //kthimi i error-eve te personalizuara, psh nese nuk deshirojme qe useri me emrin e njejte te insertohet 2 here
            if (_db.Operations.FirstOrDefault(u => u.Name.ToLower() == operationDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "User with this name already exists !");
                return BadRequest(ModelState);
            }
            if (operationDto == null)
            {
                return BadRequest(operationDto);
            }
            if (operationDto.OperationId > 0) //kur krijohet nje user i ri ID-ja e tij duhet te jete 0 nga fron end-i sepse ne DB e kemi ID-ne autoincrement 
            {
                return StatusCode(StatusCodes.Status500InternalServerError); //kthimi i nje status code qe nuk e ofron ActionResult
            }

            //accountDto.accId = _db.tblAccounts.OrderByDescending(u => u.accId).FirstOrDefault().accId + 1;//(ID llogaritet ketu ne back end)
            Operations model = new()
            {
                OperationId = operationDto.OperationId,
                Name = operationDto.Name,
                Verb = operationDto.Verb,
                Resource = operationDto.Resource,
            };
            _db.Add(model);
            _db.SaveChanges(); //kjo metode e ruan ne DB dhe e dergon ne DB, mund te insertojme disa rekorde me .Add() dhe ne fund ta therrasim SaveChanges()

            //ne metodat qe krijojne nje resurs (post) nuk mjafton qe te kthehet vetem 200OK, mirepo mundemi qe ta kthejme edhe url se ku u krijua aj objekt
            //return CreatedAtRoute("GetOperation", new { id = model.OperationId }, model);
            return Ok(model);
        }


        [HttpDelete("{id:int}", Name = "deleteOperation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteOperation(int id) //kur nuk e specifikojme tipin e kthimit (sikur tek endpointi i mesiperm qe e kthen userDto) atehere e perdorim IActionResult. Kur fshijme, nuk deshirojme qe te kthejme asgje prandaj kthejme diqka te ashtuquajtur "No Content"
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var operation = _db.Operations.FirstOrDefault(u => u.OperationId == id);
            if (operation == null)
            {
                return NotFound();
            }
            _db.Operations.Remove(operation);
            _db.SaveChanges();
            return NoContent();
        }



        [HttpPut("{id:int}", Name = "UpdateOperation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateOperation(int id, [FromBody] OperationDto operationDto)
        {
            if (operationDto == null || id != operationDto.OperationId)
            {
                return BadRequest();
            }

   
            Operations model = new()
            {
                OperationId = operationDto.OperationId,
                Name = operationDto.Name,
                Verb = operationDto.Verb,
                Resource = operationDto.Resource,
            };
            _db.Operations.Update(model); //update e ben EF automatikisht
            _db.SaveChanges();
            return NoContent();
        }
    }
}