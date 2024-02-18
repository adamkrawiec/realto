using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RealEstates.Models;

namespace RealEstates {

    class RealEstateDTO {
        public int? Id { get; }
        public string? City { get; }
        public string? Street { get; }
        public List<EstateUnitDTO>? EstateUnits { get; }

        public string? ShowPath { get; set; }

        public RealEstateDTO() { 
            Id = null;
        }
        public RealEstateDTO(RealEstate realEstate, List<EstateUnitDTO>? estateUnits = null) {
            Id = realEstate.Id;
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
        public int Id { get; }

        public int Number { get; }

        public float Area { get; }
        
        public string Address { get; }

        public TenantDTO? CurrentTenant { get; }

        public string? ShowPath { get; set; }
        public string? TenantsPath { get; set; }

        public EstateUnitDTO(EstateUnit estateUnit) {
            Id = estateUnit.Id;
            Number = estateUnit.Number;
            Area = estateUnit.Area;
            Address = $"{estateUnit.RealEstate.Address.City.Name}, {estateUnit.RealEstate.Address.Street.Name} {estateUnit.RealEstate.Number}/{estateUnit.Number}";
            CurrentTenant = estateUnit.CurrentTenant() == null ? null : new TenantDTO(estateUnit.CurrentTenant());
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
