using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorFinderApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruktori",
                columns: table => new
                {
                    InstruktorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ocjena = table.Column<double>(nullable: false),
                    slika = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruktori", x => x.InstruktorId);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    KlijentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.KlijentId);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    PredmetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImePredmeta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.PredmetId);
                });

            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    TerminId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InstruktorId = table.Column<int>(nullable: true),
                    KlijentId = table.Column<int>(nullable: true),
                    PredmetId = table.Column<int>(nullable: false),
                    QrKod = table.Column<byte[]>(type: "image", nullable: false),
                    VrijemeOdrzavanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termini", x => x.TerminId);
                    table.ForeignKey(
                        name: "FK_Termini_Instruktori_InstruktorId",
                        column: x => x.InstruktorId,
                        principalTable: "Instruktori",
                        principalColumn: "InstruktorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termini_Klijenti_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijenti",
                        principalColumn: "KlijentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termini_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "PredmetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Termini_InstruktorId",
                table: "Termini",
                column: "InstruktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_KlijentId",
                table: "Termini",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_PredmetId",
                table: "Termini",
                column: "PredmetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Termini");

            migrationBuilder.DropTable(
                name: "Instruktori");

            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "Predmet");
        }
    }
}
