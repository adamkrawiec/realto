var app = WebApplication.Create();

Street[] streets = {
    new Street("Bocianów"),
    new Street("Labędzi"),
    new Street("Kormoranów")
};

City[] cities = {
    new City("Katowice"),
    new City("Tychy"),
    new City("Kraków")
};

RealEstate[] realEstates = {
    new RealEstate(new Address(streets[0], cities[0])),
    new RealEstate(new Address(streets[1], cities[0])),
    new RealEstate(new Address(streets[2], cities[0])),
    new RealEstate(new Address(streets[0], cities[1])),
};

app.MapGet("/streets", () => {
    return streets;
});

app.MapGet("/cities", () => {
    return cities;
});

app.MapGet("/real_estates", () => {
    return realEstates;
});

app.MapGet("/real_estates/{id}", (int id) => {
    return Array.Find(realEstates, realEstate => realEstate.Id == id);
});

app.Run();

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

    public RealEstate(Address address) {
        _id += 1;
        Id = _id;
        Address = address;
    }
}
