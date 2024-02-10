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
}