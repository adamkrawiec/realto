using Microsoft.AspNetCore.Mvc;

namespace RealEstates.Controllers
{
    public class EstateUnitController : Controller
    {
        private readonly EstateUnitService _estateUnitService = new EstateUnitService();
    
        [HttpGet("/estate_units/{id}")]
        public IActionResult Show(int id)
        {
            EstateUnitDTO? estateUnit = _estateUnitService.PresentEstateUnit(id);

            if (estateUnit is null) return NotFound();

          return Ok(estateUnit);
        }
    }
}