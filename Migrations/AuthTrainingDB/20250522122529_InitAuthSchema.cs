using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace training.Migrations.AuthTrainingDB
{
    /// <inheritdoc />
    public partial class InitAuthSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b9a8725-1e43-4c1e-a6d1-cdf15e3cb6cc", "3b9a8725-1e43-4c1e-a6d1-cdf15e3cb6cc", "Manager", "MANAGER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: "3b9a8725-1e43-4c1e-a6d1-cdf15e3cb6cc");
        }
    }
}
