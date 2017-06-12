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

        public Klijent(int id, string ime, string prezime, string email,string username, string password, string brojTel, string lokacija) : base(id, ime, prezime, email, username, password, brojTel, lokacija) {KlijentId = id + 1; }
    }
}
