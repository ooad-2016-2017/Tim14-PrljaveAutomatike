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
      
        
        public Windows.UI.Xaml.Media.Imaging.WriteableBitmap slikica { get; set; }
        public QRkodVM(NavigationService _navigationService, object _arg)
        {
            var barcodeWriter = new BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,
                    Height = 300,
                    Margin = 30
                }
            };

             var image = barcodeWriter.Write("Dzenita");
            slikica = barcodeWriter.Write("Dzenita");
          // var image = barcodeWriter.Write((string)_arg);
            //slikica =barcodeWriter.Write((string)_arg);
        }
    }
}
