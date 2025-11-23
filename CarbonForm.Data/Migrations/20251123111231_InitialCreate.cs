using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonForm.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStage = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consumptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClothingExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CosmeticExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonalCareExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElectronicsExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocalProductPreferenceScore = table.Column<int>(type: "int", nullable: false),
                    EatingOutFrequency = table.Column<int>(type: "int", nullable: false),
                    MeatConsumptionKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VeggieConsumptionKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumptions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeEnergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NaturalGasBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NaturalGasM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaterBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaterM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElectricityBillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElectricityKwh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LpgM3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasAirConditioner = table.Column<bool>(type: "bit", nullable: false),
                    AirConditionerType = table.Column<int>(type: "int", nullable: false),
                    AirConditionerUseDays = table.Column<int>(type: "int", nullable: false),
                    SolidWasteKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarWashCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeEnergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeEnergies_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transportations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommuteType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommuteDistanceKm = table.Column<int>(type: "int", nullable: false),
                    FlightDomesticCount = table.Column<int>(type: "int", nullable: false),
                    FlightDomesticKm = table.Column<int>(type: "int", nullable: false),
                    FlightInternationalCount = table.Column<int>(type: "int", nullable: false),
                    FlightInternationalKm = table.Column<int>(type: "int", nullable: false),
                    CarTravelCount = table.Column<int>(type: "int", nullable: false),
                    CarTravelKm = table.Column<int>(type: "int", nullable: false),
                    PublicTransportTravelCount = table.Column<int>(type: "int", nullable: false),
                    PublicTransportTravelKm = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportations_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationLevel = table.Column<int>(type: "int", nullable: false),
                    IsNgoMember = table.Column<bool>(type: "bit", nullable: false),
                    HasAttendedGreenFair = table.Column<bool>(type: "bit", nullable: false),
                    GreenFairName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoRecycle = table.Column<bool>(type: "bit", nullable: false),
                    DoCompost = table.Column<bool>(type: "bit", nullable: false),
                    HasPlantedTree = table.Column<bool>(type: "bit", nullable: false),
                    TreeCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfos_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_SurveyId",
                table: "Consumptions",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeEnergies_SurveyId",
                table: "HomeEnergies",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_SurveyId",
                table: "Transportations",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_SurveyId",
                table: "UserInfos",
                column: "SurveyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumptions");

            migrationBuilder.DropTable(
                name: "HomeEnergies");

            migrationBuilder.DropTable(
                name: "Transportations");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
