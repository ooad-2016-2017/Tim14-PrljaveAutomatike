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
using System.Security.Cryptography;
using TutorFinderApp.View;


namespace TutorFinderApp.ViewModels
{
    class RegistracijaVM : ViewModelBase
    {
        public RelayCommand RegistracijaCommand { get; set; }
        public RelayCommand checkCommand { get; set; }
        public bool klijent, instruktor, toggle = true;
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string BrojTel { get; set; }
        public string Grad { get; set; }

        private NavigationService navigationService;

        public RegistracijaVM(NavigationService _navigationService)
        {
            RegistracijaCommand = new RelayCommand(IzvrsiRegistraciju);
            checkCommand = new RelayCommand(postaviTipKorisnika);
            navigationService = _navigationService;
        }

        private void postaviTipKorisnika(object _param)
        {
            toggle = !toggle;
            ((Windows.UI.Xaml.Controls.CheckBox)_param).IsEnabled = toggle;
        }

       
        //-----------------------------------------------------------------
        private void IzvrsiRegistraciju(object _param)
        {
            using (var dbCon = new TutorFinderDbContext())
            {
                if (klijent)
                {
                    if(dbCon.Klijenti.Where(b => b.Email == $"{Email}") != null)
                    {
                        //provjeriti ostala polja
                        dbCon.Klijenti.Add(new Klijent(Ime, Prezime, Email, GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString()), BrojTel, new Tuple<double, double>(0,0)));
                        //pozvat konstruktordbCon.Klijenti.Add(Klijent())
                    }
                }
                else
                {
                    if (dbCon.Instruktori.Where(b => b.Email == $"{Email}") != null)
                    {
                        //provjeriti ostala polja
                        //pozvat konstruktordbCon.Klijenti.Add(Instruktori())
                        //zahtjev za sliku
                    }
                }
            }

            /*using (var dbCon = new TutorFinderDbContext())
            {
                if(dbCon.Klijenti.Where(b => b.Email == $"{Email}") != null)
                    //postoji korisnik sa navedenim emailom
                else
                {
                    //provjeriti je li sve popunjeno
                    //upisati u bazu novog korisnika
                    //Password = GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString());
                    navigationService.Navigate(typeof(Login));
                }
            }*/
        //------------------------------------------------------------------





            //primjer kako se postavlja vrijednost nekog objekta u viewu 
            /*Ime = "HARIS";
            OnPropertyChanged("Ime");*/

            //primjer kako se prebacuje na drugi view
            /*navigationService.Navigate(typeof(Login));*/


            //obaviti proces registracije
        }

    }
}
