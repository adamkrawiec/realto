using RealEstates;
using Microsoft.EntityFrameworkCore;
using DB;

var builder = WebApplication.CreateBuilder();
builder.Services.AddAntiforgery();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"))
);

var app = builder.Build();
app.UseAntiforgery();
app.MapControllers();

var scope = app.Services.CreateScope();
AppDBContext dbcontext = scope.ServiceProvider.GetService<AppDBContext>();
DBClient dbClient = new DBClient(dbcontext);
dbClient.loadData();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hello}/{action=Index}/{id?}"
);

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
