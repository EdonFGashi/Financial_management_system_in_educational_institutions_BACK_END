namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla
{
    public class ShkollaDto
    {
        public string emriShkolles { get; set; }
        public int drejtori { get; set; }
        public string lokacioni { get; set; }
        public int nrNxenesve { get; set; }
        public decimal buxhetiAktual { get; set; }
        public bool autoNdarja { get; set; }
        public int accId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}
