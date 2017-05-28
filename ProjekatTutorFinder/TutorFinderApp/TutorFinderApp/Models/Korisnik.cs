using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TutorFinderApp.ViewModels;

namespace TutorFinderApp.Models
{
    class Korisnik
    {
        protected string _Ime;
        protected string _Prezime;
        protected string _Email;
        protected string _Username;
        protected string _Password;
        protected Tuple<double, double> _Lokacija;

        [Required]
        public string Ime { get { return _Ime; }
                            set {
                                    if(value != _Ime)
                                    {
                                        _Ime = value;
                                    }
                                }
                          }
        [Required]
        public string Prezime
                            {
                                get { return _Prezime; }
                                set
                                {
                                    if (value != _Prezime)
                                    {
                                        _Prezime = value;
                                    }
                                }
                            }
        [Required]
        public string Email
                            {
                                get { return _Email; }
                                set
                                {
                                    if (value != _Email)
                                    {
                                        _Email = value;
                                    }
                                }
                            }
        [Required]
        public string Username
                            {
                                get { return _Username; }
                                set
                                {
                                    if (value != _Username)
                                    {
                                        _Username = value;
                      
                                    }
                                }
                            }
        [Required]
        public string Password
                            {
                                get { return _Password; }
                                set
                                {
                                    if (value != _Password)
                                    {
                                        _Prezime = value;
                                    
                                    }
                                }
                            }
        [Required]
        public Tuple<double, double> Lokacija
                            {
                                get { return _Lokacija; }
                                set
                                {
                                    if (value != _Lokacija)
                                    {
                                        _Lokacija = value;
                                      
                                    }
                                }
                            }
    }
}
