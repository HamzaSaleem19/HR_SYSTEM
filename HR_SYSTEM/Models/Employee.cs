using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class Employee //Employee Table
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        public string Cnic { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int DepId { get; set; }//DepId Foriegn Key
        [ForeignKey("DepId")]
        public Department Department { get; set; }
        public int RoleId { get; set; }//RoleId Foriegn Key
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public ICollection<MobileNo> MobileNos { get; set; }
        
        public int CompanyRegNo { get; set; }
        [NotMapped]
        public string MobileNumber { get; set; }
        public string FilePath { get; set; }

    }
}
