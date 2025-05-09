using AutoMapper;
using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;
using Financial_management_system_in_educational_institutions_API.Models.Identity;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Financial_management_system_in_educational_institutions_API.DTOs;
//using MovieAPI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Financial_management_system_in_educational_institutions_API.Services;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly TenantSchemaInitializer tenantSchemaInitializer;
        private readonly ShkollaService shkollaService;
        private readonly TenantKompaniaService tenantKompaniaService;

        private readonly DefaultRolePermissionsService defaultRolePermissionService;

        public AccountsController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            IMapper mapper,
            TenantSchemaInitializer tenantSchemaInitializer,
            TenantShkollaService tenantShkollaService,
            TenantKompaniaService tenantKompaniaService,
            DefaultRolePermissionsService defaultRolePermissionsService
            ShkollaService shkollaService)
            
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.context = context;
            this.mapper = mapper;
            this.tenantSchemaInitializer = tenantSchemaInitializer;
            this.shkollaService = shkollaService;
            this.tenantKompaniaService = tenantKompaniaService;
            this.defaultRolePermissionService = defaultRolePermissionsService;
        }


        //[HttpPost("listUsers")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        //public async Task<ActionResult<List<UsersDTO>>> GetListUsers([FromQuery] PaginationDTO paginationDTO)
        //{
        //    var queryable = context.Users.AsQueryable();
        //    await HttpContext.InsertParameterPaginationHeader(queryable);
        //    var users = await queryable.OrderBy(x => x.Email).Paginate(paginationDTO).ToListAsync();
        //    return mapper.Map<List<UsersDTO>>(users);
        //}

        [HttpPost("listUsers")]
        public async Task<ActionResult<List<UsersDTO>>> GetListUsers([FromBody] PaginationDTO paginationDTO)
        {
            if (paginationDTO.RecordsPerPage == -1)
            {
                return await context.Users
                    .Select(u => new UsersDTO
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Role = context.UserClaims
                            .Where(c => c.UserId == u.Id && c.ClaimType == "role")
                            .Select(c => c.ClaimValue)
                            .FirstOrDefault()
                    })
                    .ToListAsync();
            }
            else
            {
                var queryable = context.Users.AsQueryable();

                // Apply pagination manually
                var totalRecords = await queryable.CountAsync();
                var users = await queryable
                    .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage) // Skip the records based on page number
                    .Take(paginationDTO.RecordsPerPage) // Take only the records per page
                    .ToListAsync();

                // Prepare the usersDTO list
                var usersDTO = new List<UsersDTO>();

                foreach (var user in users)
                {
                    var roleClaim = await context.UserClaims
                        .Where(c => c.UserId == user.Id && c.ClaimType == "role")
                        .Select(c => c.ClaimValue)
                        .FirstOrDefaultAsync();

                    usersDTO.Add(new UsersDTO
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Role = roleClaim
                    });
                }

                // Add pagination metadata to response headers (optional)
                Response.Headers.Add("X-Total-Count", totalRecords.ToString());

                return usersDTO;
            }
        }





        [HttpPut("updateRole")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateRoleDTO dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);

            var existingClaims = await userManager.GetClaimsAsync(user);
            var oldRoleClaim = existingClaims.FirstOrDefault(c => c.Type == "role");
            if (oldRoleClaim != null)
            {
                await userManager.RemoveClaimAsync(user, oldRoleClaim);
            }
            await userManager.AddClaimAsync(user, new Claim("role", dto.Role));


            return NoContent();
        }


        [HttpPost("register-komuna")]
        public async Task<IActionResult> RegisterKomunaWithUser([FromBody] RegisterKomunaWithUserDto dto)
        {
            var user = new AppUser { UserName = dto.Email, Email = dto.Email };
            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await userManager.AddClaimAsync(user, new Claim("role", dto.Role));

            var komuna = new Komuna
            {
                Qyteti = dto.Qyteti,
                NrPopullsis = dto.NrPopullsis,
                BuxhetiAktual = dto.BuxhetiAktual,
                DitaNdarjesAuto = dto.DitaNdarjesAuto,
                UserId = user.Id
            };
            context.tblKomuna.Add(komuna);
            await context.SaveChangesAsync();

            var schemaName = GenerateSafeSchemaName(dto.Qyteti);
            await tenantSchemaInitializer.CreateSchemaAndMigrateAsync(schemaName);

            return Ok(new { message = "Komuna and user created successfully", userId = user.Id });
        }

        [HttpPost("register-shkolla")]
        public async Task<IActionResult> RegisterShkolla([FromRoute] string schemaName, [FromBody] ShkollaDto dto)
        { 

            // Call the service
            await shkollaService.CreateAsync(schemaName, dto);

            return Ok(new { message = "Shkolla created successfully" });
        }

        [HttpPost("register-kompania")]
        public async Task<IActionResult> RegisterKompania([FromBody] RegisterKompaniaDto dto)
        {
            var schemaName = GenerateSafeSchemaName(dto.Qyteti);

            // Call the service
            await tenantKompaniaService.AddKompaniaWithDetailsAsync(schemaName, dto);

            return Ok(new { message = "Kompania created successfully" });
        }




        [HttpPost("makeAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult> MakeAdmin([FromBody] string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            await userManager.AddClaimAsync(user, new Claim("role", "admin"));
            return NoContent();
        }

        //[HttpPost("removeAdmin")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        //public async Task<ActionResult> RemoveAdmin([FromBody] string userId)
        //{
        //    var user = await userManager.FindByIdAsync(userId);
        //    await userManager.RemoveClaimAsync(user, new Claim("role", "admin"));
        //    return NoContent();
        //}

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponse>> Create([FromBody] RegisterUserCredentials userCredentials)
        {
            var user = new AppUser { UserName = userCredentials.Email, Email = userCredentials.Email };//e krijojme nje instance te IdentityUser dhe i japim emrin dhe emailin e perdoruesit
            var result = await userManager.CreateAsync(user, userCredentials.Password);//krijojme perdoruesin dhe i japim passwordin e tij

            if (result.Succeeded)//nese perdoruesi eshte krijuar me sukses atehere e kthejme tokenin
            {
                // Add the role to Identity claims
                await userManager.AddClaimAsync(user, new Claim("role", userCredentials.Role));

                await defaultRolePermissionService.AssignDefaultPermissionsAsync(userCredentials.Role, user.Id);

                return await BuildToken(user);
            }
            else //nese nuk eshte krijuar me sukses, atehere e kthejme nje mesazh gabimi
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponse>> Login(
            [FromBody] LoginUserCredentials userCredentials)
        {
            var result = await signInManager.PasswordSignInAsync(userCredentials.Email,
                userCredentials.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Retrieve the user by email
                var user = await userManager.FindByEmailAsync(userCredentials.Email);

                // Pass the user to BuildToken
                return await BuildToken(user);
            }
            else
            {
                return BadRequest("Incorrect Login");
            }


            //var user = await userManager.FindByEmailAsync("user@example.com");
            //var claims = await userManager.GetClaimsAsync(user);
            //var role = claims.FirstOrDefault(c => c.Type == "role")?.Value;

        }

        //metoda private e cila do ta ndertoje tokenin
        private async Task<AuthenticationResponse> BuildToken(AppUser userCredentials)
        {
            //var claims = new List<Claim>()
            //{
            //    new Claim("email", userCredentials.Email),
            //    new Claim("role", userCredentials.Role)
            //};

            var claims = await userManager.GetClaimsAsync(userCredentials);

            var listClaims = new List<Claim>(claims)
            {
               new Claim("email", userCredentials.Email),
               new Claim(ClaimTypes.NameIdentifier, userCredentials.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: listClaims,
                expires: expiration, signingCredentials: creds);

            return new AuthenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                //Role = claims.FirstOrDefault(c => c.Type == "role")?.Value
            };
        }

        // AccountsController.cs (at the bottom of the class)

        private string GenerateSafeSchemaName(string name)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var cleaned = new string(name
                .ToLowerInvariant()
                .Replace(" ", "_")
                .Where(c => !invalidChars.Contains(c))
                .ToArray());

            return cleaned;
        }

    }
}
