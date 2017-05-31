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

        public KlijentVm(NavigationService _navigationService, object _arg)
        {
            NavigationService navigationService = _navigationService;

            using (var dbCon = new TutorFinderDbContext())
            {
                foreach(var klijent in dbCon.Klijenti)
                {
                    if(klijent.Ime == (((Klijent)_arg).Ime) && klijent.Prezime == (((Klijent)_arg).Prezime))
                    {

                    }
                }
            }
        }
    }
}
