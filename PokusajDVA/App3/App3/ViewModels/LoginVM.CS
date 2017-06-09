using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.Helpers;
using TutorFinderApp.Models;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using TutorFinderApp.View;
using Windows.UI.Popups;

namespace TutorFinderApp.ViewModels
{
    class LoginVM : ViewModelBase
    {
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RegistracijaCommand { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        private NavigationService navigationService;

        public LoginVM(NavigationService _navigationService)
        {
            LoginCommand = new RelayCommand(IzvrsiLogin);
            RegistracijaCommand = new RelayCommand(IzvrsiRegistraciju);

            navigationService = _navigationService;
        }

        private void IzvrsiRegistraciju(object obj)
        {
            navigationService.Navigate(typeof(Registracija));
        }
        
        public LoginVM()
        {
            LoginCommand = new RelayCommand(IzvrsiLogin);

        }


        protected string GenerateHashFromString(string strMsg)
        {
            string strAlgName = HashAlgorithmNames.Md5;
            IBuffer buffUtf8Msg = CryptographicBuffer.ConvertStringToBinary(strMsg, BinaryStringEncoding.Utf8);

            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);
            strAlgName = objAlgProv.AlgorithmName;

            IBuffer buffHash = objAlgProv.HashData(buffUtf8Msg);

            if (buffHash.Length != objAlgProv.HashLength)
            {
                throw new Exception("There was an error creating the hash");
            }

            string hex = CryptographicBuffer.EncodeToHexString(buffHash);

            return hex;
        }


        private async void IzvrsiLogin(object _param)
        {

            Password = GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString());

            using (var DbObj = new TutorFinderApp.Models.TutorFinderDbContext())
            {

                var Klijenti = DbObj.Klijenti;

                //pretraga da li ime i password postoje u bazi
                Korisnik korisnik = null;

                foreach (var k in DbObj.Klijenti)
                {
                    if (k.Email == Email && k.Password == Password)
                    {
                        korisnik = k;
                        navigationService.Navigate(typeof(MainKlijent), k);
                        return;
                    }
                }


                foreach (var k in DbObj.Instruktori)
                {
                    if (k.Email == Email && k.Password == Password)
                    {
                        korisnik = k;
                        navigationService.Navigate(typeof(MainInstruktor), k);
                        return;
                    }

                }

                if (korisnik == null)
                {
                    var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");

                    await dialog.ShowAsync();
                }
            }
        }
    }
}
