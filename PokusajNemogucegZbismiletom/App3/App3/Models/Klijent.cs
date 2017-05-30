using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace TutorFinderApp.Models
{
    class Klijent : Korisnik
    {
        protected int _KlijentId;
        protected List<Termin> _PrijavljeniTermini;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlijentId
        {
            get { return _KlijentId; }
            set
            {
                if (value != _KlijentId)
                {
                    _KlijentId = value;

                }
            }
        }

        public List<Termin> PrijavljeniTermini
        {
            get { return _PrijavljeniTermini; }
            set
            {
                if (value != _PrijavljeniTermini)
                {
                    _PrijavljeniTermini = value;

                }
            }
        }

        public Klijent(string ime, string prezime, string email, string password, string brojTel, Tuple<double, double> lokacija) : base(ime, prezime, email, password, brojTel, lokacija) { }
    }
}
