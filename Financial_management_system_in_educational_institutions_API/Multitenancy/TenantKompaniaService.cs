using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Identity;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

public class TenantKompaniaService  
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TenantKompaniaService> _logger;
    private readonly UserManager<AppUser> _userManager;

    public TenantKompaniaService(IConfiguration configuration, ILogger<TenantKompaniaService> logger, UserManager<AppUser> userManager)
    {
        _configuration = configuration;
        _logger = logger;
        _userManager = userManager;
    }

    public async Task AddKompaniaWithDetailsAsync(string schemaName, RegisterKompaniaDto dto)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));

        var tenantProvider = new StaticTenantProvider(schemaName);
        await using var context = new ApplicationDbContext(optionsBuilder.Options, tenantProvider);

    
        var kompaniaAdresa = new Adresa
        {
            Rruga = dto.KompaniaRruga,
            Qyteti = dto.Qyteti,
            Shteti = dto.Shteti,
            KodiPostal = dto.KodiPostal,
            CreatedAt = DateTime.UtcNow
        };
        context.tblAdresat.Add(kompaniaAdresa);
        await context.SaveChangesAsync();

      
        var pronariAdresa = new Adresa
        {
            Rruga = dto.PronariRruga,
            Qyteti = dto.Qyteti,
            Shteti = dto.Shteti,
            KodiPostal = dto.KodiPostal,
            CreatedAt = DateTime.UtcNow
        };
        context.tblAdresat.Add(pronariAdresa);
        await context.SaveChangesAsync();

    
        if (!await context.tblPersons.AnyAsync(p => p.NumriPersonal == dto.PronariNumriPersonal))
        {
            var pronari = new Person
            {
                NumriPersonal = dto.PronariNumriPersonal,
                Emri = dto.Emri,
                Mbiemri = dto.Mbiemri,
                Nacionaliteti = dto.Nacionaliteti,
                AdresaId = pronariAdresa.Id,
                Gjinia = dto.Gjinia,
                DataLindjes = dto.DataLindjes
            };
            context.tblPersons.Add(pronari);
            await context.SaveChangesAsync();
        }

        // Create Identity user for shkolla
        var kompaniaUser = new AppUser { UserName = dto.Email, Email = dto.Email };
        var createResult = await _userManager.CreateAsync(kompaniaUser, dto.Password);

        if (!createResult.Succeeded)
        {
            throw new ApplicationException("Failed to create user: " +
                string.Join(", ", createResult.Errors.Select(e => e.Description)));
        }

        await _userManager.AddClaimAsync(kompaniaUser, new Claim("role", "Kompania"));

        // Now create the Shkolla and assign the created user
        var kompania = new Kompania
        {
            EmriKompanis = dto.EmriKompanis,
            PronariId = dto.PronariNumriPersonal,
            Sherbimi = dto.Sherbimi,
            NrXhirologaris = dto.NrXhirologaris,
            AdresaId = kompaniaAdresa.Id,
            UserId = kompaniaUser.Id,
            CreatedAt = DateTime.UtcNow
        };

        context.tblKompania.Add(kompania);
        await context.SaveChangesAsync();

        _logger.LogInformation("Shkolla '{Shkolla}' added to schema '{Schema}'", kompania.EmriKompanis, schemaName);
    }
}
