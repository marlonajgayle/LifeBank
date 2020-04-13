using System.Collections.Generic;

namespace LifeBank.Domain.Entities
{
    public class BloodType
    {
        public int BloodTypeId { get; set; }
        public string BloodGroup { get; set; }
        public ICollection<Donor> Donors { get; set; }
    }
}