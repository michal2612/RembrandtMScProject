using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rembrandt.Dataset.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Walking = table.Column<bool>(nullable: true),
                    Jogging = table.Column<bool>(nullable: true),
                    Biking = table.Column<bool>(nullable: true),
                    Relaxing = table.Column<bool>(nullable: true),
                    Socialising = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivitiesId);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    AttributesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lively = table.Column<int>(nullable: false),
                    Relaxing = table.Column<int>(nullable: false),
                    Tranquil = table.Column<int>(nullable: false),
                    Noisy = table.Column<int>(nullable: false),
                    Crowded = table.Column<int>(nullable: false),
                    Safe = table.Column<int>(nullable: false),
                    Beauty = table.Column<int>(nullable: false),
                    Biodiversity = table.Column<int>(nullable: false),
                    Trees = table.Column<int>(nullable: false),
                    Shrubs = table.Column<int>(nullable: false),
                    Lawns = table.Column<int>(nullable: false),
                    Flowers = table.Column<int>(nullable: false),
                    Natveg = table.Column<int>(nullable: false),
                    Benches = table.Column<int>(nullable: false),
                    Play = table.Column<int>(nullable: false),
                    Sports = table.Column<int>(nullable: false),
                    Garbage = table.Column<int>(nullable: false),
                    Veget = table.Column<int>(nullable: false),
                    Paths = table.Column<int>(nullable: false),
                    Facilities = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.AttributesId);
                });

            migrationBuilder.CreateTable(
                name: "Contributor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    DutchNationality = table.Column<bool>(nullable: true),
                    Education = table.Column<int>(nullable: true),
                    VisitDaily = table.Column<bool>(nullable: true),
                    VisitFreq = table.Column<int>(nullable: true),
                    VisitAlone = table.Column<bool>(nullable: true),
                    VisitOtherParks = table.Column<int>(nullable: true),
                    MoreInvolved = table.Column<bool>(nullable: true),
                    NatureOriented = table.Column<int>(nullable: true),
                    WithChildren = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GpsAccuracy = table.Column<int>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeasuredLocationLocationId = table.Column<int>(nullable: true),
                    ActualLocationLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.ParkId);
                    table.ForeignKey(
                        name: "FK_Park_Location_ActualLocationLocationId",
                        column: x => x.ActualLocationLocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Park_Location_MeasuredLocationLocationId",
                        column: x => x.MeasuredLocationLocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    ObservationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkipReason = table.Column<string>(nullable: true),
                    TimeSubmitted = table.Column<DateTime>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    PhotoAddress = table.Column<string>(nullable: true),
                    PhotoTowardsPointCompass = table.Column<int>(nullable: false),
                    AttributesId = table.Column<int>(nullable: true),
                    ParkId = table.Column<int>(nullable: true),
                    ActivitiesId = table.Column<int>(nullable: true),
                    ContributorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.ObservationId);
                    table.ForeignKey(
                        name: "FK_Observations_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "ActivitiesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Attributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "Attributes",
                        principalColumn: "AttributesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Contributor_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Park_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Park",
                        principalColumn: "ParkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observations_ActivitiesId",
                table: "Observations",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_AttributesId",
                table: "Observations",
                column: "AttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_ContributorId",
                table: "Observations",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_ParkId",
                table: "Observations",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Park_ActualLocationLocationId",
                table: "Park",
                column: "ActualLocationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Park_MeasuredLocationLocationId",
                table: "Park",
                column: "MeasuredLocationLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Contributor");

            migrationBuilder.DropTable(
                name: "Park");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
