namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi.Ndalesat
{
    public class CreateNdalesatDto
    {
        public string Arsyeja { get; set; }
        public decimal ShumaNdaleses { get; set; }
        public DateTime Data { get; set; }
        public bool Aprovuari { get; set; }
        public int StafiShkollesId { get; set; }
    }
}
