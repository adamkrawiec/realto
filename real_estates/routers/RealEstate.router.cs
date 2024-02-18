using RealEstates.Models;

namespace RealEstates {
  public class RealEstateRouter {
    private WebApplication App;
    private RealEstateService realEstateService = new RealEstateService();

    public RealEstateRouter(WebApplication app) {
      App = app;
    }

    public void AddProgram() {
      App.MapGet("/real_estates", () => {
          return Results.Ok(realEstateService.GetAllRealEstates());
      });

      App.MapPost("/real_estates", realEstateService.AddRealEstate).DisableAntiforgery();
      App.MapGet("/real_estates/{id}", (int id) => {
          RealEstate? realEstate = realEstateService.FindRealEstate(id);

          if (realEstate is null) return Results.NotFound();

          return Results.Ok(realEstateService.PresentRealEstate(realEstate));
      });
    }
  }
}