using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Route("api/userClaims")]
    [ApiController]
    public class UserClaimsController: ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UserClaimsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("getUserClaims")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< ActionResult<List<UserClaimDto>>> GetUsersClaims() //Me interfacen ActionResult mund te kthejme qfaredo tipi te te dhenave
        {
            return await _db.UserClaims
                 .Select(c => new UserClaimDto
                 {
                     claimId = c.Id,
                     UserId = c.UserId,
                     UserName = _db.Users
                            .Where(u => c.UserId == u.Id)
                            .Select(u => u.UserName)
                            .FirstOrDefault(),
                     ClaimType = c.ClaimType,
                     ClaimValue = c.ClaimValue
                 })
                 .ToListAsync();
        }
    }
}
