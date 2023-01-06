using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class Department //Deparment Table
    {
        [Key]
        public int DepId { get; set; }
        [Required]
        public string DepName { get; set; }
        public string LandlineNumber { get; set; }
        public string Location { get; set; }
        public int CompanyRegNo { get; set; } //CompanyRegNo Foreign Key
        [ForeignKey("CompanyRegNo")]
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
