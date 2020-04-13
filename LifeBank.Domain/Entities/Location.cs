using LifeBank.Domain.Common;

namespace LifeBank.Domain.Entities
{
    public class Location : AuditableEntity
    {
        public long LocationId { get; set; }
        public string LocatioName { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public int ParishId { get; set; }
        public Parish Parish { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
