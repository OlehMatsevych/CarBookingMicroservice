using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarBooking.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCharacteristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VIN = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    Engine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCharacteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarMakers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarMakers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    MakerId = table.Column<Guid>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: false),
                    CharacteristicsId = table.Column<Guid>(nullable: true),
                    CarMakerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarMakers_CarMakerId",
                        column: x => x.CarMakerId,
                        principalTable: "CarMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarCharacteristics_CharacteristicsId",
                        column: x => x.CharacteristicsId,
                        principalTable: "CarCharacteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarMakers_LocationId",
                table: "CarMakers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarMakerId",
                table: "Cars",
                column: "CarMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CharacteristicsId",
                table: "Cars",
                column: "CharacteristicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ProviderId",
                table: "Cars",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_LocationId",
                table: "Providers",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarMakers");

            migrationBuilder.DropTable(
                name: "CarCharacteristics");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
