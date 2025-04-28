namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class PorositeListDto
    {
        public int Id { get; set; }
        public string ProduktiEmri { get; set; }
        public string ShkollaEmri { get; set; }
        public int Sasia { get; set; }
        public DateTime DataPorosise { get; set; }
        public bool Paguar { get; set; }
        public string? Shenime { get; set; }
    }
}
