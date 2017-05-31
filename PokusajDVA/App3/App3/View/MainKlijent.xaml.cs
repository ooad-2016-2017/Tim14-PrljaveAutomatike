using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TutorFinderApp.ViewModels;
using TutorFinderApp.Helpers;
using TutorFinderApp.Models;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TutorFinderApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainKlijent : Page
    {
        public MainKlijent()
        {
            this.InitializeComponent();
            DataContext = new KlijentVm(new NavigationService());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("ok", "ko");
        }
    }
}
