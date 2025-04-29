namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla
{
    public class UpdateShkollaDto
    {
        public int drejtori { get; set; }
        public string lokacioni { get; set; }
        public int nrNxenesve { get; set; }
        public decimal buxhetiAktual { get; set; }
        public bool autoNdarja { get; set; }
    }
}
