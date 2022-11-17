using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_SYSTEM.Migrations
{
    public partial class anr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleType",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnic",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ANRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateofActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofEnclosure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProtectionMechanism = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentMechanism = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeySpecies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRegeneration = table.Column<int>(type: "int", nullable: false),
                    AreaofEnclosure = table.Column<int>(type: "int", nullable: false),
                    AreaUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRegeneration = table.Column<int>(type: "int", nullable: false),
                    MajorInterventions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedSuccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedDamage = table.Column<int>(type: "int", nullable: false),
                    EstimatedDamageAcreage = table.Column<int>(type: "int", nullable: false),
                    DamageReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDCSolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongTermMeasures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanForSbstitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neghaban = table.Column<int>(type: "int", nullable: false),
                    SkilledLabour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANRs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANRs");

            migrationBuilder.AlterColumn<string>(
                name: "RoleType",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cnic",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DepName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
