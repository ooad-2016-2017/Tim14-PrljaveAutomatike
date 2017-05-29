using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TutorFinderApp.ViewModels;

namespace TutorFinderApp.Models
{
    class Instruktor : Korisnik
    {
        protected int _InstruktorId;
        protected double _Ocjena;
        protected byte[] _slika;
        protected List<Termin> _PrijavljeniTermini;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstruktorId
        {
            get { return _InstruktorId; }
            set
            {
                if (value != _InstruktorId)
                {
                    _InstruktorId = value;
 
                }
            }
        }
        public double Ocjena
        {
            get { return _Ocjena; }
            set
            {
                if (value != _Ocjena)
                {
                    _Ocjena = value;
             
                }
            }
        }
        public byte[] slika
        {
            get { return _slika; }
            set
            {
                if (value != _slika)
                {
                    _slika = value;
                
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
        public Instruktor(string ime, string prezime, string email, string password, string brojTel, Tuple<double, double> lokacija): base(ime,prezime,email,password,brojTel,lokacija){ }
    }
}
