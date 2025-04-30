using System;
using Financial_management_system_in_educational_institutions_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

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
            // 1) Seed data for Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    accId = 1,
                    organisationName = "Rilindja",
                    role = "kompani",
                    username = "kompania1",
                    email = "rilindja@gmail.com",
                    passwordHash = "324refds32q",
                    salt = "fdszx",
                    twoFAcode = 491593,
                    twoFAtime = DateTime.Now
                },//testing
                new Account
                {
                    accId = 2,
                    organisationName = "Hasan Prishtina",
                    role = "universitet",
                    username = "kompania1",
                    email = "hasanprishtina@gmail.com",
                    passwordHash = "vdsv2wqc2ws2",
                    salt = "adsyx",
                    twoFAcode = 154923,
                    twoFAtime = DateTime.Now
                }
            );

            modelBuilder.Entity<Komuna>().ToTable("tblKomuna");

            modelBuilder.Entity<Account>().ToTable("tblAccounts");

            modelBuilder.Entity<Komuna>()
                .Property(k => k.buxhetiAktual)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Shkolla>()
                .Property(s => s.buxhetiAktual)
                .HasPrecision(18, 2);

            modelBuilder.Entity<StafiShkolles>()
                .Property(s => s.paga)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Ndalesat>()
                .Property(n => n.ShumaNdaleses)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Pagesat>()
                .Property(p => p.TVSH)
                .HasPrecision(18, 2);



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
