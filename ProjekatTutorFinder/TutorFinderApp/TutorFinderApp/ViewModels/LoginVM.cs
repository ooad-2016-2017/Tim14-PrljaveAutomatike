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

        private IzvrsiLogin(object _param) {

            Password = GenerateHashFromString(((Windows.UI.Xaml.Controls.PasswordBox)_param).Password.ToString());

            using (var DbObj = new TutorFinderApp.Models.TutorFinderDbContext) {

                var Klijenti = DbObj.Klijenti();
                if()
            }
        }
    }
}
