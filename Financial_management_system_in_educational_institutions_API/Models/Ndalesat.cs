using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Ndalesat")]
    public class Ndalesat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(250)]
        public string Arsyeja { get; set; }

        [Required]
        public decimal ShumaNdaleses { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        public bool Aprovuari { get; set; }

        [Required, ForeignKey("StafiShkolles")]
        public int StafiShkollesId { get; set; }
        public StafiShkolles StafiShkolles { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
