using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Porosite")]
    public class Porosite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DataPorosise { get; set; }

        [Required]
        public int Sasia { get; set; }

        [Required]
        public string Statusi { get; set; } = "Ne Pritje"; // Default - to Ne Pritje

        [StringLength(250)]
        public string? Shenime { get; set; }

        [Required, ForeignKey("Shkolla")]
        public int ShkollaId { get; set; }
        public Shkolla Shkolla { get; set; }

        [Required, ForeignKey("Produkti")]
        public int ProduktiId { get; set; }
        public Produkti Produkti { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
