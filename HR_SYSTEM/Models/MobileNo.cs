using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class MobileNo
    {
        [Key]
        public int MobileId { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$",
                   ErrorMessage = "Entered Mobile Number format is not valid.")]
        public string MobileNumber { get; set; }
        [Required]
        public int EmpId { get; set; } //EmpdId Foriegn Key
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }
        public int CompanyRegNo { get; set; }
        public int DepId { get; set; }
    }
}
