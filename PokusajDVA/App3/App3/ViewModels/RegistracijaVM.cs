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
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

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
                    if (dbCon.Klijenti.Where(b => b.Email == $"{Email}") != null)
                    {
                        //provjeriti ostala polja
                        dbCon.Klijenti.Add(new Klijent(Ime, Prezime, Email, GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString()), BrojTel, new Tuple<double, double>(0, 0)));
                    }
                }
                else
                {
                    if (dbCon.Instruktori.Where(b => b.Email == $"{Email}") != null)
                    {
                        //provjeriti ostala polja
                        dbCon.Instruktori.Add(new Instruktor(Ime, Prezime, Email, GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString()), BrojTel, new Tuple<double, double>(0, 0)));
                        //zahtjev za sliku
                    }
                }
            }
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

    }
}
