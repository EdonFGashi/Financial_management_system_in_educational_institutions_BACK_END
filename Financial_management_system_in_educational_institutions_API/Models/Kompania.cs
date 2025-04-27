using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Kompania")]
    public class Kompania
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Emri { get; set; }

        [Required, ForeignKey("Person")]
        public int PronariId { get; set; }
        public Person Person { get; set; }

        [Required, StringLength(100)]
        public string Sherbimi { get; set; }

        [StringLength(200)]
        public string? Lokacioni { get; set; }

        public int NrXhirologaris { get; set; }

        [Required, ForeignKey("Adresa")]
        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }

        [Required, ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
