namespace Financial_management_system_in_educational_institutions_API.Models;
public class AdresaDto
{
    public int Id { get; set; }
    public string Rruga { get; set; }
    public string Qyteti { get; set; }
    public string? Shteti { get; set; }
    public string? KodiPostal { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}