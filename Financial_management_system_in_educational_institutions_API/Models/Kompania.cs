using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Financial_management_system_in_educational_institutions_API.Models.Identity;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("tblKompania")] // Schema will be set dynamically
    public class Kompania
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string EmriKompanis { get; set; }

        [Required, ForeignKey("Person")]
        public int PronariId { get; set; }
        public Person Person { get; set; }

        [Required, StringLength(100)]
        public string Sherbimi { get; set; }

        public int NrXhirologaris { get; set; }

        [Required, ForeignKey("Adresa")]
        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
