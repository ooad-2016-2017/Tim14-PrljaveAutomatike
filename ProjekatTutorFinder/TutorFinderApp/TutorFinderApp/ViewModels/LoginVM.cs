using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.Helpers;
using TutorFinderApp.Models;


namespace TutorFinderApp.ViewModels
{
    class LoginVM : ViewModelBase 
    {
        public RelayCommand LoginCommand { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


        public LoginVM()
        {
            LoginCommand = new RelayCommand(IzvrsiLogin);

        }

        private void IzvrsiLogin(object _param) {

            Password = GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString());

            using (var DbObj = new TutorFinderApp.Models.TutorFinderDbContext()) {

                var Klijenti = DbObj.Klijenti;

                //pretraga da li ime i password postoje u bazi

                int count = 0;
                var korisnik = null;
                foreach (var k in Klijenti) {
                    if (k.Email = Email && k.Password = Password) { korisnik = k;count = 1; break; } 
                        }
                
                //if (korisnik != null && count = 1)
                //{
                 //   this.Frame.Navigate(typeof(MainPage), korisnik);
                //}
                //else
                //{
                 //   var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna
                  // prijava");
                   
                  //  await dialog.ShowAsync();
                //}
            }
        }
    }
}
