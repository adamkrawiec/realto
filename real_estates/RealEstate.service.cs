using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
  class RealEstateService {
    readonly DB db;

    public RealEstateService() {
      db = DB.GetInstance();
    }

    private StaircaseDTO presentStaircase(Staircase staircase) {
      List<EstateUnitDTO> estateUnitDTOs = presentEstateUnits(staircase);
      return new StaircaseDTO(staircase, estateUnitDTOs);
    }
    private List<EstateUnitDTO> presentEstateUnits(Staircase staircase) {
      return db.EstateUnits.
          FindAll(estateUnit => estateUnit.Staircase == staircase).
          Select(estateUnit => new EstateUnitDTO(estateUnit)).
          ToList();

    }
    public RealEstateDTO presentRealEstate (RealEstate realEstate) {
      if(realEstate is null) return new RealEstateDTO();

      List<Staircase> staircases = db.Staircases.FindAll(staircase => staircase.RealEstate.Id == realEstate.Id);
      
      List<StaircaseDTO> staircaseDTOs = staircases.Select((staircase) => presentStaircase(staircase)).ToList();

      return new RealEstateDTO(realEstate, staircaseDTOs);
    }

    public EstateUnitDTO presentEstateUnit (EstateUnit estateUnit) {
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