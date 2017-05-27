using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.ViewModels;
using TutorFinderApp.Models;
using TutorFinderApp.Helpers;
using System.Windows.Input;

namespace TutorFinderApp.ViewModels
{
    class KorisnikVM : Pomocna
    {
        public RelayCommand LoginKomanda { get; set; }

        private string Ime;
        private string Prezime;
        private string Username;
        private string Password;
        private string Email;
        private string BrojTel;
        private string Grad;

        public KorisnikVM()
        {
            Ime = null;
            Prezime = null;
            Username = null;
            Password = null;
            Email = null;
            BrojTel = null;
            Grad = null;

            LoginKomanda = new RelayCommand(IzvrsiLogin);
        }

        private void IzvrsiLogin()
        {
            using(TutorFinderDbContext dbObj = new TutorFinderDbContext())
            {

            }
        }

    }
}
