using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TutorFinderApp.ViewModels
{
    public abstract class Pomocna : INotifyPropertyChanged
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
    }
}
