using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LmycAPI.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUserRoles_UserId",
            //    table: "AspNetUserRoles");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressCountry",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressProvince",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreet",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SailingExperience",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoatName = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    FeetInInches = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Picture = table.Column<string>(nullable: false),
                    RecordCreationDate = table.Column<DateTime>(nullable: false),
                    Year = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.BoatId);
                    table.ForeignKey(
                        name: "FK_Boats_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoatId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    ReservedBoat = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boats_Id",
                table: "Boats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BoatId",
                table: "Reservations",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations",
                column: "CreatedBy");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //    table: "AspNetUserTokens",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressProvince",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressStreet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SailingExperience",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
