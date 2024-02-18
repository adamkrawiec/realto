using RealEstates.Models;
using DB;

using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
  class EstateUnitService {
    readonly DBClient db;

    public EstateUnitService() {
      db = DBClient.GetInstance();
    }


    public List<EstateUnit> EstateUnits () {
      return db.EstateUnits;
    }

    public EstateUnit? FindEstateUnit(int estateUnitId) {
      return db.EstateUnits.Find(estateUnit => estateUnit.Id == estateUnitId);
    }

    public EstateUnitDTO PresentEstateUnit (EstateUnit estateUnit) {
      return new EstateUnitDTO(estateUnit);
    }
  }
}