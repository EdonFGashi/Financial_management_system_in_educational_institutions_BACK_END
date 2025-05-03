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

public class TenantShkollaService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TenantShkollaService> _logger;
    private readonly UserManager<AppUser> _userManager;

    public TenantShkollaService(IConfiguration configuration, ILogger<TenantShkollaService> logger, UserManager<AppUser> userManager)
    {
        _configuration = configuration;
        _logger = logger;
        _userManager = userManager;
    }

    public async Task AddSchoolWithDetailsAsync(string schemaName, RegisterShkollaDto dto)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));

        var tenantProvider = new StaticTenantProvider(schemaName);
        await using var context = new ApplicationDbContext(optionsBuilder.Options, tenantProvider);

        // School Address
        var shkollaAdresa = new Adresa
        {
            Rruga = dto.ShkollaRruga,
            Qyteti = dto.Qyteti,
            Shteti = dto.Shteti,
            KodiPostal = dto.KodiPostal,
            CreatedAt = DateTime.UtcNow
        };
        context.tblAdresat.Add(shkollaAdresa);
        await context.SaveChangesAsync();

        // Drejtori Address
        var drejtoriAdresa = new Adresa
        {
            Rruga = dto.DrejtoriRruga,
            Qyteti = dto.Qyteti,
            Shteti = dto.Shteti,
            KodiPostal = dto.KodiPostal,
            CreatedAt = DateTime.UtcNow
        };
        context.tblAdresat.Add(drejtoriAdresa);
        await context.SaveChangesAsync();

        // Drejtori (Person)
        if (!await context.tblPersons.AnyAsync(p => p.NumriPersonal == dto.DrejtoriNumriPersonal))
        {
            var drejtori = new Person
            {
                NumriPersonal = dto.DrejtoriNumriPersonal,
                Emri = dto.Emri,
                Mbiemri = dto.Mbiemri,
                Nacionaliteti = dto.Nacionaliteti,
                AdresaId = drejtoriAdresa.Id,
                Gjinia = dto.Gjinia,
                DataLindjes = dto.DataLindjes
            };
            context.tblPersons.Add(drejtori);
            await context.SaveChangesAsync();
        }

        // Create Identity user for shkolla
        var shkollaUser = new AppUser { UserName = dto.Email, Email = dto.Email };
        var createResult = await _userManager.CreateAsync(shkollaUser, dto.Password);

        if (!createResult.Succeeded)
        {
            throw new ApplicationException("Failed to create user: " +
                string.Join(", ", createResult.Errors.Select(e => e.Description)));
        }

        await _userManager.AddClaimAsync(shkollaUser, new Claim("role", "Shkolla"));

        // Now create the Shkolla and assign the created user
        var shkolla = new Shkolla
        {
            emriShkolles = dto.EmriShkolles,
            drejtori = dto.DrejtoriNumriPersonal,
            nrNxenesve = dto.NrNxenesve,
            AdresaId = shkollaAdresa.Id,
            buxhetiAktual = dto.BuxhetiAktual,
            autoNdarja = dto.AutoNdarja,
            UserId = shkollaUser.Id,
            createdAt = DateTime.UtcNow
        };

        context.tblShkolla.Add(shkolla);
        await context.SaveChangesAsync();

        _logger.LogInformation("Shkolla '{Shkolla}' added to schema '{Schema}'", shkolla.emriShkolles, schemaName);
    }

    //public async Task AddSchoolToSchemaAsync(string schemaName, Shkolla shkolla)
    //{
    //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
    //        .UseSqlServer(_configuration.GetConnectionString("DefaultSQLConnection"));

    //    var tenantProvider = new StaticTenantProvider(schemaName);
    //    await using var context = new ApplicationDbContext(optionsBuilder.Options, tenantProvider);

    //    // Save Adresa if not tracked
    //    if (shkolla.Adresa != null && shkolla.Adresa.Id == 0)
    //    {
    //        context.tblAdresat.Add(shkolla.Adresa);
    //        await context.SaveChangesAsync();
    //    }

    //    // Save Person if not exists
    //    if (!await context.tblPersons.AnyAsync(p => p.NumriPersonal == shkolla.drejtori))
    //    {
    //        if (shkolla.Person != null)
    //        {
    //            shkolla.Person.AdresaId = shkolla.Adresa.Id;
    //            context.tblPersons.Add(shkolla.Person);
    //            await context.SaveChangesAsync();
    //        }
    //    }

    //    // Ensure correct foreign key reference
    //    shkolla.AdresaId = shkolla.Adresa.Id;

    //    context.tblShkolla.Add(shkolla);
    //    await context.SaveChangesAsync();

    //    _logger.LogInformation("Shkolla '{Name}' added to schema '{Schema}'", shkolla.emriShkolles, schemaName);
    //}

    //public async Task<int> EnsureAdresaExistsAsync(ApplicationDbContext context, Adresa adresa)
    //{
    //    var existing = await context.tblAdresat.FirstOrDefaultAsync(a =>
    //        a.Rruga == adresa.Rruga &&
    //        a.Qyteti == adresa.Qyteti &&
    //        a.Shteti == adresa.Shteti &&
    //        a.KodiPostal == adresa.KodiPostal
    //    );

    //    if (existing != null)
    //        return existing.Id;

    //    context.tblAdresat.Add(adresa);
    //    await context.SaveChangesAsync();
    //    return adresa.Id;
    //}
}
