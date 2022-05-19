using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Weather_App.Objects;
using Xamarin.Forms;

namespace Weather_App.Converters
{
    public class VideoConverter : IValueConverter
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
                    return theme.LittleRainVideo;
                case "дождь":
                    return theme.RainVideo;
                case "облачно с прояснениями":
                    return theme.PartiallyCloudyVideo;
                case "небольшая облачность":
                    return theme.CloudVideo;
                case "переменная облачность":
                    return theme.MainlyCloudyVideo;
                case "пасмурно":
                    return theme.DullVideo;
                case "небольшой снег":
                    return theme.LittleSnowVideo;
                case "ясно":
                    return theme.SunnyVideo;
                case "снег":
                    return theme.SnowVideo;
                case "гроза":
                    return theme.ThunderstormVideo;
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
