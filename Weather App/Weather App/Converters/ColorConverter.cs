using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Weather_App.Objects;
using Xamarin.Forms;

namespace Weather_App.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            return GetColor(value as string, parameter as Theme);
        }

        private Color GetColor(string weather,Theme theme)
        {
            switch (weather)
            {
                case "небольшой дождь":
                    return theme.LittleRainColor;
                case "дождь":
                    return theme.RainColor;
                case "облачно с прояснениями":
                    return theme.PartiallyCloudyColor;
                case "небольшая облачность":
                    return theme.CloudyColor;
                case "переменная облачность":
                    return theme.MainlyCloudyColor;
                case "пасмурно":
                    return theme.DullColor;
                case "небольшой снег":
                    return theme.LittleSnowColor;
                case "ясно":
                    return theme.SunnyColor;
                case "снег":
                    return theme.SnowColor;
                case "гроза":
                    return theme.ThunderstormColor;
            }
            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
