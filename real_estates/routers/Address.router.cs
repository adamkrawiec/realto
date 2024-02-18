using DB;

namespace RealEstates {
  public class AddressRouter {
    private WebApplication App;
    private DBClient db = DBClient.GetInstance();

    public AddressRouter(WebApplication app) {
      App = app;
    }

    public void AddProgram() {
      App.MapGet("/streets", () => {
        return db.Streets;
      });

      App.MapGet("/cities", () => {
          return db.Cities;
      });
    }
  }
}