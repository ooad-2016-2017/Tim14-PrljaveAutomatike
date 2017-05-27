using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TutorFinderApp.Models;

namespace TutorFinderApp.Migrations
{
    [DbContext(typeof(TutorFinderDbContext))]
    [Migration("20170527013359_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("TutorFinderApp.Models.Instruktor", b =>
                {
                    b.Property<int>("InstruktorId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Ocjena");

                    b.Property<byte[]>("slika")
                        .HasColumnType("image");

                    b.HasKey("InstruktorId");

                    b.ToTable("Instruktori");
                });

            modelBuilder.Entity("TutorFinderApp.Models.Klijent", b =>
                {
                    b.Property<int>("KlijentId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("KlijentId");

                    b.ToTable("Klijenti");
                });

            modelBuilder.Entity("TutorFinderApp.Models.Predmet", b =>
                {
                    b.Property<int>("PredmetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImePredmeta");

                    b.HasKey("PredmetId");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("TutorFinderApp.Models.Termin", b =>
                {
                    b.Property<int>("TerminId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InstruktorId");

                    b.Property<int?>("KlijentId");

                    b.Property<int>("PredmetId");

                    b.Property<byte[]>("QrKod")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<DateTime>("VrijemeOdrzavanja");

                    b.HasKey("TerminId");

                    b.HasIndex("InstruktorId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("PredmetId");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("TutorFinderApp.Models.Termin", b =>
                {
                    b.HasOne("TutorFinderApp.Models.Instruktor")
                        .WithMany("PrijavljeniTermini")
                        .HasForeignKey("InstruktorId");

                    b.HasOne("TutorFinderApp.Models.Klijent")
                        .WithMany("PrijavljeniTermini")
                        .HasForeignKey("KlijentId");

                    b.HasOne("TutorFinderApp.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
