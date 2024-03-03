using Microsoft.AspNetCore.Mvc;
using DB;

namespace RealEstates.Controllers
{
    public class AddressController : Controller
    {
        private DBClient db = new DBClient(null);

        [HttpGet("/streets")]
        public IActionResult Streets()
        {
            return Ok(db.Streets);
        }

        [HttpGet("/cities")]
        public IActionResult Cities()
        {
            return Ok(db.Cities);
        }
    }
}