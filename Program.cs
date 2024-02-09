using Microsoft.AspNetCore.Mvc;
using RealEstates;

List<Street> streets = new List<Street>();
streets.Add(new Street("Bocianów"));
streets.Add(new Street("Labędzi"));
streets.Add(new Street("Kormoranów"));

List<City> cities = new List<City>();
cities.Add(new City("Katowice"));
cities.Add(new City("Tychy"));
cities.Add(new City("Kraków"));

List<RealEstate> realEstates = new List<RealEstate>();
realEstates.Add(new RealEstate(new Address(streets[0], cities[0])));
realEstates.Add(new RealEstate(new Address(streets[1], cities[0])));
realEstates.Add(new RealEstate(new Address(streets[2], cities[0])));
realEstates.Add(new RealEstate(new Address(streets[0], cities[1])));


var builder = WebApplication.CreateBuilder();
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseAntiforgery();

app.MapGet("/streets", () => {
    return streets;
});

app.MapGet("/cities", () => {
    return cities;
});

app.MapGet("/real_estates", () => {
    return realEstates;
});

app.MapPost("/real_estates", ([FromForm] string streetName, [FromForm] string cityName) => {
    Street? street = streets.Find(street => street.Name == streetName);
    City? city = cities.Find(city => city.Name == cityName);

    if (street != null && city != null) {
        RealEstate realEstate = new RealEstate(new Address(street, city));
        realEstates.Add(realEstate);
    }
    
    return realEstates;
}).DisableAntiforgery();

app.MapGet("/real_estates/{id}", (int id) => {
    return realEstates.Find(realEstate => realEstate.Id == id);
});

app.Run();
