namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class NdarjetBuxhetitDto
    {
        public int Id { get; set; }
        public int ShkollaId { get; set; }
        public decimal Shuma { get; set; }
        public DateTime Data { get; set; }
        public bool Auto { get; set; }
        public string? Shenime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}