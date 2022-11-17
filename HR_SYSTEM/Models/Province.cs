using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_SYSTEM.Models
{
    public class Province : BaseModel
    {
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Countries { get; set; }
        public ICollection<Division> Divisions { get; set; }

    }

}
