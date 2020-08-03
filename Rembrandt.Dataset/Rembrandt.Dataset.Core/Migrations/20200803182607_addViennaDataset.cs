using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rembrandt.Dataset.Core.Migrations
{
    public partial class addViennaDataset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ViennaAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeelingWell = table.Column<int>(nullable: true),
                    Attractive = table.Column<int>(nullable: true),
                    Clean = table.Column<int>(nullable: true),
                    Facilities = table.Column<int>(nullable: true),
                    Quiet = table.Column<int>(nullable: true),
                    Secure = table.Column<int>(nullable: true),
                    AnimalsNature = table.Column<int>(nullable: true),
                    Playing = table.Column<int>(nullable: true),
                    Romance = table.Column<int>(nullable: true),
                    ExerciseSport = table.Column<int>(nullable: true),
                    SittingLayingDown = table.Column<int>(nullable: true),
                    Winter = table.Column<int>(nullable: true),
                    Creativity = table.Column<int>(nullable: true),
                    Summer = table.Column<int>(nullable: true),
                    CoolingGreen = table.Column<bool>(nullable: true),
                    CoolingWind = table.Column<bool>(nullable: true),
                    DrikingWater = table.Column<bool>(nullable: true),
                    Shadow = table.Column<bool>(nullable: true),
                    Water = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViennaAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViennaSubAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlpineSkiing = table.Column<bool>(nullable: true),
                    Alternativ = table.Column<bool>(nullable: true),
                    AnimalBirdObservation = table.Column<bool>(nullable: true),
                    FeedingPettingAnimals = table.Column<bool>(nullable: true),
                    ApparatusGymnastics = table.Column<bool>(nullable: true),
                    Ballgames = table.Column<bool>(nullable: true),
                    BallgamesThrowingBalls = table.Column<bool>(nullable: true),
                    BathingSwimming = table.Column<bool>(nullable: true),
                    BoardGames = table.Column<bool>(nullable: true),
                    Breastfeed = table.Column<bool>(nullable: true),
                    ClimbingBouldering = table.Column<bool>(nullable: true),
                    Cycling = table.Column<bool>(nullable: true),
                    Dancing = table.Column<bool>(nullable: true),
                    TakingTheDogOffTheLeash = table.Column<bool>(nullable: true),
                    LettingTheDogSwim = table.Column<bool>(nullable: true),
                    TakingTheDogForAWalk = table.Column<bool>(nullable: true),
                    EnjoyingNature = table.Column<bool>(nullable: true),
                    ThrowingFrisbee = table.Column<bool>(nullable: true),
                    GoingForAWalk = table.Column<bool>(nullable: true),
                    Hiking = table.Column<bool>(nullable: true),
                    HoresebackRiding = table.Column<bool>(nullable: true),
                    Iceskating = table.Column<bool>(nullable: true),
                    Jogging = table.Column<bool>(nullable: true),
                    JuggingHulaHoop = table.Column<bool>(nullable: true),
                    LayingDownProtected = table.Column<bool>(nullable: true),
                    NordicSkiing = table.Column<bool>(nullable: true),
                    NordicWalking = table.Column<bool>(nullable: true),
                    Paddleboar = table.Column<bool>(nullable: true),
                    PaintingDrawing = table.Column<bool>(nullable: true),
                    Parcouring = table.Column<bool>(nullable: true),
                    Picknick = table.Column<bool>(nullable: true),
                    Playing = table.Column<bool>(nullable: true),
                    PlayingAnInstrument = table.Column<bool>(nullable: true),
                    PlayingInTheSnow = table.Column<bool>(nullable: true),
                    PlayingWithWater = table.Column<bool>(nullable: true),
                    Proposing = table.Column<bool>(nullable: true),
                    RidingABoat = table.Column<bool>(nullable: true),
                    Romance = table.Column<bool>(nullable: true),
                    PlayingWithSand = table.Column<bool>(nullable: true),
                    RidingAScooter = table.Column<bool>(nullable: true),
                    Selfie = table.Column<bool>(nullable: true),
                    ConsumptionNecessary = table.Column<bool>(nullable: true),
                    SittingOnTheGround = table.Column<bool>(nullable: true),
                    Skating = table.Column<bool>(nullable: true),
                    Slacklinin = table.Column<bool>(nullable: true),
                    Tobogganing = table.Column<bool>(nullable: true),
                    Snowshoein = table.Column<bool>(nullable: true),
                    Spraying = table.Column<bool>(nullable: true),
                    StarObservation = table.Column<bool>(nullable: true),
                    EnjoyingTheSun = table.Column<bool>(nullable: true),
                    TableTennis = table.Column<bool>(nullable: true),
                    TakingPictures = table.Column<bool>(nullable: true),
                    ThrowingObjects = table.Column<bool>(nullable: true),
                    ObservingTrainspotting = table.Column<bool>(nullable: true),
                    UrbanGardening = table.Column<bool>(nullable: true),
                    WorkingStudying = table.Column<bool>(nullable: true),
                    Yoga = table.Column<bool>(nullable: true),
                    Youth = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViennaSubAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViennaObservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: true),
                    TimeSubmitted = table.Column<DateTime>(nullable: false),
                    PhotoPointUrl = table.Column<string>(nullable: true),
                    PhotoNorthUrl = table.Column<string>(nullable: true),
                    PhotoEastUrl = table.Column<string>(nullable: true),
                    PhotoSouthUrl = table.Column<string>(nullable: true),
                    PhotoWestUrl = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    AttributesId = table.Column<int>(nullable: true),
                    SubAttributesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViennaObservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViennaObservations_ViennaAttributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "ViennaAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViennaObservations_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViennaObservations_ViennaSubAttributes_SubAttributesId",
                        column: x => x.SubAttributesId,
                        principalTable: "ViennaSubAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViennaObservations_AttributesId",
                table: "ViennaObservations",
                column: "AttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_ViennaObservations_LocationId",
                table: "ViennaObservations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ViennaObservations_SubAttributesId",
                table: "ViennaObservations",
                column: "SubAttributesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViennaObservations");

            migrationBuilder.DropTable(
                name: "ViennaAttributes");

            migrationBuilder.DropTable(
                name: "ViennaSubAttributes");
        }
    }
}
