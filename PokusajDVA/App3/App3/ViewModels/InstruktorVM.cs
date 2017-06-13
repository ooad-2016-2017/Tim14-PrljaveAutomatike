using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.Helpers;
using TutorFinderApp.Models;
using TutorFinderApp.View;

namespace TutorFinderApp.ViewModels
{
    class InstruktorVM : ViewModelBase
    {
        public NavigationService navigationService;
        private readonly Action<object> prikaziQRKod;

        public RelayCommand Logout { get; set; }
        public RelayCommand Termini { get; set; }
        public RelayCommand MojQRKod { get; set; }
        public List<string> lista { get; set; }
        Instruktor inst;

        public InstruktorVM(NavigationService _navigationService, object _arg)
        {
            navigationService = _navigationService;
            Logout = new RelayCommand(izvrsiLogout);
            Termini = new RelayCommand(prikaziTermine);
            MojQRKod = new RelayCommand(PrikaziQRKod);
            lista = new List<string>();

            using (var dbCon = new TutorFinderDbContext())
            {
                foreach (var instruktor in dbCon.Instruktori)
                {
                    if (instruktor.Ime == (((Instruktor)_arg).Ime) && instruktor.Prezime == (((Instruktor)_arg).Prezime))
                    {
                        foreach (var termin in dbCon.Termini)
                        {
                            if (termin.InstruktorId == instruktor.InstruktorId)
                            {
                                lista.Add("Predmet: " + termin.Predmet + ", vrijeme: " + termin.VrijemeOdrzavanja.Date + " " + termin.VrijemeOdrzavanja.TimeOfDay);
                            }
                            inst = instruktor;
                        }
                        OnPropertyChanged("lista");
                        break;
                    }

                    }

            }


        }

        private void PrikaziQRKod(object obj)
        {
            obj = inst.Ime  +DateTime.Now.ToString("h:mm:ss tt");
            navigationService.Navigate(typeof(QRkod),obj);
        }


        private void prikaziTermine(object obj)
        {
            navigationService.Navigate(typeof(MainInstruktor));
        }

        protected async void izvrsiLogout(object _arg)
        {
            navigationService.Navigate(typeof(Login));
        }

        
    }
}
