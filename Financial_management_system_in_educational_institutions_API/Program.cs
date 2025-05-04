using Financial_management_system_in_educational_institutions_API;
using Financial_management_system_in_educational_institutions_API.Data;
using Financial_management_system_in_educational_institutions_API.Services.Shared;
using Financial_management_system_in_educational_institutions_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Interfaces.Shared;
using Financial_management_system_in_educational_institutions_API.Models;

using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Financial_management_system_in_educational_institutions_API.Models.Identity;
var builder = WebApplication.CreateBuilder(args);

// Access Configuration from builder
var configuration = builder.Configuration;

// -------------------- DATABASE --------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultSQLConnection"));
});

// -------------------- MULTITENANCY --------------------
builder.Services.AddHttpContextAccessor(); // Needed for accessing claims in UserTenantProvider
builder.Services.AddScoped<ITenantProvider, UserTenantProvider>();
builder.Services.AddSingleton<IModelCacheKeyFactory, TenantModelCacheKeyFactory>();
builder.Services.AddScoped<TenantSchemaInitializer>();
builder.Services.AddScoped<TenantKompaniaService>();

// -------------------- CORS --------------------
builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders(new[] { "totalAmountOfRecords" });
    });
});




builder.Services.AddLogging();
// -------------------- CONTROLLERS --------------------
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------- CUSTOM SERVICES --------------------
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IShkollaService, ShkollaService>();
builder.Services.AddScoped<IKompaniaService, KompaniaService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IPorositeService, PorositeService>();
builder.Services.AddScoped<IRaportiService, RaportiService>();
builder.Services.AddScoped<IProduktiService, ProduktiService>();
builder.Services.AddScoped<IStafiService, StafiService>();




builder.Services.AddAutoMapper(typeof(MappingProfile));

// -------------------- IDENTITY --------------------
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// -------------------- JWT AUTH --------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["keyjwt"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdmin", policy => policy.RequireClaim("role", "admin"));
});

var app = builder.Build();

// -------------------- MIDDLEWARE --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
