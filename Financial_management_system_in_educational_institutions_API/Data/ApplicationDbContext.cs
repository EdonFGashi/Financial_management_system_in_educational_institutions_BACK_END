using System;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Multitenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Financial_management_system_in_educational_institutions_API.Models.Identity;
using System.Security;
using System.Xml;


namespace Financial_management_system_in_educational_institutions_API.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<AppUser, AppRole, string,
                   AppUserClaim, AppUserRole, AppUserLogin,
                   AppRoleClaim, AppUserToken>

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
        public DbSet<Shporta> Shportat { get; set; }


        public DbSet<RolePermissions> RolePermissions { get; set; }
        public DbSet<Operations> Operations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply default schema dynamically — applies to tenant tables
            if (!_isDesignTime)
            {
                modelBuilder.HasDefaultSchema(_schema);
            }

            // Call base *before* your overrides
            base.OnModelCreating(modelBuilder);

            // ✅ Now override Identity table mappings
            modelBuilder.Entity<AppUser>().ToTable("AspNetUsers", "shared");
            modelBuilder.Entity<AppRole>().ToTable("AspNetRoles", "shared");
            modelBuilder.Entity<AppUserRole>().ToTable("AspNetUserRoles", "shared");
            modelBuilder.Entity<AppUserClaim>().ToTable("AspNetUserClaims", "shared");
            modelBuilder.Entity<AppUserLogin>().ToTable("AspNetUserLogins", "shared");
            modelBuilder.Entity<AppRoleClaim>().ToTable("AspNetRoleClaims", "shared");
            modelBuilder.Entity<AppUserToken>().ToTable("AspNetUserTokens", "shared");

            // ✅ Shared custom tables
            modelBuilder.Entity<Komuna>().ToTable("tblKomuna", "shared");
            modelBuilder.Entity<Account>().ToTable("tblAccounts", "shared");

            modelBuilder.Entity<Operations>().ToTable("Operations", "shared");
            modelBuilder.Entity<RolePermissions>().ToTable("RolePermissions", "shared");


            // ✅ Tenant Tables (explicit schema)
            modelBuilder.Entity<Person>().ToTable("tblPersons", _schema);
            modelBuilder.Entity<Produkti>().ToTable("Produkti",_schema);
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
            modelBuilder.Entity<Komuna>().Property(k => k.BuxhetiAktual).HasPrecision(18, 2);
            modelBuilder.Entity<Shkolla>().Property(s => s.buxhetiAktual).HasPrecision(18, 2);
            modelBuilder.Entity<StafiShkolles>().Property(s => s.paga).HasPrecision(18, 2);
            modelBuilder.Entity<Ndalesat>().Property(n => n.ShumaNdaleses).HasPrecision(18, 2);
            modelBuilder.Entity<Pagesat>().Property(p => p.TVSH).HasPrecision(18, 2);

            // ✅ Relationships

            modelBuilder.Entity<Produkti>()
            .Property(p => p.Fotografia)
            .HasMaxLength(1000);

            modelBuilder.Entity<Komuna>()
                .Property(k => k.BuxhetiAktual)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Porosite>()
                .HasOne(p => p.Shkolla)
                .WithMany()
                .HasForeignKey(p => p.ShkollaId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Shkolla>()
                .HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Marreveshja>()
                .HasOne(m => m.Komuna)
                .WithMany()
                .HasForeignKey(m => m.KomunaId)
                .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Person>()
                .HasOne(p => p.Adresa)
                .WithMany()
                .HasForeignKey(p => p.AdresaId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Shkolla>()
                .HasOne(s => s.Adresa)
                .WithMany()
                .HasForeignKey(s => s.AdresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shkolla>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // modelBuilder.Entity<RolePermissions>()
            //.HasOne(s => s.ClaimId)
            //.WithMany()
            //.HasForeignKey(s => s.ClaimId);

            modelBuilder.Entity<RolePermissions>()
               .HasKey(rp => rp.RolePermissionId);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.AspNetUserClaims)
                .WithMany()                       // No reverse navigation in AppUserClaim
                .HasForeignKey(rp => rp.ClaimId)
                .IsRequired();

            modelBuilder.Entity<AppUserClaim>()
                 .HasOne(c => c.AppUser)
                 .WithMany()
                 .HasForeignKey(c => c.UserId)
                 .OnDelete(DeleteBehavior.Restrict);


            //            modelBuilder.Entity<Permissions>().HasData(
            //    new Permissions { PermissionId = 1, Name = "Read Users", Verb = "GET", Resource = "Users" },
            //    new Permissions { PermissionId = 2, Name = "Create User", Verb = "POST", Resource = "Users" }
            //);
        }
    }
    }
