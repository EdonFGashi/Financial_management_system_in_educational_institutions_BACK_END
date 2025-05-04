using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Financial_management_system_in_educational_institutions_API.Models.Identity;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("tblShkolla")] // Schema is dynamic, handled via OnModelCreating
    public class Shkolla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shkollaId { get; set; }

        [Required, StringLength(150)]
        public string emriShkolles { get; set; }

        [Required]
        public int drejtori { get; set; }
        public Person? Person { get; set; }

        [Required]
        public int nrNxenesve { get; set; }


        [Required, ForeignKey("Adresa")]
        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal buxhetiAktual { get; set; }

        [Required]
        public bool autoNdarja { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}
