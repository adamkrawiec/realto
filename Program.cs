using Microsoft.AspNetCore.Mvc;
using RealEstates;
using DB;

DBClient db = DBClient.GetInstance();
db.loadData();

RealEstateService realEstateService = new RealEstateService();

var builder = WebApplication.CreateBuilder();
builder.Services.AddAntiforgery();
builder.Services.AddControllers();

var app = builder.Build();
app.UseAntiforgery();


AddressRouter addressRouter = new AddressRouter(app);
EstateUnitRouter estateUnitRouter = new EstateUnitRouter(app);
RealEstateRouter realEstateRouter = new RealEstateRouter(app);

addressRouter.AddProgram();
estateUnitRouter.AddProgram();
realEstateRouter.AddProgram();

app.MapControllerRoute(
    name: "welcome",
    pattern: "{controller=Hello}/{action=Index}/{id?}"
);
app.Run();
