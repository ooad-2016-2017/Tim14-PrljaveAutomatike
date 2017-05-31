﻿using System;
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

        public KlijentVm(NavigationService _navigationService)
        {
            NavigationService navigationService = _navigationService;
            lista = new List<string>();
            lista.Add("haris");
            lista.Add("nermin");
            lista.Add("dzenita");
            OnPropertyChanged("lista");


            using (var dbCon = new TutorFinderDbContext())
            {
                foreach(var klijent in dbCon.Klijenti)
                {

                }
            }
        }
    }
}
