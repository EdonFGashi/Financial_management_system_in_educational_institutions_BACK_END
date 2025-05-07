namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Authorization
{
    public class UserClaimDto
    {
        public int claimId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        //public AppUserClaim AppUserClaim { get; set; }
        public string ClaimType { get; set; }
        //public Operations Operations { get; set; }
        public string ClaimValue { get; set; }
    }
}
