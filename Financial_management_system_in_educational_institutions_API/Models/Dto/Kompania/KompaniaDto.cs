namespace Financial_management_system_in_educational_institutions_API.Models.Dto.Kompania;
public class KompaniaDto
{
    public int Id { get; set; }
    public string Emri { get; set; }
    public int PronariId { get; set; }
    public string Sherbimi { get; set; }
    public int NrXhirologaris { get; set; }
    public int AdresaId { get; set; }
    public int AccountId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}