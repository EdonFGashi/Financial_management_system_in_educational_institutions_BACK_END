using System;
using System.ComponentModel.DataAnnotations;
using Financial_management_system_in_educational_institutions_API.Models.Dto;

public class RegisterKompaniaDto
{

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
    // 🔸 School Info
    [Required]
    public string EmriKompanis { get; set; }

    [Required]
    public string Sherbimi { get; set; }

    [Required]
    public int NrXhirologaris { get; set; }

    [Required]
    public string Qyteti { get; set; } // used for schema

    [Required]
    public int PronariNumriPersonal { get; set; }

    [Required]
    public string Emri { get; set; }

    [Required]
    public string Mbiemri { get; set; }

    [Required]
    public string Nacionaliteti { get; set; }

    [Required]
    public string Gjinia { get; set; }

    [Required]
    public DateTime DataLindjes { get; set; }

    // 🔸 Common fields (optional override)
    [Required]
    public string Shteti { get; set; }

    public string? KodiPostal { get; set; }

    // 🔸 Separate address lines
    [Required]
    public string KompaniaRruga { get; set; }

    [Required]
    public string PronariRruga { get; set; }
}
