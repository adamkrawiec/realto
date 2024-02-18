using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace RealEstates.Controllers;

public class HomeController : Controller
{
    public string Index()
    {
      return "Realto Home";
    }
}