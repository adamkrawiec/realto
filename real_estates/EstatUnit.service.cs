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

    public EstateUnitDTO? PresentEstateUnit (int estateUnitId) {
      EstateUnit? estateUnit = db.EstateUnits.Find(estateUnit => estateUnit.Id == estateUnitId);
      
      if (estateUnit != null) {
        return new EstateUnitDTO(estateUnit);
      }

      return null;
    }
  }
}