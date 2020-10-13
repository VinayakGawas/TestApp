using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TestApp.Converters
{
    public class BytesToImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource imgSource = null;

            if (value is string img)
            {

            }
            byte[] FileName = value as byte[];
            if (FileName != null)
            {


                var stream1 = new MemoryStream(FileName);
                imgSource = ImageSource.FromStream(() => stream1);
                return imgSource;
            }
            else
            {
                return null;
              //  imgSource = (FileImageSource)PlatFromImage.GetImage("no_image.png");
               // return imgSource;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
