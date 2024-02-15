namespace RealEstates {
  namespace Models {
        public class RealEstate {
        private static int _id = 0;
        public int Id { get; }
        public Address Address { get; set; }
        public float Area { get; set; }
        public int Number { get; set; }

        public RealEstate(Address address, float area, int number) {
            _id += 1;
            Id = _id;
            Address = address;
            Area = area;
            Number = number;
        }
    }
  }
}