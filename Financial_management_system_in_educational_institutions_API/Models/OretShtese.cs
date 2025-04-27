using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("OretShtese")]
    public class OretShtese
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, ForeignKey("StafiShkolles")]
        public int StafiShkollesId { get; set; }
        public StafiShkolles StafiShkolles { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DataAngazhimit { get; set; }

        [Required]
        public int NrOreve { get; set; }

        [Required]
        public decimal PagesaPerOre { get; set; }

        [StringLength(250)]
        public string? Shenime { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
