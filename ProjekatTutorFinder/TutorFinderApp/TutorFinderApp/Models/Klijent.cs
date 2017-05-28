using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TutorFinderApp.ViewModels;

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
                    _KlijentId= value;
                    OnPropertyChanged("KlijentId");
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
                    OnPropertyChanged("_PrijavljeniTermini");
                }
            }
        }
    }
}
