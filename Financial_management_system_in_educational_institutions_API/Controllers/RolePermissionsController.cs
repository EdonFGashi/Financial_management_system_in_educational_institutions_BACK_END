//using Financial_management_system_in_educational_institutions_API.Data;
//using Financial_management_system_in_educational_institutions_API.Models;
//using Financial_management_system_in_educational_institutions_API.Models.Dto.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace Financial_management_system_in_educational_institutions_API.Controllers
//{
//    [Route("api/operations")]
//    [ApiController]
//    public class RolePermissionsController
//    {

//        private readonly ApplicationDbContext _db;
//        public RolePermissionsController(ApplicationDbContext db)
//        {
//            _db = db;
//        }


//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public ActionResult<RolePermissions> CreateUser([FromBody] RolePermissionsDto rolePermissionsDto)//kete objekt e marrim nga body
//        {
//            //kthimi i error-eve te personalizuara, psh nese nuk deshirojme qe useri me emrin e njejte te insertohet 2 here
//            if (_db.RolePermissions.FirstOrDefault(u => u.ToLower() == rolePermissionsDto..ToLower()) != null)
//            {
//                ModelState.AddModelError("CustomError", "User with this name already exists !");
//                return BadRequest(ModelState);
//            }
//            if (accountDto == null)
//            {
//                return BadRequest(accountDto);
//            }
//            if (accountDto.accId > 0) //kur krijohet nje user i ri ID-ja e tij duhet te jete 0 nga fron end-i sepse ne DB e kemi ID-ne autoincrement 
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError); //kthimi i nje status code qe nuk e ofron ActionResult
//            }

//            //accountDto.accId = _db.tblAccounts.OrderByDescending(u => u.accId).FirstOrDefault().accId + 1;//(ID llogaritet ketu ne back end)
//            Account model = new()
//            {
//                accId = accountDto.accId,
//                organisationName = accountDto.organisationName,
//                role = accountDto.role,
//                username = accountDto.username,
//                passwordHash = accountDto.passwordHash,
//                salt = "",
//                twoFAcode = accountDto.twoFAcode,
//                twoFAtime = DateTime.Now
//            };
//            _db.tblAccounts.Add(model);
//            _db.SaveChanges(); //kjo metode e ruan ne DB dhe e dergon ne DB, mund te insertojme disa rekorde me .Add() dhe ne fund ta therrasim SaveChanges()

//            //ne metodat qe krijojne nje resurs (post) nuk mjafton qe te kthehet vetem 200OK, mirepo mundemi qe ta kthejme edhe url se ku u krijua aj objekt
//            return CreatedAtRoute("GetUser", new { id = accountDto.accId }, accountDto);
//        }
//    }
//}
