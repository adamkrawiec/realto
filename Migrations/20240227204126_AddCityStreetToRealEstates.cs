using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace realto.Migrations
{
    /// <inheritdoc />
    public partial class AddCityStreetToRealEstates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("City", "real_estates", "varchar");
            migrationBuilder.AddColumn<string>("Street", "real_estates", "varchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("City", "real_estates");
            migrationBuilder.DropColumn("Street", "real_estates");
        }
    }
}
