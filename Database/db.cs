using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

namespace DB {
    public class DBClient {
        public List<RealEstate> RealEstates { get; set; }
        public List<Staircase> Staircases { get; set; }
        public List<EstateUnit> EstateUnits { get; set; }
        public List<Street> Streets { get; set; }
        public List<City> Cities { get; set; }
        public List<Tenant> Tenants { get; set; }

        private readonly AppDBContext? _context;
        
        public DBClient(AppDBContext? context) { 
            RealEstates = new List<RealEstate>();
            Staircases = new List<Staircase>();
            EstateUnits = new List<EstateUnit>();
            Streets = new List<Street>();
            Cities = new List<City>();
            Tenants = new List<Tenant>();
            _context = context;
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

            Streets = streets;
            Cities = cities; 
        
            // loadRealEstates();
            // loadEstateUnits();
            // loadTenants();
        }

        private void loadRealEstates() {
            string path = "./Database/real_estates.csv";
            List<RealEstate> realEstates = [];


            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines.Skip(1))
            {
                string[] columns = line.Split(',');
                int realEstateId = Int32.Parse(columns[0]);
                string city= columns[1];
                string street = columns[2];
                int number = Int32.Parse(columns[3]);
                int area = Int32.Parse(columns[4]);
                _context.RealEstates.Add(new RealEstate(city, street, area, number));
                _context.SaveChanges();
            }
            RealEstates = realEstates;
        }

        private void loadEstateUnits() {
            string path = "./Database/estate_units.csv";
            List<EstateUnit> estateUnits = [];

            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines.Skip(1))
            {
                string[] columns = line.Split(',');
                int realEstateId = Int32.Parse(columns[1]);
                int number = Int32.Parse(columns[2]);
                int area = Int32.Parse(columns[3]);
                RealEstate realEstate = RealEstates.Find(realEstate => realEstate.Id == realEstateId);

                estateUnits.Add(new EstateUnit(realEstate, number, area));
            }
            EstateUnits = estateUnits;
        }

        private void loadTenants() {
            string path = "./Database/tenants.csv";
            List<Tenant> tenants = [];

            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines.Skip(1))
            {
                string[] columns = line.Split(',');
                int estateUnitId = Int32.Parse(columns[1]);
                string name = columns[2];
                DateTime movedInAt = DateTime.Parse(columns[3]);
                DateTime? movedOutAt = null;
                try {
                    movedOutAt = DateTime.Parse(columns[4]);
                } catch (FormatException) {
                    movedOutAt = null;
                }
                EstateUnit estateUnit = EstateUnits.Find(estateUnit => estateUnit.Id == estateUnitId);

                tenants.Add(new Tenant(name, estateUnit, movedInAt, movedOutAt));
            }
            Tenants = tenants;
        }
  }
}