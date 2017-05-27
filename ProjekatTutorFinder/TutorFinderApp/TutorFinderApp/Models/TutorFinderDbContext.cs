
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TutorFinderApp.Models
{
    class TutorFinderDbContext : DbContext
    {
        public DbSet<Klijent> Klijenti { get; set; }
        public DbSet<Instruktor> Instruktori { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Termin> Termini { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string DbPutanja = "Baza.db";

            try
            {
                DbPutanja = Path.Combine(ApplicationData.Current.LocalFolder.Path, DbPutanja);
            }
            catch (InvalidOperationException){ }

            optionsBuilder.UseSqlite($"Data source={DbPutanja}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instruktor>().Property(p => p.slika).HasColumnType("image");
            modelBuilder.Entity<Termin>().Property(p => p.QrKod).HasColumnType("image");
        }
    }
}
