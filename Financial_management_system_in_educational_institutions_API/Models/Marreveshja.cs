using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("Marreveshja")]
    public class Marreveshja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, ForeignKey("Komuna")]
        public int KomunaId { get; set; }
        public Komuna Komuna { get; set; }

        [Required, ForeignKey("Kompania")]
        public int KompaniaId { get; set; }
        public Kompania Kompania { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime NgaData { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeriMeData { get; set; }

        [Required, ForeignKey("Tenderi")]
        public int TenderiId { get; set; }
        public Tenderi Tenderi { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
