namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class KomunaDto
    {
        public int KomunaId { get; set; }
        public string Qyteti { get; set; }
        public int? NrPopullsis { get; set; }
        public decimal? BuxhetiAktual { get; set; }
        public bool DitaNdarjesAuto { get; set; }
        public string UserId { get; set; }
    }
}
