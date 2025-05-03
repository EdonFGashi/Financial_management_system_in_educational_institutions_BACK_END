using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumriPersonal { get; set; }

        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Nacionaliteti { get; set; }
        [Required, ForeignKey("Adresa")]
        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }
        public string Gjinia { get; set; }
        public DateTime DataLindjes { get; set; }
    }
}
