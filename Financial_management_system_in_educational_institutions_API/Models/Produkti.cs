using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Produkti")]
    public class Produkti
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        [StringLength(200)]
        public string? Fotografia { get; set; }

        [Required, ForeignKey("Kompania")]
        public int KompaniaId { get; set; }
        public Kompania Kompania { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
