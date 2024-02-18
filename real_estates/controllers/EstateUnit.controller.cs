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
            estateUnit.TenantsPath = Url.Action("ShowTenants", "EstateUnit", new { id = estateUnit.Id });
            if (estateUnit is null) return NotFound();

            return Ok(estateUnit);
        }

        [HttpGet("/estate_units/{id}/tenants", Name = "EstateUnitTenants")]
        public IActionResult ShowTenants(int id)
        {
            return Ok(_estateUnitService.GetTenants(id));
        }
    }
}