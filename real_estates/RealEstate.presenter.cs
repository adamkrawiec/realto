namespace RealEstates {
  class RealEstatePresenter {
    private readonly RealEstate? _realEstate;
    private readonly List<Staircase> _staircases;

    public RealEstatePresenter() {
      _staircases = [];
    }
    public RealEstatePresenter(RealEstate realEstate) {
      _realEstate = realEstate;
      _staircases = DB.GetInstance().Staircases.FindAll(staircase => staircase.RealEstate.Id == _realEstate.Id);
    }

    public RealEstateDTO Present() {
      return _realEstate == null ? new RealEstateDTO() : new RealEstateDTO(_realEstate, PresentStaircases());
    }

    private List<StaircaseDTO> PresentStaircases() {
      return _staircases.Select(staircase => new StaircasePresenter(staircase).Present()).ToList();
    }
  }

  class StaircasePresenter {
    private readonly Staircase _staircase;
    private readonly List<EstateUnit> _estateUnits;

    public StaircasePresenter(Staircase staircase) {
      _staircase = staircase;
      _estateUnits = DB.GetInstance().EstateUnits.FindAll(estateUnit => estateUnit.Staircase == _staircase);
    }

    public StaircaseDTO Present() {
      return new StaircaseDTO(_staircase, PresentEstateUnits());
    }

    private List<EstateUnitDTO> PresentEstateUnits() {
      return _estateUnits.Select(estateUnit => new EstateUnitDTO(estateUnit)).ToList();
    }
  }
}