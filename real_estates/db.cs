namespace RealEstates {
  class DB {
    public List<RealEstate> RealEstates { get; set; }
    public List<Staircase> Staircases { get; set; }
    public List<EstateUnit> EstateUnits { get; set; }
    public List<Street> Streets { get; set; }
    public List<City> Cities { get; set; }

    private DB() { 
        RealEstates = new List<RealEstate>();
        Staircases = new List<Staircase>();
        EstateUnits = new List<EstateUnit>();
        Streets = new List<Street>();
        Cities = new List<City>();
    }
    private static DB _instance;

    public static DB GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DB();
        }
        return _instance;
    }
  }
}