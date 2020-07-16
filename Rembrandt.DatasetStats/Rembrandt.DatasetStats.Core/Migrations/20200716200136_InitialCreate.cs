using Microsoft.EntityFrameworkCore.Migrations;

namespace Rembrandt.DatasetStats.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivitiesStat",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Walking = table.Column<bool>(nullable: false),
                    Jogging = table.Column<bool>(nullable: false),
                    Biking = table.Column<bool>(nullable: false),
                    Relaxing = table.Column<bool>(nullable: false),
                    Socialising = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesStat", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "AttributesStat",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lively = table.Column<float>(nullable: false),
                    Relaxing = table.Column<float>(nullable: false),
                    Tranquil = table.Column<float>(nullable: false),
                    Noisy = table.Column<float>(nullable: false),
                    Crowded = table.Column<float>(nullable: false),
                    Safe = table.Column<float>(nullable: false),
                    Beauty = table.Column<float>(nullable: false),
                    Biodiversity = table.Column<float>(nullable: false),
                    Trees = table.Column<float>(nullable: false),
                    Shrubs = table.Column<float>(nullable: false),
                    Lawns = table.Column<float>(nullable: false),
                    Flowers = table.Column<float>(nullable: false),
                    Natveg = table.Column<float>(nullable: false),
                    Benches = table.Column<float>(nullable: false),
                    Play = table.Column<float>(nullable: false),
                    Sports = table.Column<float>(nullable: false),
                    Garbage = table.Column<float>(nullable: false),
                    Veget = table.Column<float>(nullable: false),
                    Paths = table.Column<float>(nullable: false),
                    Facilities = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributesStat", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "ObservationsStat",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: false),
                    AttributesPrimaryKey = table.Column<int>(nullable: true),
                    ActivitiesPrimaryKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservationsStat", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_ObservationsStat_ActivitiesStat_ActivitiesPrimaryKey",
                        column: x => x.ActivitiesPrimaryKey,
                        principalTable: "ActivitiesStat",
                        principalColumn: "PrimaryKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ObservationsStat_AttributesStat_AttributesPrimaryKey",
                        column: x => x.AttributesPrimaryKey,
                        principalTable: "AttributesStat",
                        principalColumn: "PrimaryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotoAdresses",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    ObservationStatPrimaryKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAdresses", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_PhotoAdresses_ObservationsStat_ObservationStatPrimaryKey",
                        column: x => x.ObservationStatPrimaryKey,
                        principalTable: "ObservationsStat",
                        principalColumn: "PrimaryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkipReasons",
                columns: table => new
                {
                    SkipReasonsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(nullable: true),
                    ReasonCount = table.Column<int>(nullable: false),
                    ObservationStatPrimaryKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkipReasons", x => x.SkipReasonsId);
                    table.ForeignKey(
                        name: "FK_SkipReasons_ObservationsStat_ObservationStatPrimaryKey",
                        column: x => x.ObservationStatPrimaryKey,
                        principalTable: "ObservationsStat",
                        principalColumn: "PrimaryKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObservationsStat_ActivitiesPrimaryKey",
                table: "ObservationsStat",
                column: "ActivitiesPrimaryKey");

            migrationBuilder.CreateIndex(
                name: "IX_ObservationsStat_AttributesPrimaryKey",
                table: "ObservationsStat",
                column: "AttributesPrimaryKey");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAdresses_ObservationStatPrimaryKey",
                table: "PhotoAdresses",
                column: "ObservationStatPrimaryKey");

            migrationBuilder.CreateIndex(
                name: "IX_SkipReasons_ObservationStatPrimaryKey",
                table: "SkipReasons",
                column: "ObservationStatPrimaryKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoAdresses");

            migrationBuilder.DropTable(
                name: "SkipReasons");

            migrationBuilder.DropTable(
                name: "ObservationsStat");

            migrationBuilder.DropTable(
                name: "ActivitiesStat");

            migrationBuilder.DropTable(
                name: "AttributesStat");
        }
    }
}
