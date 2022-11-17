
 using Microsoft.EntityFrameworkCore;

namespace HR_SYSTEM.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        /// <summary>
        /// RegNo (PK) int| Name string| Landline string| Address string
        /// </summary>     
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MobileNo> MobileNumbers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ANR> ANRs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Tehsil> Tehsils { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id= 1,
                    Name = "Pakistan",
                    
                }
            );
        }
    }
}

