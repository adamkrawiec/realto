using RealEstates.Models;

namespace RealEstates {
  public class EstateUnitRouter {
    private WebApplication App;
    private EstateUnitService estateUnitService = new EstateUnitService();

    public EstateUnitRouter(WebApplication app) {
      App = app;
    }

    public void AddProgram() {
      App.MapGet("/estate_units/{id}/", (int id) => {
          EstateUnit? estateUnit = estateUnitService.FindEstateUnit(id);

          if (estateUnit is null) return Results.NotFound();

          return Results.Ok(estateUnitService.PresentEstateUnit(estateUnit));
      });

    }
  }
}