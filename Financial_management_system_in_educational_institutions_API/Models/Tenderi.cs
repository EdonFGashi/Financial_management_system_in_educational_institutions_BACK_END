using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Tenderi")]
    public class Tenderi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        public string? Pershkrimi { get; set; }

        [StringLength(100)]
        public string? Sherbimi { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public decimal Shuma { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
