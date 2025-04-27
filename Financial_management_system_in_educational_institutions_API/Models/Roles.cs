using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Domain { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
