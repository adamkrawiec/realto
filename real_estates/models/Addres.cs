namespace RealEstates {
    namespace Models {
        public class Street {
            public string Name { get; set; }

            public Street(string name) {
                Name = name;
            }
        }

        public class City {
            public string Name { get; set; }

            public City(string name) {
                Name = name;
            }
        }

        public class Address {
            public Street Street { get; set; }
            public City City { get; set; }

            public Address(Street street, City city) {
                Street = street;
                City = city;
            }
        }
    }
}