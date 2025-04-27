namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class ProduktiDto
    {
        public int Id { get; set; }
        public string Emri { get; set; }
        public string? Pershkrimi { get; set; }
        public decimal Cmimi { get; set; }
        public int SasiaNeStok { get; set; }
        public string? Origjina { get; set; }
        public string? Prodhuesi { get; set; }
        public string? Fotografia { get; set; }
        public int KompaniaId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}