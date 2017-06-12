using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.Helpers;
using TutorFinderApp.View;


namespace TutorFinderApp.ViewModels
{
    class MainPageVM : ViewModelBase
    {
        public RelayCommand RegistracijaCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }

        private NavigationService navigationService;

        public MainPageVM(NavigationService _navigationService) {
            RegistracijaCommand= new RelayCommand(Idi_Registracija);
            LoginCommand = new RelayCommand(Idi__Login);
            navigationService = _navigationService;
        }

        private void Idi__Login(object obj)
        {
            navigationService.Navigate(typeof(Login));
        }

        private void Idi_Registracija(object obj)
        {
            navigationService.Navigate(typeof(Registracija));
        }
    }
}
