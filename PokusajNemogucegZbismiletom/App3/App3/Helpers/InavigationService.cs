using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorFinderApp.Helpers
{
    public interface INavigationService
    {
        void Navigate(Type page);
        void Navigate(Type page, object parameter);
        void GoBack();
    }
}
