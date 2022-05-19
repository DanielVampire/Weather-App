using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Weather_App.Objects;
using Xamarin.Forms;

namespace Weather_App.Converters
{
    public class IconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            return GetIcon(value as string, parameter as Theme);
        }
        private string GetIcon(string weather, Theme theme)
        {
            switch (weather)
            {
                case "небольшой дождь":
                    return theme.LittleRainIcon;
                case "дождь":
                    return theme.RainIcon;
                case "облачно с прояснениями":
                    return theme.PartiallyCloudyIcon;
                case "небольшая облачность":
                    return theme.CloudIcon;
                case "переменная облачность":
                    return theme.MainlyCloudyIcon;
                case "пасмурно":
                    return theme.DullIcon;
                case "небольшой снег":
                    return theme.LittleSnowIcon;
                case "ясно":
                    return theme.SunnyIcon;
                case "снег":
                    return theme.SnowIcon;
                case "гроза":
                    return theme.ThunderstormIcon;
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
