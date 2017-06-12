using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.Helpers;

namespace TutorFinderApp.ViewModels
{
    class LokacijaVM : ViewModelBase, INotifyPropertyChanged
    {
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public string Adresa {get; set;}
        public string sourceURL { get; set; }
        public RelayCommand Trazi { get; set; }
        private NavigationService navigationService;
        public LokacijaVM(NavigationService _navigationService)
        {
            Trazi = new RelayCommand(Izvrsi_trazenje);
            navigationService = _navigationService;
            sourceURL = "https://www.google.ba/maps?q=";
        }

        private void Izvrsi_trazenje(object obj)
        {
            StringBuilder queryaddress = new StringBuilder();
            queryaddress.Append("https://www.google.ba/maps?q=");
            if(Adresa!=string.Empty)
            {
                queryaddress.Append(Adresa+","+"+");
            }
            if (Grad != string.Empty)
            {
                queryaddress.Append(Grad + "," + "+");
            }
            if (Drzava!= string.Empty)
            {
                queryaddress.Append(Drzava );
            }
            sourceURL=queryaddress.ToString();
            OnNotifyPropertyChanged("sourceURL");

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
