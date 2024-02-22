using RealEstates.Models;
using DB;

using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
    class RealEstateService {
        readonly DBClient db;

        public RealEstateService() {
            db = DBClient.GetInstance();
        }

        public List<RealEstateDTO> GetAllRealEstates (string? city, string? street, int? number) {
            IEnumerable<RealEstate> realEstates = db.RealEstates;
            if(city != null) {
                realEstates = from realEstate in realEstates
                    where string.Equals(realEstate.Address.City.Name, city, StringComparison.OrdinalIgnoreCase)
                    select realEstate;
            }

            if(street != null) {
                realEstates = from realEstate in realEstates
                    where string.Equals(realEstate.Address.Street.Name, street, StringComparison.OrdinalIgnoreCase)
                    select realEstate;
            }

            if(number != null) {
                realEstates = from realEstate in realEstates
                    where realEstate.Number == number
                    select realEstate;
            } 

            return realEstates.ToList().Select(realEstate => new RealEstateDTO(realEstate)).ToList();
        }

        public RealEstate? FindRealEstate(int realEstateId) {
            return findRealEstate(realEstateId);
        }

        public RealEstateDTO? PresentRealEstate (int realEstateId) {
            RealEstate? realEstate = findRealEstate(realEstateId);
            
            if(realEstate == null)  return null;
            
            List<EstateUnitDTO> estateUnits = db.EstateUnits.
              FindAll(estateUnit => estateUnit.RealEstate.Id == realEstateId).
              Select(estateUnit => new EstateUnitDTO(estateUnit)).
              ToList();

            return new RealEstateDTO(realEstate, estateUnits);
        }

        public RealEstateDTO? AddRealEstate (string streetName, string cityName, float area, int? number) {
            Street? street = db.Streets.Find(street => street.Name == streetName);
            City? city = db.Cities.Find(city => city.Name == cityName);

            if (street == null || city == null || number == null) {
                return null;
            }

            RealEstate realEstate = new RealEstate(new Address(street, city), area, number.Value);
            db.RealEstates.Add(realEstate); 
            return new RealEstateDTO(realEstate);
        }

        private RealEstate? findRealEstate(int realEstateId) {
            return db.RealEstates.Find(realEstate => realEstate.Id == realEstateId);
        }
    }
}