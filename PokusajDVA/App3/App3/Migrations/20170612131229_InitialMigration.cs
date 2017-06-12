using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace TutorFinderAppMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Instruktor",
                columns: table => new
                {
                    InstruktorId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Lokacija = table.Column(type: "TEXT", nullable: true),
                    Ocjena = table.Column(type: "REAL", nullable: false),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true),
                    slika = table.Column(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruktor", x => x.InstruktorId);
                });
            migration.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Lokacija = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentId);
                });
            migration.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    PredmetId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    ImePredmeta = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.PredmetId);
                });
            migration.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    TerminId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    InstruktorId = table.Column(type: "INTEGER", nullable: false),
                    KlijentId = table.Column(type: "INTEGER", nullable: false),
                    PredmetPredmetId = table.Column(type: "INTEGER", nullable: true),
                    QrKod = table.Column(type: "image", nullable: true),
                    VrijemeOdrzavanja = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.TerminId);
                    table.ForeignKey(
                        name: "FK_Termin_Instruktor_InstruktorId",
                        columns: x => x.InstruktorId,
                        referencedTable: "Instruktor",
                        referencedColumn: "InstruktorId");
                    table.ForeignKey(
                        name: "FK_Termin_Klijent_KlijentId",
                        columns: x => x.KlijentId,
                        referencedTable: "Klijent",
                        referencedColumn: "KlijentId");
                    table.ForeignKey(
                        name: "FK_Termin_Predmet_PredmetPredmetId",
                        columns: x => x.PredmetPredmetId,
                        referencedTable: "Predmet",
                        referencedColumn: "PredmetId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Termin");
            migration.DropTable("Instruktor");
            migration.DropTable("Klijent");
            migration.DropTable("Predmet");
        }
    }
}
