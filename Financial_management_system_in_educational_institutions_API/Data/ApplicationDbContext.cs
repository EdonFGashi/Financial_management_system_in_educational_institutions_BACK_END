using System;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Financial_management_system_in_educational_institutions_API.Models.Identity;


namespace Financial_management_system_in_educational_institutions_API.Data
{
    public class ApplicationDbContext
        : IdentityDbContext
    {
        private readonly string _schema;
        private readonly bool _isDesignTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITenantProvider tenantProvider)
            : base(options)
        {
            _schema = tenantProvider.GetSchema();
            _isDesignTime = tenantProvider is StaticTenantProvider; // Detect if it's being used during design-time
        }

        public DbSet<Account> tblAccounts { get; set; }
        public DbSet<Person> tblPersons { get; set; }
        public DbSet<Shkolla> tblShkolla { get; set; }
        public DbSet<Komuna> tblKomuna { get; set; }
        public DbSet<Role> tblRoles { get; set; }
        public DbSet<Adresa> tblAdresat { get; set; }
        public DbSet<Kompania> tblKompania { get; set; }
        public DbSet<Marreveshja> tblMarreveshja { get; set; }
        public DbSet<Porosite> tblPorosite { get; set; }
        public DbSet<InventariAktual> tblInventariAktual { get; set; }
        public DbSet<NdarjetBuxhetit> tblNdarjetBuxhetit { get; set; }
        public DbSet<OretShtese> tblOretShtese { get; set; }
        public DbSet<Pagesat> tblPagesat { get; set; }
        public DbSet<Tenderi> tblTenderi { get; set; }
        public DbSet<Produkti> tblProdukti { get; set; }
        public DbSet<StafiShkolles> tblStafiShkolles { get; set; }
        public DbSet<Ndalesat> tblNdalesat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply default schema only at runtime (optional fallback)
            if (!_isDesignTime)
            {
                modelBuilder.HasDefaultSchema(_schema);
            }

            // ✅ Explicitly mapped Shared Tables
            modelBuilder.Entity<Komuna>().ToTable("tblKomuna", "shared");
            modelBuilder.Entity<Account>().ToTable("tblAccounts", "shared");

            // ✅ Shared ASP.NET Identity Tables (explicit schema)
            //modelBuilder.Entity<IdentityUser>(e => { e.ToTable(name: "Users", schema: "shared");  });
            //modelBuilder.Entity<IdentityRole>(e => { e.ToTable(name: "Roles", schema: "shared"); });
            //modelBuilder.Entity<IdentityUserRole<string>>(e => { e.ToTable(name: "UserRoles", schema: "shared"); });
            //modelBuilder.Entity<IdentityUserClaim<string>>(e => { e.ToTable(name: "UserClaims", schema: "shared"); });
            //modelBuilder.Entity<IdentityUserLogin<string>>(e => { e.ToTable(name: "UserLogins", schema: "shared"); });
            //modelBuilder.Entity<IdentityRoleClaim<string>>(e => { e.ToTable(name: "RoleClaims", schema: "shared"); });
            //modelBuilder.Entity<IdentityUserToken<string>>(e => { e.ToTable(name: "UserTokens", schema: "shared"); });

            // ✅ Tenant Tables (explicit schema)
            modelBuilder.Entity<Person>().ToTable("tblPersons", _schema);
            modelBuilder.Entity<Shkolla>().ToTable("tblShkolla", _schema);
            modelBuilder.Entity<Role>().ToTable("tblRoles", _schema);
            modelBuilder.Entity<Adresa>().ToTable("tblAdresat", _schema);
            modelBuilder.Entity<Kompania>().ToTable("tblKompania", _schema);
            modelBuilder.Entity<Marreveshja>().ToTable("tblMarreveshja", _schema);
            modelBuilder.Entity<Porosite>().ToTable("tblPorosite", _schema);
            modelBuilder.Entity<InventariAktual>().ToTable("tblInventariAktual", _schema);
            modelBuilder.Entity<NdarjetBuxhetit>().ToTable("tblNdarjetBuxhetit", _schema);
            modelBuilder.Entity<OretShtese>().ToTable("tblOretShtese", _schema);
            modelBuilder.Entity<Pagesat>().ToTable("tblPagesat", _schema);
            modelBuilder.Entity<Tenderi>().ToTable("tblTenderi", _schema);
            modelBuilder.Entity<Produkti>().ToTable("tblProdukti", _schema);
            modelBuilder.Entity<StafiShkolles>().ToTable("tblStafiShkolles", _schema);
            modelBuilder.Entity<Ndalesat>().ToTable("tblNdalesat", _schema);

            // ✅ Decimal Precision
            modelBuilder.Entity<Komuna>().Property(k => k.buxhetiAktual).HasPrecision(18, 2);
            modelBuilder.Entity<Shkolla>().Property(s => s.buxhetiAktual).HasPrecision(18, 2);
            modelBuilder.Entity<StafiShkolles>().Property(s => s.paga).HasPrecision(18, 2);
            modelBuilder.Entity<Ndalesat>().Property(n => n.ShumaNdaleses).HasPrecision(18, 2);
            modelBuilder.Entity<Pagesat>().Property(p => p.TVSH).HasPrecision(18, 2);

            // ✅ Relationships
            modelBuilder.Entity<StafiShkolles>()
                .HasOne(s => s.Person)
                .WithMany()
                .HasForeignKey(s => s.numriPersonal)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StafiShkolles>()
                .HasOne(s => s.Shkolla)
                .WithMany()
                .HasForeignKey(s => s.shkollaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shkolla>()
                .HasOne(s => s.Person)
                .WithMany()
                .HasForeignKey(s => s.drejtori)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Marreveshja>()
                .HasOne(m => m.Komuna)
                .WithMany()
                .HasForeignKey(m => m.KomunaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
    }
