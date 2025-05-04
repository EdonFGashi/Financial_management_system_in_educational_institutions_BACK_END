namespace Financial_management_system_in_educational_institutions_API.Models
{
    public class Shporta
    {
        public int Id { get; set; }

        public int ProduktiId { get; set; }
        public Produkti Produkti { get; set; }

        public int ShkollaId { get; set; }
        public Shkolla Shkolla { get; set; }

        public int Sasia { get; set; }

        public String foto;

        public string Statusi { get; set; } // "Aprovuar", "Jo Aprovuar"

        public DateTime DataShtimit { get; set; } = DateTime.UtcNow;
    }
}
