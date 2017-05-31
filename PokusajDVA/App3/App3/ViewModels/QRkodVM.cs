using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorFinderApp.Helpers;
using TutorFinderApp.View;
using ZXing.Mobile;

namespace TutorFinderApp.ViewModels

{
    class QRkodVM: ViewModelBase
    {
        public Windows.UI.Xaml.Media.Imaging.WriteableBitmap slika;
        public QRkodVM(NavigationService _navigationService, object _arg) {
            var write = new BarcodeWriter();
            write.Format = ZXing.BarcodeFormat.QR_CODE;
            slika = write.Write((string)_arg);
        }
    }
}
