using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class Division : BaseModel
    {
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province Provinces { get; set; }
        public ICollection<District> Districts { get; set; }

    }

}
