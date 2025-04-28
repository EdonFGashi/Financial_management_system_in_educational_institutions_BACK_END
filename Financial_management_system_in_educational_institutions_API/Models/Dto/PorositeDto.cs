public class PorositeDto
{
    public int Id { get; set; }
    public DateTime DataPorosise { get; set; }
    public int Sasia { get; set; }
    public string Statusi { get; set; } = "Ne pritje"; // Default - Ne Pritje
    public string? Shenime { get; set; }
    public int ShkollaId { get; set; }
    public int ProduktiId { get; set; }
    public string ShkollaEmri { get; set; } = string.Empty;
    public string ProduktiEmri { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
