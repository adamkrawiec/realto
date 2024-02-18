using Microsoft.AspNetCore.Mvc;

namespace RealEstates.Controllers;

public class HomeController : Controller
{
    public string Index()
    {
      return "Realto Home";
    }
}