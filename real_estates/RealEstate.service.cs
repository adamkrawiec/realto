using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
  class RealEstateService {
    readonly DB db;

    public RealEstateService() {
      db = DB.GetInstance();
    }


    public RealEstateDTO PresentRealEstate (RealEstate realEstate) {
      return new RealEstatePresenter(realEstate).Present();
    }

    public EstateUnitDTO PresentEstateUnit (EstateUnit estateUnit) {
      return new EstateUnitDTO(estateUnit);
    }

    public List<RealEstate> AddRealEstate ([FromForm] string streetName, [FromForm] string cityName, [FromForm] float area) {
    Street? street = db.Streets.Find(street => street.Name == streetName);
    City? city = db.Cities.Find(city => city.Name == cityName);

    if (street != null && city != null) {
        RealEstate realEstate = new RealEstate(new Address(street, city), area);
        db.RealEstates.Add(realEstate);
    }
    
    return db.RealEstates;
}
  }
}