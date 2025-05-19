using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderingSystem.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO StatusLookups (Name, Description) VALUES ('Pending', '')");
            migrationBuilder.Sql("INSERT INTO StatusLookups (Name, Description) VALUES ('Processing', '')");
            migrationBuilder.Sql("INSERT INTO StatusLookups (Name, Description) VALUES ('Completed', '')");
            migrationBuilder.Sql("INSERT INTO StatusLookups (Name, Description) VALUES ('Cancelled', '')");
            migrationBuilder.Sql("INSERT INTO StatusLookups (Name, Description) VALUES ('Refunded', '')");
            migrationBuilder.Sql("INSERT INTO StatusLookups (Name, Description) VALUES ('Failed', '')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
