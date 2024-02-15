namespace RealEstates {
  namespace Models {
    public class EstateUnit {
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
}