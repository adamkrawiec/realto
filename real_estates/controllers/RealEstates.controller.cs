using Microsoft.AspNetCore.Mvc;

namespace RealEstates.Controllers
{
    [Route("/real_estates")]
    public class RealEstatesController : Controller {
        private readonly AppDBContext _context;

        private readonly RealEstateService _realEstateService;
        
        public RealEstatesController(AppDBContext context) {
            _context = context;
            _realEstateService = new RealEstateService(_context);
        }

        [HttpPost]
        public IActionResult create(string streetName, string cityName, float area, int number) {
            RealEstateDTO? realEstate = _realEstateService.AddRealEstate(streetName, cityName, area, number);
            if (realEstate is null) return BadRequest();

            return Ok(realEstate);
        }


        [HttpGet]
        public IActionResult Index(string? cityName, string? streetName)
        {
            List<RealEstateDTO> realEstates = _realEstateService.GetAllRealEstates(cityName, streetName);
            realEstates.ForEach(realEstate =>
                realEstate.ShowPath = Url.Action("Show", "RealEstates", new { id = realEstate.Id })
            );
            
            return Ok(realEstates);
        }

        [HttpGet("/real_estates/{id}")]
        public async Task<IActionResult> Show(long id)
        {
            RealEstateDTO? realEstate = await _realEstateService.PresentRealEstate(id);

            if (realEstate is null) return NotFound();

            // realEstate.EstateUnits.ForEach(estateUnit =>
            //     estateUnit.ShowPath = Url.Action("Show", "EstateUnit", new { id = estateUnit.Id })
            // );
            return Ok(realEstate);
        }
    }
}