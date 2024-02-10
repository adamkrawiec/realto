namespace RealEstates {

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
}