using System.ComponentModel.DataAnnotations;

namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Produkti
{
    public class CreateProduktiDto
    {
        [Required, StringLength(100)]
        public string Emri { get; set; }

        [StringLength(250)]
        public string? Pershkrimi { get; set; }

        [Required]
        public decimal Cmimi { get; set; }

        [Required]
        public int SasiaNeStok { get; set; }

        [StringLength(100)]
        public string? Origjina { get; set; }

        [StringLength(100)]
        public string? Prodhuesi { get; set; }

        public string? Fotografia { get; set; }  

        [Required]
        public int KompaniaId { get; set; }  // Should usually come from auth, not frontend
    }
}
