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
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string BrojTel { get; set; }
        public string Grad { get; set; }

        public Windows.UI.Xaml.Controls.Frame frameObject { get; set; }

        public RegistracijaVM(Windows.UI.Xaml.Controls.Frame _frameObject)
        {
            RegistracijaCommand = new RelayCommand(IzvrsiRegistraciju);
            frameObject = _frameObject;
        }

        private void IzvrsiRegistraciju(object _param)
        {
            Password = GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString());
            frameObject.Navigate(typeof(Login));
            
            //obaviti proces registracije
        }

    }
}
