namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class PorositeDto
    {
        public int Id { get; set; }

        // Order date
        public DateTime DataPorosise { get; set; }

        public int Sasia { get; set; }
        public bool Paguar { get; set; }
        public string? Shenime { get; set; }

        // Foreign keys (still needed if you want to create/update)
        public int ShkollaId { get; set; }
        public int ProduktiId { get; set; }

        // --- NEW: human-readable names for front-end listing/filtering ---
        public string ShkollaEmri { get; set; } = string.Empty;
        public string ProduktiEmri { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
