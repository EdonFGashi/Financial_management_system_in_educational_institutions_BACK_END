namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class TenderiDto
    {
        public int Id { get; set; }
        public string? Pershkrimi { get; set; }
        public string? Sherbimi { get; set; }
        public DateTime Data { get; set; }
        public decimal Shuma { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}