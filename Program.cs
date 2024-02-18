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

app.MapControllerRoute(
    name: "welcome",
    pattern: "{controller=Hello}/{action=Index}/{id?}"
);
app.Run();
