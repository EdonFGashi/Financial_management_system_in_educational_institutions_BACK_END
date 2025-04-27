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

        [Required]
        public int numriPersonal { get; set; }       
        public Person Person { get; set; }

        [Required, StringLength(100)]
        public string pozita { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal paga { get; set; }

        [Required]
        public int numriOreve { get; set; }

        [Required]
        public int shkollaId { get; set; }           
        public Shkolla Shkolla { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}
