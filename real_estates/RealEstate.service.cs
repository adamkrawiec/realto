using RealEstates.Models;
using DB;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace RealEstates {
  class RealEstateService {
    readonly DBClient db;

    public RealEstateService() {
      db = DBClient.GetInstance();
    }


    public RealEstateDTO PresentRealEstate (RealEstate realEstate) {
      return new RealEstatePresenter(realEstate).Present();
    }

    public EstateUnitDTO PresentEstateUnit (EstateUnit estateUnit) {
      return new EstateUnitDTO(estateUnit);
    }

    public List<RealEstate> AddRealEstate ([FromForm] string streetName, [FromForm] string cityName, [FromForm] float area, [FromForm] int number) {
    Street? street = db.Streets.Find(street => street.Name == streetName);
    City? city = db.Cities.Find(city => city.Name == cityName);

    if (street != null && city != null) {
        RealEstate realEstate = new RealEstate(new Address(street, city), area, number);
        db.RealEstates.Add(realEstate);
    }
    
    return db.RealEstates;
}
  }
}