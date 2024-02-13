namespace RealEstates {
  public class RealEstateRouter {
    private WebApplication App;
    private DB db = DB.GetInstance();
    private RealEstateService realEstateService = new RealEstateService();

    public RealEstateRouter(WebApplication app) {
      App = app;
    }

    public void AddProgram() {
      App.MapGet("/real_estates", () => {
          return db.RealEstates;
      });

      App.MapPost("/real_estates", realEstateService.AddRealEstate).DisableAntiforgery();
      App.MapGet("/real_estates/{id}", (int id) => {
          RealEstate? realEstate = db.RealEstates.Find(realEstate => realEstate.Id == id);

          if (realEstate is null) return Results.NotFound();

          return Results.Ok(realEstateService.presentRealEstate(realEstate));
      });

      App.MapGet("/estate_units/{id}/", (int id) => {
          EstateUnit? estateUnit = db.EstateUnits.Find(estateUnit => estateUnit.Id == id);

          if (estateUnit is null) return Results.NotFound();

          return Results.Ok(realEstateService.presentEstateUnit(estateUnit));
      });

    }
  }
}