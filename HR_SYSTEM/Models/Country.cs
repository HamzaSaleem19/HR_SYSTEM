using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_SYSTEM.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Country : BaseModel
    {
        public ICollection<Province> Provinces { get; set; }
    }
}
