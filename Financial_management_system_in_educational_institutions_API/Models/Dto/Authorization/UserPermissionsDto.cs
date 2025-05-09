namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Authorization
{
    public class UserPermissionsDto
    {
            public int RolePermissionId { get; set; }
            public int ClaimId { get; set; }
            public string UserID { get; set; }
            public string UserName { get; set; }
            //public AppUserClaim AppUserClaim { get; set; }
            public int OperationId { get; set; }
            //public Operations Operations { get; set; }

 
    }
}
