namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Inventari
{
    public class CreateInventariAktualDto
    {
        public string Emri {  get; set; }
        public string? Pershkrimi { get; set; }
        public int Sasia { get; set; }
        public string Shifra { get; set; }
        public int ShkollaId { get; set; }
    }
}
