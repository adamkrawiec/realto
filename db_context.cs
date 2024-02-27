
using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

public class AppDBContext : DbContext {
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<RealEstate> RealEstates { get; set; }
}