using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class Tehsil : BaseModel
    {
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District Districts { get; set; }


    }
}
