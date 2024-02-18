using DB;
using Utils;

namespace RealEstates {
  namespace Models {
    public class Tenant {
        private static int _id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public EstateUnit EstateUnit { get; set; }
        public DateTime MovedInAt { get; set; }
        public DateTime? MovedOutAt { get; set; }

        public Tenant(string name, EstateUnit estateUnit, DateTime movedInAt, DateTime? movedOutAt = null) {
            _id += 1;
            Id = _id;
            Name = name;
            EstateUnit = estateUnit;
            MovedInAt = movedInAt;
            MovedOutAt = movedOutAt;
        }

        public DateRange Period() {
            return new DateRange(MovedInAt, MovedOutAt ?? DateTime.Now);
        }

        public bool otherTenatOverlaps(Tenant otherTenant) {
            return Period().Overlap(otherTenant.Period());
        }

        public Tenant? PreviousTenant() {
          return DBClient.GetInstance().Tenants.FindAll(tenant => tenant.EstateUnit == EstateUnit).OrderBy(t => t.MovedInAt).ToList().Find(tenant => tenant.MovedOutAt < MovedInAt);}
    }
  }
}