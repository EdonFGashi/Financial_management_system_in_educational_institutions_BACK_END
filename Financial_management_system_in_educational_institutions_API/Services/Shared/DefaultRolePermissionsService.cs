using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_management_system_in_educational_institutions_API.Services.Shared
{
    public class DefaultRolePermissionsService
    {
        private readonly ApplicationDbContext context;

        // Static default permissions per role
        private static readonly Dictionary<string, List<(string actionName, string verb, string resource)>> DefaultPermissionsByRole = new()
        {
            ["komune"] = new List<(string, string, string)>
            {
                ("ReloadEndpoints", "POST", "api/Endpoints/reload"),
                ("GetListUsers", "POST", "api/accounts/listUsers"),
                ("UpdateUserRole", "PUT", "api/accounts/updateRole"),
                ("RegisterKomunaWithUser", "POST", "api/accounts/register-komuna"),
                ("RegisterShkolla", "POST", "api/accounts/register-shkolla"),
                ("RegisterKompania", "POST", "api/accounts/register-kompania"),
                ("MakeAdmin", "POST", "api/accounts/makeAdmin"),
                ("Create", "POST", "api/accounts/create"),
                ("Login", "POST", "api/accounts/login"),
                ("GetAll", "GET", "api/Kompania"),
                ("GetById", "GET", "api/Kompania/{id}"),
                ("Create", "POST", "api/Kompania"),
                ("Update", "PUT", "api/Kompania/{id}"),
                ("Delete", "DELETE", "api/Kompania/{id}"),
                ("GetAll", "GET", "api/Komuna"),
                ("Get", "GET", "api/Komuna/{id:int}"),
                ("Create", "POST", "api/Komuna"),
                ("Update", "PUT", "api/Komuna/{id:int}"),
                ("Delete", "DELETE", "api/Komuna/{id:int}"),
                ("GetUsers", "GET", "api/MoneyMonitor"),
                ("GetUser", "GET", "api/MoneyMonitor/{id:int}"),
                ("CreateUser", "POST", "api/MoneyMonitor"),
                ("DeleteUser", "DELETE", "api/MoneyMonitor/{id:int}"),
                ("UpdateUser", "PUT", "api/MoneyMonitor/{id:int}"),
                ("UpdatePartialUser", "PATCH", "api/MoneyMonitor/{id:int}"),
                ("GetOperations", "GET", "api/operations/getOperations"),
                ("CreateOperation", "POST", "api/operations/createOperation"),
                ("DeleteOperation", "DELETE", "api/operations/{id:int}"),
                ("UpdateOperation", "PUT", "api/operations/{id:int}"),
                ("GetAll", "GET", "api/Person"),
                ("Get", "GET", "api/Person/{numriPersonal:int}"),
                ("Create", "POST", "api/Person"),
                ("Update", "PUT", "api/Person/{numriPersonal:int}"),
                ("Delete", "DELETE", "api/Person/{numriPersonal:int}"),
                ("GetPorosite", "GET", "api/Porosite"),
                ("Paguaj", "PATCH", "api/Porosite/paguaj/{id}"),
                ("Fshij", "PATCH", "api/Porosite/fshij/{id}"),
                ("GetAllRaportet", "GET", "api/Raporti"),
                ("GenerateRaport", "POST", "api/Raporti/gjenero"),
                ("GetAll", "GET", "api/role-permissions/getAll"),
                ("Create", "POST", "api/role-permissions/create"),
                ("Delete", "DELETE", "api/role-permissions/{id:int}"),
                ("UpdateRolePermission", "PUT", "api/role-permissions/{id:int}"),
                ("GetAll", "GET", "api/Shkolla"),
                ("GetById", "GET", "api/Shkolla/{id}"),
                ("Create", "POST", "api/Shkolla"),
                ("Update", "PUT", "api/Shkolla/{id}"),
                ("Delete", "DELETE", "api/Shkolla/{id}"),
                ("GetShporta", "GET", "api/Shporta/{shkollaId}"),
                ("AddToShporta", "POST", "api/Shporta"),
                ("UpdateShporta", "PUT", "api/Shporta"),
                ("DeleteFromShporta", "DELETE", "api/Shporta/{id}"),
                ("GetUsersClaims", "GET", "api/userClaims/getUserClaims")
            },
            ["shkolle"] = new List<(string, string, string)>
            {
                ("ReloadEndpoints", "POST", "api/Endpoints/reload"),
                ("GetListUsers", "POST", "api/accounts/listUsers"),
                ("UpdateUserRole", "PUT", "api/accounts/updateRole"),
                ("RegisterKomunaWithUser", "POST", "api/accounts/register-komuna"),
                ("RegisterShkolla", "POST", "api/accounts/register-shkolla"),
                ("RegisterKompania", "POST", "api/accounts/register-kompania"),
                ("MakeAdmin", "POST", "api/accounts/makeAdmin"),
                ("Create", "POST", "api/accounts/create"),
                ("Login", "POST", "api/accounts/login"),
                ("GetAll", "GET", "api/Kompania"),
                ("GetById", "GET", "api/Kompania/{id}"),
                ("Create", "POST", "api/Kompania"),
                ("Update", "PUT", "api/Kompania/{id}"),
                ("Delete", "DELETE", "api/Kompania/{id}"),
                ("GetAll", "GET", "api/Komuna"),
                ("Get", "GET", "api/Komuna/{id:int}"),
                ("Create", "POST", "api/Komuna"),
                ("Update", "PUT", "api/Komuna/{id:int}"),
                ("Delete", "DELETE", "api/Komuna/{id:int}"),
                ("GetUsers", "GET", "api/MoneyMonitor"),
                ("GetUser", "GET", "api/MoneyMonitor/{id:int}"),
                ("CreateUser", "POST", "api/MoneyMonitor"),
                ("DeleteUser", "DELETE", "api/MoneyMonitor/{id:int}"),
                ("UpdateUser", "PUT", "api/MoneyMonitor/{id:int}"),
                ("UpdatePartialUser", "PATCH", "api/MoneyMonitor/{id:int}"),
                ("GetOperations", "GET", "api/operations/getOperations"),
                ("CreateOperation", "POST", "api/operations/createOperation"),
                ("DeleteOperation", "DELETE", "api/operations/{id:int}"),
                ("UpdateOperation", "PUT", "api/operations/{id:int}"),
                ("GetAll", "GET", "api/Person"),
                ("Get", "GET", "api/Person/{numriPersonal:int}"),
                ("Create", "POST", "api/Person"),
                ("Update", "PUT", "api/Person/{numriPersonal:int}"),
                ("Delete", "DELETE", "api/Person/{numriPersonal:int}"),
                ("GetPorosite", "GET", "api/Porosite"),
                ("Paguaj", "PATCH", "api/Porosite/paguaj/{id}"),
                ("Fshij", "PATCH", "api/Porosite/fshij/{id}"),
                ("GetAllRaportet", "GET", "api/Raporti"),
                ("GenerateRaport", "POST", "api/Raporti/gjenero"),
                ("GetAll", "GET", "api/role-permissions/getAll"),
                ("Create", "POST", "api/role-permissions/create"),
                ("Delete", "DELETE", "api/role-permissions/{id:int}"),
                ("UpdateRolePermission", "PUT", "api/role-permissions/{id:int}"),
                ("GetAll", "GET", "api/Shkolla"),
                ("GetById", "GET", "api/Shkolla/{id}"),
                ("Create", "POST", "api/Shkolla"),
                ("Update", "PUT", "api/Shkolla/{id}"),
                ("Delete", "DELETE", "api/Shkolla/{id}"),
                ("GetShporta", "GET", "api/Shporta/{shkollaId}"),
                ("AddToShporta", "POST", "api/Shporta"),
                ("UpdateShporta", "PUT", "api/Shporta"),
                ("DeleteFromShporta", "DELETE", "api/Shporta/{id}"),
                ("GetUsersClaims", "GET", "api/userClaims/getUserClaims")
            },
            ["kompani"] = new List<(string, string, string)>
            {
                ("ReloadEndpoints", "POST", "api/Endpoints/reload"),
                ("GetListUsers", "POST", "api/accounts/listUsers"),
                ("UpdateUserRole", "PUT", "api/accounts/updateRole"),
                ("RegisterKomunaWithUser", "POST", "api/accounts/register-komuna"),
                ("RegisterShkolla", "POST", "api/accounts/register-shkolla"),
                ("RegisterKompania", "POST", "api/accounts/register-kompania"),
                ("MakeAdmin", "POST", "api/accounts/makeAdmin"),
                ("Create", "POST", "api/accounts/create"),
                ("Login", "POST", "api/accounts/login"),
                ("GetAll", "GET", "api/Kompania"),
                ("GetById", "GET", "api/Kompania/{id}"),
                ("Create", "POST", "api/Kompania"),
                ("Update", "PUT", "api/Kompania/{id}"),
                ("Delete", "DELETE", "api/Kompania/{id}"),
                ("GetAll", "GET", "api/Komuna"),
                ("Get", "GET", "api/Komuna/{id:int}"),
                ("Create", "POST", "api/Komuna"),
                ("Update", "PUT", "api/Komuna/{id:int}"),
                ("Delete", "DELETE", "api/Komuna/{id:int}"),
                ("GetUsers", "GET", "api/MoneyMonitor"),
                ("GetUser", "GET", "api/MoneyMonitor/{id:int}"),
                ("CreateUser", "POST", "api/MoneyMonitor"),
                ("DeleteUser", "DELETE", "api/MoneyMonitor/{id:int}"),
                ("UpdateUser", "PUT", "api/MoneyMonitor/{id:int}"),
                ("UpdatePartialUser", "PATCH", "api/MoneyMonitor/{id:int}"),
                ("GetOperations", "GET", "api/operations/getOperations"),
                ("CreateOperation", "POST", "api/operations/createOperation"),
                ("DeleteOperation", "DELETE", "api/operations/{id:int}"),
                ("UpdateOperation", "PUT", "api/operations/{id:int}"),
                ("GetAll", "GET", "api/Person"),
                ("Get", "GET", "api/Person/{numriPersonal:int}"),
                ("Create", "POST", "api/Person"),
                ("Update", "PUT", "api/Person/{numriPersonal:int}"),
                ("Delete", "DELETE", "api/Person/{numriPersonal:int}"),
                ("GetPorosite", "GET", "api/Porosite"),
                ("Paguaj", "PATCH", "api/Porosite/paguaj/{id}"),
                ("Fshij", "PATCH", "api/Porosite/fshij/{id}"),
                ("GetAllRaportet", "GET", "api/Raporti"),
                ("GenerateRaport", "POST", "api/Raporti/gjenero"),
                ("GetAll", "GET", "api/role-permissions/getAll"),
                ("Create", "POST", "api/role-permissions/create"),
                ("Delete", "DELETE", "api/role-permissions/{id:int}"),
                ("UpdateRolePermission", "PUT", "api/role-permissions/{id:int}"),
                ("GetAll", "GET", "api/Shkolla"),
                ("GetById", "GET", "api/Shkolla/{id}"),
                ("Create", "POST", "api/Shkolla"),
                ("Update", "PUT", "api/Shkolla/{id}"),
                ("Delete", "DELETE", "api/Shkolla/{id}"),
                ("GetShporta", "GET", "api/Shporta/{shkollaId}"),
                ("AddToShporta", "POST", "api/Shporta"),
                ("UpdateShporta", "PUT", "api/Shporta"),
                ("DeleteFromShporta", "DELETE", "api/Shporta/{id}"),
                ("GetUsersClaims", "GET", "api/userClaims/getUserClaims")
            }
            ,
            ["admin"] = new List<(string, string, string)>
            {
                ("ReloadEndpoints", "POST", "api/Endpoints/reload"),
                ("GetListUsers", "POST", "api/accounts/listUsers"),
                ("UpdateUserRole", "PUT", "api/accounts/updateRole"),
                ("RegisterKomunaWithUser", "POST", "api/accounts/register-komuna"),
                ("RegisterShkolla", "POST", "api/accounts/register-shkolla"),
                ("RegisterKompania", "POST", "api/accounts/register-kompania"),
                ("MakeAdmin", "POST", "api/accounts/makeAdmin"),
                ("Create", "POST", "api/accounts/create"),
                ("Login", "POST", "api/accounts/login"),
                ("GetAll", "GET", "api/Kompania"),
                ("GetById", "GET", "api/Kompania/{id}"),
                ("Create", "POST", "api/Kompania"),
                ("Update", "PUT", "api/Kompania/{id}"),
                ("Delete", "DELETE", "api/Kompania/{id}"),
                ("GetAll", "GET", "api/Komuna"),
                ("Get", "GET", "api/Komuna/{id:int}"),
                ("Create", "POST", "api/Komuna"),
                ("Update", "PUT", "api/Komuna/{id:int}"),
                ("Delete", "DELETE", "api/Komuna/{id:int}"),
                ("GetUsers", "GET", "api/MoneyMonitor"),
                ("GetUser", "GET", "api/MoneyMonitor/{id:int}"),
                ("CreateUser", "POST", "api/MoneyMonitor"),
                ("DeleteUser", "DELETE", "api/MoneyMonitor/{id:int}"),
                ("UpdateUser", "PUT", "api/MoneyMonitor/{id:int}"),
                ("UpdatePartialUser", "PATCH", "api/MoneyMonitor/{id:int}"),
                ("GetOperations", "GET", "api/operations/getOperations"),
                ("CreateOperation", "POST", "api/operations/createOperation"),
                ("DeleteOperation", "DELETE", "api/operations/{id:int}"),
                ("UpdateOperation", "PUT", "api/operations/{id:int}"),
                ("GetAll", "GET", "api/Person"),
                ("Get", "GET", "api/Person/{numriPersonal:int}"),
                ("Create", "POST", "api/Person"),
                ("Update", "PUT", "api/Person/{numriPersonal:int}"),
                ("Delete", "DELETE", "api/Person/{numriPersonal:int}"),
                ("GetPorosite", "GET", "api/Porosite"),
                ("Paguaj", "PATCH", "api/Porosite/paguaj/{id}"),
                ("Fshij", "PATCH", "api/Porosite/fshij/{id}"),
                ("GetAllRaportet", "GET", "api/Raporti"),
                ("GenerateRaport", "POST", "api/Raporti/gjenero"),
                ("GetAll", "GET", "api/role-permissions/getAll"),
                ("Create", "POST", "api/role-permissions/create"),
                ("Delete", "DELETE", "api/role-permissions/{id:int}"),
                ("UpdateRolePermission", "PUT", "api/role-permissions/{id:int}"),
                ("GetAll", "GET", "api/Shkolla"),
                ("GetById", "GET", "api/Shkolla/{id}"),
                ("Create", "POST", "api/Shkolla"),
                ("Update", "PUT", "api/Shkolla/{id}"),
                ("Delete", "DELETE", "api/Shkolla/{id}"),
                ("GetShporta", "GET", "api/Shporta/{shkollaId}"),
                ("AddToShporta", "POST", "api/Shporta"),
                ("UpdateShporta", "PUT", "api/Shporta"),
                ("DeleteFromShporta", "DELETE", "api/Shporta/{id}"),
                ("GetUsersClaims", "GET", "api/userClaims/getUserClaims")
            }
        };

        public DefaultRolePermissionsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AssignDefaultPermissionsAsync(string role, string userId)
        {
            if (!DefaultPermissionsByRole.TryGetValue(role, out var permissions))
                return;

            var userClaim = await context.UserClaims
                .Where(uc => uc.UserId == userId && uc.ClaimType == "role" && uc.ClaimValue == role)
                .FirstOrDefaultAsync();

            if (userClaim == null)
                return;

            foreach (var (actionName, verb, resource) in permissions)
            {
                var operation = await context.Operations
                    .FirstOrDefaultAsync(op => op.Resource == resource && op.Verb == verb && op.Name == actionName);

                if (operation != null)
                {
                    var exists = await context.RolePermissions.AnyAsync(rp =>
                        rp.ClaimId == userClaim.Id && rp.OperationId == operation.OperationId);

                    if (!exists)
                    {
                        var rolePermission = new RolePermissions
                        {
                            ClaimId = userClaim.Id,
                            OperationId = operation.OperationId
                        };

                        context.RolePermissions.Add(rolePermission);
                    }
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
