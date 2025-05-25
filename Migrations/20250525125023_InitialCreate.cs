using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace training.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dara_departments",
                columns: table => new
                {
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dara_departments", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "dara_employees",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    hire_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: true),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    create_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dara_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_dara_employees_dara_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "dara_departments",
                        principalColumn: "department_id");
                });

            migrationBuilder.InsertData(
                table: "dara_departments",
                columns: new[] { "department_id", "name" },
                values: new object[,]
                {
                    { new Guid("1e21aa4d-35db-43c0-a2e0-d5e155582cb5"), "IT Support" },
                    { new Guid("32c61738-f1e5-4b8e-9c42-5cb78a16012a"), "Quality Assurance" },
                    { new Guid("47cc9f6a-6a0f-4c12-9b96-82a1c57f9b71"), "DevOps" },
                    { new Guid("64b63eec-bb98-4121-bdf8-940ee1de9150"), "Sales and Marketing" },
                    { new Guid("6e420738-b23c-41c4-82f3-fd6d0a6a5f58"), "Product Management" },
                    { new Guid("7b7f2a1b-dc3e-4c7c-b514-92fcf015cb57"), "Software Development" },
                    { new Guid("9400ed2a-2ae6-453f-9130-14e46e10553a"), "Finance and Accounting" },
                    { new Guid("adf08c7e-7c09-4ef3-bb9c-f4993a2b41aa"), "UI/UX Design" },
                    { new Guid("d4e5c630-ecaa-4f6b-a8c7-1d47c7a5f91a"), "Human Resources" },
                    { new Guid("ec7e2c46-166a-43a4-8c03-1b206a35f159"), "Cybersecurity" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_dara_employees_department_id",
                table: "dara_employees",
                column: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dara_employees");

            migrationBuilder.DropTable(
                name: "dara_departments");
        }
    }
}
