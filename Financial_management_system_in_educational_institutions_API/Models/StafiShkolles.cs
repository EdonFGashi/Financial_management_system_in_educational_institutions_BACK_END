using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("StafiShkolles")]
    public class StafiShkolles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required, StringLength(100)]
        public string Pozita { get; set; }

        [Required]
        public decimal Paga { get; set; }

        [Required]
        public int NrOreve { get; set; }

        [Required, ForeignKey("Shkolla")]
        public int ShkollaId { get; set; }
        public Shkolla Shkolla { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
