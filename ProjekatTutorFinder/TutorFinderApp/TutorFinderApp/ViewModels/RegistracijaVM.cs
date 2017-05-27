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
    class RegistracijaVM : Pomocna
    {
        public RelayCommand RegistracijaCommand { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string BrojTel { get; set; }
        public string Grad { get; set; }

        public RegistracijaVM()
        {
            RegistracijaCommand = new RelayCommand(IzvrsiRegistraciju);
        }

        private void IzvrsiRegistraciju()
        {
            //Ime = "OK";
            //OnPropertyChanged("Ime"); //ok bindinzi
            //REST?
        }

    }
}
