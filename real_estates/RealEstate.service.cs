using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
  class RealEstateService {
    readonly DB db;

    public RealEstateService() {
      db = DB.GetInstance();
    }

    public RealEstateDTO FindRealEstate (int id) {
      RealEstate? realEstate = db.RealEstates.Find(realEstate => realEstate.Id == id);
      if(realEstate is null) return new RealEstateDTO();

      List<Staircase> realEstateStaircases = db.Staircases.FindAll(staircase => staircase.RealEstate.Id == id);
      
      List<StaircaseDTO> staircaseDTOs = realEstateStaircases.Select((staircase) => {
          IEnumerable<EstateUnitDTO> estateUnitDTOs = db.EstateUnits.
              FindAll(estateUnit => estateUnit.Staircase == staircase).
              Select(estateUnit => new EstateUnitDTO(estateUnit));
          return new StaircaseDTO(staircase, estateUnitDTOs.ToList());
      }).ToList();

      return new RealEstateDTO(realEstate, staircaseDTOs.ToList());
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