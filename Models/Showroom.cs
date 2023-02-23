using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Models
{
    public class Showroom
    {
        public int ShowroomId { get; set; }
        public string? Name { get; set; } = null;
        public int? Phone { get; set; } = null;
        public string? Address { get; set; } = null;
        public virtual ICollection<Car> Cars { get; } = new List<Car>();
    }
}
