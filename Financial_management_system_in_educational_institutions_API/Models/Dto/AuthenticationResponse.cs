namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
