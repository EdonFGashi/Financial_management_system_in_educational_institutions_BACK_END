namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class OretShteseDto
    {
        public int Id { get; set; }
        public int StafiShkollesId { get; set; }
        public DateTime DataAngazhimit { get; set; }
        public int NrOreve { get; set; }
        public decimal PagesaPerOre { get; set; }
        public string? Shenime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}