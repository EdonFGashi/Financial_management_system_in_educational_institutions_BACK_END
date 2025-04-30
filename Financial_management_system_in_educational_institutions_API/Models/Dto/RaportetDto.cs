namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class RaportetDto
    {
        public int Id { get; set; }
        public string Porosia { get; set; } = string.Empty;
        public int Sasia { get; set; }
        public string Kompania { get; set; } = string.Empty;
        public string Shkolla { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Statusi { get; set; } = string.Empty; // <-- ADD THIS
        public bool Selected { get; set; } = false;
    }
}
