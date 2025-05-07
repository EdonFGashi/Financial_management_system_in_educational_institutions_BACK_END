using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/role-permissions")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public RolePermissionController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<object>> GetAll()
        {
            var result = _db.RolePermissions
                .Include(rp => rp.Operations)
                .Include(rp => rp.AspNetUserClaims)
                .Select(rp => new
                {
                    rp.RolePermissionId,
                    rp.ClaimId,
                    rp.OperationId,
                    Role = rp.AspNetUserClaims.ClaimValue,
                    Name = rp.Operations.Name,
                    Verb = rp.Operations.Verb,
                    Resource = rp.Operations.Resource
                }).ToList();

            return Ok(result);
        }

        //[HttpPost("create")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<RolePermissions> Create([FromBody] RolePermissionsDto rolePermissionsDto)
        //{
        //    if (!_db.UserClaims.Any(c => c.Id == rolePermissionsDto.ClaimId) &&
        //        !_db.Operations.Any(o => o.OperationId == rolePermissionsDto.OperationId))
        //    {
        //        return BadRequest("Invalid ClaimId or OperationId");
        //    }

        //    var newRolePermission = new RolePermissions
        //    {
        //        ClaimId = rolePermissionsDto.ClaimId,
        //        OperationId = rolePermissionsDto.OperationId
        //    };

        //    _db.RolePermissions.Add(newRolePermission);
        //    _db.SaveChanges();

        //    return CreatedAtAction(nameof(GetAll), new { id = newRolePermission.RolePermissionId }, newRolePermission);
        //}

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RolePermissions> Create([FromBody] RolePermissionsDto dto)
        {
            if (!_db.UserClaims.Any(c => c.Id == dto.ClaimId) ||
                !_db.Operations.Any(o => o.OperationId == dto.OperationId))
            {
                return BadRequest("Invalid ClaimId or OperationId");
            }

            var newRolePermission = new RolePermissions
            {
                ClaimId = dto.ClaimId,
                OperationId = dto.OperationId
            };

            _db.RolePermissions.Add(newRolePermission);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = newRolePermission.RolePermissionId }, newRolePermission);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var rp = _db.RolePermissions.FirstOrDefault(x => x.RolePermissionId == id);
            if (rp == null) return NotFound();

            _db.RolePermissions.Remove(rp);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
