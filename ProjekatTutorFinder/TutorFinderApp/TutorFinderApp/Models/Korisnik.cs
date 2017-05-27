using System;
using System.ComponentModel.DataAnnotations;

namespace TutorFinderApp.Models
{
    class Korisnik
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Tuple<double, double> lokacija { get; set; }
    }
}
