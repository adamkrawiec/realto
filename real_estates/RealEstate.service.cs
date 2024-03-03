using RealEstates.Models;
using DB;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

namespace RealEstates {
    class RealEstateService {
        private readonly AppDBContext _context;

        public RealEstateService(AppDBContext context) {
            _context = context;
        }

        public List<RealEstateDTO> GetAllRealEstates (string? cityName, string? streetName) {
            List<RealEstate> realEstates = _context.RealEstates.ToList();
            return realEstates.Select(realEstate => new RealEstateDTO(realEstate, [])).ToList();
        }

        public async Task<RealEstate?> FindRealEstate(long realEstateId) {
            return await findRealEstate(realEstateId);
        }

        public async Task<RealEstateDTO?> PresentRealEstate (long realEstateId) {
            RealEstate? realEstate = await findRealEstate(realEstateId);
            
            if(realEstate == null)  return null;
            
            // List<EstateUnitDTO> estateUnits = _context.EstateUnits.
            //   FindAll(estateUnit => estateUnit.RealEstate.Id == realEstateId).
            //   Select(estateUnit => new EstateUnitDTO(estateUnit)).
            //   ToList();

            return new RealEstateDTO(realEstate, []);
        }

        public RealEstateDTO? AddRealEstate (string street, string city, float area, int? number) {

            if (street == null || city == null || number == null) {
                return null;
            }

            RealEstate realEstate = new RealEstate(city, street, area, number.Value);
            _context.RealEstates.Add(realEstate); 
            _context.SaveChanges();
            return new RealEstateDTO(realEstate);
        }

        private async Task<RealEstate?> findRealEstate(long realEstateId) {
            return await _context.RealEstates.FindAsync(realEstateId);
        }
    }
}