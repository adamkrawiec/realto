namespace RealEstates {
  namespace Models {
    public class Staircase {
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
  }
}