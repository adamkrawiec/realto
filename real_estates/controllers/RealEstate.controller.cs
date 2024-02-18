using Microsoft.AspNetCore.Mvc;
using RealEstates.Models;

namespace RealEstates.Controllers
{
    public class RealEstateController : Controller {

        private readonly RealEstateService _realEstateService = new RealEstateService();
        
        [HttpPost("/real_estates")]
        public IActionResult create(string streetName, string cityName, float area, int number) {
            return Ok(_realEstateService.AddRealEstate(streetName, cityName, area, number));
        }

        [HttpGet("/real_estates")]
        public IActionResult Index()
        {
            return Ok(_realEstateService.GetAllRealEstates());
        }

        [HttpGet("/real_estates/{id}")]
        public IActionResult Show(int id)
        {
            RealEstate? realEstate = _realEstateService.FindRealEstate(id);

            if (realEstate is null) return NotFound();

            return Ok(_realEstateService.PresentRealEstate(realEstate));
        }
    }
}