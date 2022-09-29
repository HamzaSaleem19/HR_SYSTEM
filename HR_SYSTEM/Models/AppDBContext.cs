
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


    }
}

