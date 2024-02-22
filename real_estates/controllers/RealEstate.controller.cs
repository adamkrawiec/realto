using Microsoft.AspNetCore.Mvc;

namespace RealEstates.Controllers
{
    [Route("/real_estates")]
    public class RealEstateController : Controller {

        private readonly RealEstateService _realEstateService = new RealEstateService();
        
        [HttpPost]
        public IActionResult create(string streetName, string cityName, float area, int number) {
            RealEstateDTO? realEstate = _realEstateService.AddRealEstate(streetName, cityName, area, number);
            if (realEstate is null) return BadRequest();

            return Ok(realEstate);
        }

        [HttpGet]
        public IActionResult Index(string? city, string? street, int? number)
        {
            List<RealEstateDTO> realEstates = _realEstateService.GetAllRealEstates(city, street, number);
            realEstates.ForEach(realEstate =>
                realEstate.ShowPath = Url.Action("Show", "RealEstate", new { id = realEstate.Id })
            );
            
            return Ok(realEstates);
        }

        [HttpGet("/{id}")]
        public IActionResult Show(int id)
        {
            RealEstateDTO? realEstate = _realEstateService.PresentRealEstate(id);

            if (realEstate is null) return NotFound();

            realEstate.EstateUnits.ForEach(estateUnit =>
                estateUnit.ShowPath = Url.Action("Show", "EstateUnit", new { id = estateUnit.Id })
            );
            return Ok(realEstate);
        }
    }
}