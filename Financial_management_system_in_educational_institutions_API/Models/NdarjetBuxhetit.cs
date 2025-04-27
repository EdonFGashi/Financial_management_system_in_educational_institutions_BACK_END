using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("NdarjetBuxhetit")]
    public class NdarjetBuxhetit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, ForeignKey("Shkolla")]
        public int ShkollaId { get; set; }
        public Shkolla Shkolla { get; set; }

        [Required]
        public decimal Shuma { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public bool Auto { get; set; }

        [StringLength(250)]
        public string? Shenime { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
