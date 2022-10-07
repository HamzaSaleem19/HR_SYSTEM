using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleType { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}