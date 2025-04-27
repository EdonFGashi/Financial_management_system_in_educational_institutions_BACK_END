using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("InventariAktual")]
    public class InventariAktual
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Emri { get; set; }

        [StringLength(250)]
        public string? Pershkrimi { get; set; }

        [Required]
        public int Sasia { get; set; }

        [Required, StringLength(50)]
        public string Shifra { get; set; }

        [Required, ForeignKey("Shkolla")]
        public int ShkollaId { get; set; }
        public Shkolla Shkolla { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
