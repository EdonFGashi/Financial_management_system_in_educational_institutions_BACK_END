using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("tblShkolla")]
    public class Shkolla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shkollaId { get; set; }

        [Required, StringLength(150)]
        public string emriShkolles { get; set; }

        [Required]
        public int drejtori { get; set; }           
        public Person? Person { get; set; }

        [Required, StringLength(200)]
        public string lokacioni { get; set; }

        [Required]
        public int nrNxenesve { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal buxhetiAktual { get; set; }

        [Required]
        public bool autoNdarja { get; set; }

        [Required]
        public int accId { get; set; }              
        public Account? Account { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}
