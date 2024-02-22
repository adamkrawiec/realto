using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RealEstates.Models;

namespace RealEstates {

    class RealEstateDTO {
        public int? Id { get; }
        public string? City { get; }
        public string? Street { get; }
        public int? Number { get; }
        public List<EstateUnitDTO>? EstateUnits { get; }

        public string? ShowPath { get; set; }

        public RealEstateDTO() { 
            Id = null;
        }
        public RealEstateDTO(RealEstate realEstate, List<EstateUnitDTO>? estateUnits = null) {
            Id = realEstate.Id;
            Number = realEstate.Number;
            City = realEstate.Address.City.Name;
            Street = realEstate.Address.Street.Name;
            EstateUnits = estateUnits is null ? [] : estateUnits;
        }
    };

    class StaircaseDTO {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<EstateUnitDTO>? EstateUnits { get; set; }

        public StaircaseDTO(Staircase staircase, List<EstateUnitDTO>? estateUnits = null) {
            Id = staircase.Id;
            Number = staircase.Number;
            EstateUnits = estateUnits is null ? [] : estateUnits;
        }
    };

    class EstateUnitDTO {
        public int Id { 
            get { return _estateUnit.Id; }
        }

        public int Number {
            get { return _estateUnit.Number; }
        }

        public float Area {
            get { return _estateUnit.Area; }
        }
        
        public string Address {
            get {
                return $"{_estateUnit.RealEstate.Address.City.Name}, {_estateUnit.RealEstate.Address.Street.Name} {_estateUnit.RealEstate.Number}/{_estateUnit.Number}";
            }
        }

        public TenantDTO? CurrentTenant {
            get {
                Tenant? tenant = _estateUnit.CurrentTenant();
                return tenant == null ? null : new TenantDTO(tenant);
            }
        }

        public string? ShowPath { get; set; }
        public string? TenantsPath { get; set; }

        private EstateUnit _estateUnit;
        public EstateUnitDTO(EstateUnit estateUnit) {
            _estateUnit = estateUnit;
        }
    }

    public class TenantDTO {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? MovedInAt { get; set; }
        public DateTime? MovedOutAt { get; set; }

        public TenantDTO(Tenant tenant) {
            Id = tenant.Id;
            Name = tenant.Name;
            MovedInAt = tenant.MovedInAt;
            MovedOutAt = tenant.MovedOutAt;
        }
    }
}
