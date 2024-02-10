namespace RealEstates {
    class Street {
        public string Name { get; set; }

        public Street(string name) {
            Name = name;
        }
    }

    class City {
        public string Name { get; set; }

        public City(string name) {
            Name = name;
        }
    }

    class Address {
        public Street Street { get; set; }
        public City City { get; set; }

        public Address(Street street, City city) {
            Street = street;
            City = city;
        }
    }

    class RealEstate {
        private static int _id = 0;
        public int Id { get; }
        public Address Address { get; set; }
        public float Area { get; set; }

        public RealEstate(Address address, float area) {
            _id += 1;
            Id = _id;
            Address = address;
            Area = area;
        }
    }

    class Staircase {
        private static int _id = 0;
        public int Id { get; }
        public int Number { get; set; }
        public RealEstate RealEstate { get; set; }

        public Staircase(int number, RealEstate realEstate) {
            _id += 1;
            Id = _id;
            Number = number;
            RealEstate = realEstate;
        }
    }

    class EstateUnit {
        private static int _id = 0;
        public int Id { get; }

        public int Number { get; set; }
        public Staircase Staircase { get; set; }

        public float Area { get; set; }

        public EstateUnit(int number, Staircase staircase, float area) {
            _id += 1;
            Id = _id;
            Number = number;
            Staircase = staircase;
            Area = area;
        }
    }

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
