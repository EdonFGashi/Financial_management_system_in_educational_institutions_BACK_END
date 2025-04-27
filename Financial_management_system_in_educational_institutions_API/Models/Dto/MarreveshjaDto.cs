namespace Financial_management_system_in_educational_institutions_API.Models.Dto;
public class MarreveshjaDto
{
    public int Id { get; set; }
    public int KomunaId { get; set; }
    public int KompaniaId { get; set; }
    public DateTime NgaData { get; set; }
    public DateTime? DeriMeData { get; set; }
    public int TenderiId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}