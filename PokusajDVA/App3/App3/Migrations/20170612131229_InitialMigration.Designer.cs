using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using TutorFinderApp.Models;

namespace TutorFinderAppMigrations
{
    [ContextType(typeof(TutorFinderDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20170612131229_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("TutorFinderApp.Models.Instruktor", b =>
                {
                    b.Property<int>("InstruktorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("Lokacija");

                    b.Property<double>("Ocjena");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.Property<byte[]>("slika")
                        .Annotation("Relational:ColumnType", "image");

                    b.Key("InstruktorId");
                });

            builder.Entity("TutorFinderApp.Models.Klijent", b =>
                {
                    b.Property<int>("KlijentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("Lokacija");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.Key("KlijentId");
                });

            builder.Entity("TutorFinderApp.Models.Predmet", b =>
                {
                    b.Property<int>("PredmetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImePredmeta");

                    b.Key("PredmetId");
                });

            builder.Entity("TutorFinderApp.Models.Termin", b =>
                {
                    b.Property<int>("TerminId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstruktorId");

                    b.Property<int>("KlijentId");

                    b.Property<int?>("PredmetPredmetId");

                    b.Property<byte[]>("QrKod")
                        .Annotation("Relational:ColumnType", "image");

                    b.Property<DateTime>("VrijemeOdrzavanja");

                    b.Key("TerminId");
                });

            builder.Entity("TutorFinderApp.Models.Termin", b =>
                {
                    b.Reference("TutorFinderApp.Models.Instruktor")
                        .InverseCollection()
                        .ForeignKey("InstruktorId");

                    b.Reference("TutorFinderApp.Models.Klijent")
                        .InverseCollection()
                        .ForeignKey("KlijentId");

                    b.Reference("TutorFinderApp.Models.Predmet")
                        .InverseCollection()
                        .ForeignKey("PredmetPredmetId");
                });
        }
    }
}
