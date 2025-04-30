namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class PorositeDto
    {
        public int Id { get; set; }
        public DateTime DataPorosise { get; set; }
        public int Sasia { get; set; }
        public string Statusi { get; set; } = "Ne Pritje"; // Default
        public string? Shenime { get; set; }
        public int ShkollaId { get; set; }
        public int ProduktiId { get; set; }

        public string ShkollaEmri { get; set; } = string.Empty;
        public string ProduktiEmri { get; set; } = string.Empty;
        public string ProduktiPershkrimi { get; set; } = string.Empty; 
        public string KompaniaEmri { get; set; } = string.Empty; 

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
