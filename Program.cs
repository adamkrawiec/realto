using Microsoft.AspNetCore.Mvc;
using RealEstates;

DB db = DB.GetInstance();
db.loadData();

RealEstateService realEstateService = new RealEstateService();

var builder = WebApplication.CreateBuilder();
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseAntiforgery();

app.MapGet("/streets", () => {
    return db.Streets;
});

app.MapGet("/cities", () => {
    return db.Cities;
});

RealEstateRouter realEstateRouter = new RealEstateRouter(app);
realEstateRouter.AddProgram();

app.Run();
