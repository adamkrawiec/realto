namespace RealEstates {
  namespace Models {
    public class EstateUnit {
        private static int _id = 0;
        public int Id { get; }

        public int Number { get; set; }

        public RealEstate RealEstate { get; set; }

        public float Area { get; set; }

        public EstateUnit(RealEstate realEstate, int number, float area) {
            _id += 1;
            Id = _id;
            RealEstate = realEstate;
            Number = number;
            Area = area;
        }
    }
  }
}