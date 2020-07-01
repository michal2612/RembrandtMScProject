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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Walking = table.Column<bool>(nullable: true),
                    Jogging = table.Column<bool>(nullable: true),
                    Biking = table.Column<bool>(nullable: true),
                    Relaxing = table.Column<bool>(nullable: true),
                    Socialising = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    ContributorPrimaryKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Contributors", x => x.ContributorPrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GpsAccuracy = table.Column<int>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeasuredLocationId = table.Column<int>(nullable: true),
                    ActualLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parks_Locations_ActualLocationId",
                        column: x => x.ActualLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parks_Locations_MeasuredLocationId",
                        column: x => x.MeasuredLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkipReason = table.Column<string>(nullable: true),
                    TimeSubmitted = table.Column<DateTime>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    PhotoAddress = table.Column<string>(nullable: true),
                    PhotoTowardsPointCompass = table.Column<int>(nullable: false),
                    AttributesId = table.Column<int>(nullable: true),
                    ParkId = table.Column<int>(nullable: true),
                    ActivitiesId = table.Column<int>(nullable: true),
                    ContributorPrimaryKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Attributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Contributors_ContributorPrimaryKey",
                        column: x => x.ContributorPrimaryKey,
                        principalTable: "Contributors",
                        principalColumn: "ContributorPrimaryKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Parks_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parks",
                        principalColumn: "Id",
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
                name: "IX_Observations_ContributorPrimaryKey",
                table: "Observations",
                column: "ContributorPrimaryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_ParkId",
                table: "Observations",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_ActualLocationId",
                table: "Parks",
                column: "ActualLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_MeasuredLocationId",
                table: "Parks",
                column: "MeasuredLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
