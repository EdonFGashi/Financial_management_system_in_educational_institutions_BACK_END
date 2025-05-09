namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi.OretShtese
{
    public class CreateOretShteseDto
    {
        public int StafiShkollesId { get; set; }
        public DateTime DataAngazhimit { get; set; }
        public int NrOreve { get; set; }
        public decimal PagesaPerOre { get; set; }
        public string? Shenime { get; set; }
    }
}
