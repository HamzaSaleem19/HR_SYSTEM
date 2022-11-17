using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class District : BaseModel
    {
        public int DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public Division Divisions { get; set; }
        public ICollection<Tehsil> Tehsils{ get; set; }

    }
}
