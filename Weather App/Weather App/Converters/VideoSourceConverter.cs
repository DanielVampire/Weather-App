using System;
using System.Globalization;
using Weather_App.Objects;
using Xamarin.Forms;

namespace Weather_App.Converters
{
    public class VideoSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            if (Device.RuntimePlatform == Device.UWP)
                return $"ms-appx:///Assets/{value}";
            else
                return $"ms-appx:///{value}";
        }
        private string GetVideo(string weather,Theme theme)
        {
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
