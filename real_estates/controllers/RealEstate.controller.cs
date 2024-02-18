using Microsoft.AspNetCore.Mvc;

namespace RealEstates.Controllers
{
    public class RealEstateController : Controller {

        private readonly RealEstateService _realEstateService = new RealEstateService();
        
        [HttpPost("/real_estates")]
        public IActionResult create(string streetName, string cityName, float area, int number) {
            RealEstateDTO? realEstate = _realEstateService.AddRealEstate(streetName, cityName, area, number);
            if (realEstate is null) return BadRequest();

            return Ok(realEstate);
        }

        [HttpGet("/real_estates")]
        public IActionResult Index()
        {
            List<RealEstateDTO> realEstates = _realEstateService.GetAllRealEstates();
            realEstates.ForEach(realEstate =>
                realEstate.ShowPath = Url.Action("Show", "RealEstate", new { id = realEstate.Id })
            );
            
            return Ok(realEstates);
        }

        [HttpGet("/real_estates/{id}")]
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