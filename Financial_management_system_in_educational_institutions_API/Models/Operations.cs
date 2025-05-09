using Financial_management_system_in_educational_institutions_API.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    public class Operations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Verb { get; set; }
        [Required]
        public string Resource { get; set; }
    }
}
