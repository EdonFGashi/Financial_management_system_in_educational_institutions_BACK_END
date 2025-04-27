using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Adresat")]
    public class Adresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Rruga { get; set; }

        [Required, StringLength(100)]
        public string Qyteti { get; set; }

        [StringLength(100)]
        public string? Shteti { get; set; }

        [StringLength(20)]
        public string? KodiPostal { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
