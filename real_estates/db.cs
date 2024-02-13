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

    public void loadData() {
      List<Street> streets = new List<Street>();
      streets.Add(new Street("Bocianów"));
      streets.Add(new Street("Labędzi"));
      streets.Add(new Street("Kormoranów"));

      List<City> cities = new List<City>();
      cities.Add(new City("Katowice"));
      cities.Add(new City("Tychy"));
      cities.Add(new City("Kraków"));

      RealEstate re1 = new RealEstate(new Address(streets[0], cities[0]), 520);
      List<RealEstate> realEstates = [re1];
      realEstates.Add(new RealEstate(new Address(streets[1], cities[0]), 630));
      realEstates.Add(new RealEstate(new Address(streets[2], cities[0]), 820));
      realEstates.Add(new RealEstate(new Address(streets[0], cities[1]), 440));

      Staircase sc1 = new Staircase(1, re1);
      Staircase sc2 = new Staircase(2, re1);
      List<Staircase> staircases = [sc1, sc2];

      EstateUnit eu1 = new EstateUnit(1, sc1, 44.0f);
      EstateUnit eu2 = new EstateUnit(2, sc1, 56.0f);
      EstateUnit eu3 = new EstateUnit(1, sc2, 44.0f);
      EstateUnit eu4 = new EstateUnit(2, sc2, 56.0f);
      EstateUnit eu5 = new EstateUnit(2, sc2, 73.0f);

      List<EstateUnit> estateUnits = [eu1, eu2, eu3, eu4, eu5];

      EstateUnits = estateUnits;
      Staircases = staircases;
      RealEstates = realEstates;
      Streets = streets;
      Cities = cities; 
    }
  }
}