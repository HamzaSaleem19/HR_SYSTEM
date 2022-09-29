using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class Company  //Company table
    {
        [Key]
        public int CompanyRegNo { get; set; }
        public string Name { get; set; }
        public string LandlineNo { get; set; }
        public string Address { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
