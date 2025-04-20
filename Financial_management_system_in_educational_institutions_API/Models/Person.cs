using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numriPersonal { get; set; }

        public string emri { get; set; }
        public string mbiemri { get; set; }
        public string nacionaliteti { get; set; }
        public string qyteti { get; set; }
        public string shteti { get; set; }
        public string gjinia { get; set; }
        public DateTime dataLindjes { get; set; }
    }
}
