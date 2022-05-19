using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Weather_App.Objects;
using Xamarin.Forms;

namespace Weather_App.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            return GetImage(value as string, parameter as Theme);
        }
        private string GetImage(string weather, Theme theme)
        {
            switch (weather)
            {
                case "небольшой дождь":
                    return theme.LittleRainImage;
                case "дождь":
                    return theme.RainImage;
                case "облачно с прояснениями":
                    return theme.PartiallyCloudyImage;
                case "небольшая облачность":
                    return theme.CloudImage;
                case "переменная облачность":
                    return theme.MainlyCloudyImage;
                case "пасмурно":
                    return theme.DullImage;
                case "небольшой снег":
                    return theme.LittleSnowImage;
                case "ясно":
                    return theme.SunnyImage;
                case "снег":
                    return theme.SnowImage;
                case "гроза":
                    return theme.ThunderstormImage;
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
