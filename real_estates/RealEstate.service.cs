using RealEstates.Models;
using DB;

using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
    class RealEstateService {
        readonly DBClient db;

        public RealEstateService() {
            db = DBClient.GetInstance();
        }

        public List<RealEstate> GetAllRealEstates () {
            return db.RealEstates;
        }

        public RealEstate? FindRealEstate(int realEstateId) {
            return db.RealEstates.Find(realEstate => realEstate.Id == realEstateId);
        }

        public RealEstateDTO? PresentRealEstate (int realEstateId) {
            RealEstate realEstate = db.RealEstates.Find(realEstate => realEstate.Id == realEstateId);
            if(realEstate != null)
            {
                return new RealEstatePresenter(realEstate).Present();
            }

            return null;
        }

        public List<RealEstate> AddRealEstate (string streetName, string cityName, float area, int number) {
            Street? street = db.Streets.Find(street => street.Name == streetName);
            City? city = db.Cities.Find(city => city.Name == cityName);

            if (street != null && city != null) {
                RealEstate realEstate = new RealEstate(new Address(street, city), area, number);
                db.RealEstates.Add(realEstate);
            }
      
        return db.RealEstates;
        }
    }
}