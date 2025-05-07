using Financial_management_system_in_educational_institutions_API.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Authorization
{
    public class RolePermissionsDto
    {

            public int RolePermissionId { get; set; }
            public int ClaimId { get; set; }
            //public AppUserClaim AppUserClaim { get; set; }
            public int OperationId { get; set; }
            //public Operations Operations { get; set; }

        }
    }


