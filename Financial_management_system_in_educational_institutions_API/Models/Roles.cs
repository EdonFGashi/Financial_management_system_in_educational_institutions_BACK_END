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
        public int roleId { get; set; }

        [Required, StringLength(50)]
        public string role { get; set; }

        [Required, StringLength(100)]
        public string domain { get; set; }

        [StringLength(250)]
        public string? description { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}
