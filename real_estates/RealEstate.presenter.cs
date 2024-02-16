using DB;
using RealEstates.Models;

namespace RealEstates {
  class RealEstatePresenter {
    private readonly RealEstate? _realEstate;
    private readonly List<EstateUnit> _estateUnits;
    private DBClient db = DBClient.GetInstance();

    public RealEstatePresenter() {
      _estateUnits = [];
    }
    public RealEstatePresenter(RealEstate realEstate) {
      _realEstate = realEstate;
      _estateUnits = db.EstateUnits.FindAll(estateUnit => estateUnit.RealEstate == _realEstate);
    }

    public RealEstateDTO Present() {
      return _realEstate == null ? new RealEstateDTO() : new RealEstateDTO(_realEstate, PresentEstateUnits());
    }


    private List<EstateUnitDTO> PresentEstateUnits() {
      return _estateUnits.Select(estateUnit => new EstateUnitDTO(estateUnit)).ToList();
    }
  }
}