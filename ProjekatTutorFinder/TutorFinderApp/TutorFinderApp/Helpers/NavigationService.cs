using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TutorFinderApp.Helpers
{
    class NavigationService: INavigationService
    {
        public void Navigate(Type page)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(page);
        }

        public void Navigate(Type page, object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(page, parameter);
        }

        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            frame.GoBack();
        }
    }
}
