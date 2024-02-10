namespace RealEstates {

    class RealEstateDTO {
        public int? Id { get; }
        public string? City { get; }
        public string? Street { get; }
        public List<StaircaseDTO>? Staircases { get; }

        public RealEstateDTO() { 
            Id = null;
        }
        public RealEstateDTO(RealEstate realEstate, List<StaircaseDTO>? staircases = null) {
            Id = realEstate.Id;
            City = realEstate.Address.City.Name;
            Street = realEstate.Address.Street.Name;
            Staircases = staircases is null ? [] : staircases;
        }
    };

    class StaircaseDTO {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<EstateUnitDTO>? EstateUnits { get; set; }

        public StaircaseDTO(Staircase staircase, List<EstateUnitDTO>? estateUnits = null) {
            Id = staircase.Id;
            Number = staircase.Number;
            EstateUnits = estateUnits is null ?[] : estateUnits;
        }
    };

    class EstateUnitDTO {
        public int Id { get; set; }

        public int Number { get; set; }

        public float Area { get; set; }

        public EstateUnitDTO(EstateUnit estateUnit) {
            Id = estateUnit.Id;
            Number = estateUnit.Number;
            Area = estateUnit.Area;
        }
    }
}