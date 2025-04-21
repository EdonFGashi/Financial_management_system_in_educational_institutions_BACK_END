using Financial_management_system_in_educational_institutions_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Financial_management_system_in_educational_institutions_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Account> tblAccounts { get; set; }
        public DbSet<Person> tblPersons { get; set; }
        public DbSet<Shkolla> tblShkolla { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account()
                {
                    accId = 1,
                    organisationName = "Rilindja",
                    role = "kompani",
                    username = "kompania1",
                    passwordHash = "324refds32q",
                    salt = "fdszx",
                    twoFAcode = 491593,
                    twoFAtime = DateTime.Now
                },
                new Account()
                {
                    accId = 2,
                    organisationName = "Hasan Prishtina",
                    role = "universitet",
                    username = "kompania1",
                    passwordHash = "vdsv2wqc2ws2",
                    salt = "adsyx",
                    twoFAcode = 154923,
                    twoFAtime = DateTime.Now
                }
            );
        }

    }
}
