using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Weather_App.Objects;
using Xamarin.Forms;

namespace Weather_App.Converters
{
    public class ThemeConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            return GetTheme(value as string, parameter as Theme);
        }
        private Tuple<string,Color,string, string> GetTheme(string weather, Theme theme)
        {
            Tuple<string, Color, string, string> data;
            switch (weather)
            {
                case "небольшой дождь":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.LittleRainVideo, 
                        theme.LittleRainColor, 
                        theme.LittleRainIcon,
                        theme.LittleRainImage
                        );
                    return data;
                case "дождь":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.RainVideo,
                        theme.RainColor,
                        theme.RainIcon,
                        theme.RainImage
                        );
                    return data;
                case "облачно с прояснениями":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.PartiallyCloudyVideo,
                        theme.PartiallyCloudyColor,
                        theme.PartiallyCloudyIcon,
                        theme.PartiallyCloudyImage
                        );
                    return data;
                case "небольшая облачность":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.CloudVideo,
                        theme.CloudyColor,
                        theme.CloudIcon,
                        theme.CloudImage
                        );
                    return data;
                case "переменная облачность":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.MainlyCloudyVideo,
                        theme.MainlyCloudyColor,
                        theme.MainlyCloudyIcon,
                        theme.MainlyCloudyImage
                        );
                    return data;
                case "пасмурно":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.DullVideo,
                        theme.DullColor,
                        theme.DullIcon,
                        theme.DullImage
                        );
                    return data;
                case "небольшой снег":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.LittleSnowVideo,
                        theme.LittleSnowColor,
                        theme.LittleSnowIcon,
                        theme.LittleSnowImage
                        );
                    return data;
                case "ясно":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.SunnyVideo,
                        theme.SunnyColor,
                        theme.SunnyIcon,
                        theme.SunnyImage
                        );
                    return data;
                case "снег":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.SnowVideo,
                        theme.SnowColor,
                        theme.SnowIcon,
                        theme.SnowImage
                        );
                    return data;
                case "гроза":
                    data = new Tuple<string, Color, string, string>
                        (
                        theme.ThunderstormVideo,
                        theme.ThunderstormColor,
                        theme.ThunderstormIcon,
                        theme.ThunderstormImage
                        );
                    return data;
            }
            return new Tuple<string, Color, string, string>(string.Empty, new Color(), string.Empty, string.Empty);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
