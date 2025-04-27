namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class PorositeDto
    {
        public int Id { get; set; }
        public DateTime DataPorosise { get; set; }
        public int Sasia { get; set; }
        public bool Paguar { get; set; }
        public string? Shenime { get; set; }
        public int ShkollaId { get; set; }
        public int ProduktiId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}