using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.Helpers;
using TutorFinderApp.Models;

namespace TutorFinderApp.ViewModels
{
    class KlijentVm : ViewModelBase
    {
        public List<string> lista { get; set; }
        public RelayCommand Logout { get; set; }
        public RelayCommand TraziInstrukcije { get; set; }
        public NavigationService navigationService;

        public KlijentVm(NavigationService _navigationService, object _arg)
        {
            navigationService = _navigationService;
            Logout = new RelayCommand(izvrsiLogout);
            TraziInstrukcije = new RelayCommand(traziInstrukcije);

            using (var dbCon = new TutorFinderDbContext())
            {
                foreach(var klijent in dbCon.Klijenti)
                {
                    if(klijent.Ime == (((Klijent)_arg).Ime) && klijent.Prezime == (((Klijent)_arg).Prezime))
                    {
                        foreach (var termin in dbCon.Termini)
                        {
                            if(termin.KlijentId == klijent.KlijentId)
                            {
                                lista.Add("Predmet: " + termin.Predmet  + ", vrijeme: " + termin.VrijemeOdrzavanja.Date + " " + termin.VrijemeOdrzavanja.TimeOfDay);
                            }
                        }
                        break;
                    }
                }
            }
        }

        protected async void izvrsiLogout(object _arg)
        {
            
        }

        protected async void traziInstrukcije(object _arg)
        {
            //navigationService.Navigate(typeof(Pretraga))
        }
    }
}
