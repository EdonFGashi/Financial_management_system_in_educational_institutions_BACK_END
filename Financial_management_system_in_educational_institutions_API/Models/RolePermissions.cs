using Financial_management_system_in_educational_institutions_API.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("RolePermissions")]
    public class RolePermissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolePermissionId { get; set; }
        [ForeignKey("AspNetUserClaims")]
        public int ClaimId { get; set; } 

        public AppUserClaim AspNetUserClaims { get; set; }
        [Required, ForeignKey("Operations")]
        public int OperationId { get; set; }
        public Operations Operations { get; set; }

    }
}
