using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Security.Cryptography;

namespace TutorFinderApp.ViewModels
{ 
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, e);
            }
        }

        protected virtual void SetProperty<T>(ref T property, T value, string propertyName)
        {
            property = value;
            this.OnPropertyChanged(propertyName);
        } 

        //nema veze sa viewmodelom ali je korisno da bude tu
        protected string GenerateHashFromString(string _string)
        {
            MD5 md5Hash = MD5.Create();
            byte[] hashByte = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(_string.ToString()));
            StringBuilder sBuilder = new StringBuilder();

            foreach (byte b in hashByte)
            {
                sBuilder.Append(b.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
