using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Pagesat")]
    public class Pagesat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DataPageses { get; set; }

        [Required]
        public decimal TVSH { get; set; }

        [Required, StringLength(50)]
        public string NrFletPageses { get; set; }

        [Required, ForeignKey("Porosite")]
        public int PorositeId { get; set; }
        public Porosite Porosite { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
