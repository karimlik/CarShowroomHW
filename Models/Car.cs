using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Make { get; set; } = null;
        public string? Model { get; set; } = null;
        public int? ModelYear { get; set; } = null;
        public int? EngineCapacity { get; set; } = null;
        public int? Price { get; set; } = null;
        public int ShowId { get; set; }
        public virtual Showroom ShowroomInfo { get; set; } = null!;

    }
}
