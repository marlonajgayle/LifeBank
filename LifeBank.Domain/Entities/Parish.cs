using System.Collections.Generic;

namespace LifeBank.Domain.Entities
{
    public class Parish
    {
        public int ParishId { get; set; }
        public string ParishName { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
