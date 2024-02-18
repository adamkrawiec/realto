using RealEstates.Models;
using DB;

using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
    class EstateUnitService {
        readonly DBClient db = DBClient.GetInstance();

        public EstateUnitService() {
        }


        public List<EstateUnit> EstateUnits () {
            return db.EstateUnits;
        }

        public EstateUnitDTO? PresentEstateUnit (int estateUnitId) {
            EstateUnit? estateUnit = db.EstateUnits.Find(estateUnit => estateUnit.Id == estateUnitId);

            if (estateUnit != null) {
                return new EstateUnitDTO(estateUnit);
            }

            return null;
        }

        public List<TenantDTO> GetTenants (int estateUnitId) {
            List<TenantDTO> tenants = db.Tenants.
              FindAll(tenant => tenant.EstateUnit.Id == estateUnitId)
              .Select(tenant => new TenantDTO(tenant))
              .ToList();

            return tenants;
        }
    }
}