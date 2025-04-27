namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class PagesatDto
    {
        public int Id { get; set; }
        public DateTime DataPageses { get; set; }
        public decimal TVSH { get; set; }
        public string NrFletPageses { get; set; }
        public int PorositeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}