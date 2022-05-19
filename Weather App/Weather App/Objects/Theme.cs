using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Weather_App.Converters;
using Xamarin.Forms;

namespace Weather_App.Objects
{
    public class Theme : INotifyPropertyChanged
    {
        #region Colors
        private Color littleRainColor;
        public Color LittleRainColor
        {
            get => littleRainColor;
            set
            {
                littleRainColor = value;
                OnPropertyChanged(nameof(LittleRainColor));
            }
        }

        private Color rainColor;
        public Color RainColor
        {
            get => rainColor;
            set
            {
                rainColor = value;
                OnPropertyChanged(nameof(RainColor));
            }
        }
        private Color sunnyColor;
        public Color SunnyColor
        {
            get => sunnyColor;
            set
            {
                sunnyColor = value;
                OnPropertyChanged(nameof(SunnyColor));
            }
        }
        private Color littleSnowColor;
        public Color LittleSnowColor
        {
            get => littleSnowColor;
            set
            {
                littleSnowColor = value;
                OnPropertyChanged(nameof(LittleSnowColor));
            }
        }
        private Color snowColor;
        public Color SnowColor
        {
            get => snowColor;
            set
            {
                snowColor = value;
                OnPropertyChanged(nameof(SnowColor));
            }
        }
       
        private Color partiallyCloudyColor;
        public Color PartiallyCloudyColor
        {
            get => partiallyCloudyColor;
            set
            {
                partiallyCloudyColor = value;
                OnPropertyChanged(nameof(PartiallyCloudyColor));
            }
        }
        private Color cloudyColor;
        public Color CloudyColor
        {
            get => cloudyColor;
            set
            {
                cloudyColor = value;
                OnPropertyChanged(nameof(CloudyColor));
            }
        }
        private Color dullColor;
        public Color DullColor
        {
            get => dullColor;
            set
            {
                dullColor = value;
                OnPropertyChanged(nameof(DullColor));
            }
        }
        private Color mainlyCloudyColor;
        public Color MainlyCloudyColor
        {
            get => mainlyCloudyColor;
            set
            {
                mainlyCloudyColor = value;
                OnPropertyChanged(nameof(MainlyCloudyColor));
            }
        }
        private Color thunderstormColor;
        public Color ThunderstormColor
        {
            get => thunderstormColor;
            set
            {
                thunderstormColor = value;
                OnPropertyChanged(nameof(ThunderstormColor));
            }
        }
        #endregion

        #region Icons

        private string littleRainIcon;
        public string LittleRainIcon
        {
            get => littleRainIcon;
            set
            {
                littleRainIcon = value;
                OnPropertyChanged(nameof(LittleRainIcon));
            }
        }
        
        private string rainIcon;
        public string RainIcon
        {
            get => rainIcon;
            set
            {
                rainIcon = value;
                OnPropertyChanged(nameof(RainIcon));
            }
        }
        private string partiallyCloudyIcon;
        public string PartiallyCloudyIcon
        {
            get => partiallyCloudyIcon;
            set
            {
                partiallyCloudyIcon = value;
                OnPropertyChanged(nameof(PartiallyCloudyIcon));
            }
        }
        private string cloudIcon;
        public string CloudIcon
        {
            get => cloudIcon;
            set
            {
                cloudIcon = value;
                OnPropertyChanged(nameof(CloudIcon));
            }
        }
        private string mainlyCloudyIcon;
        public string MainlyCloudyIcon
        {
            get => mainlyCloudyIcon;
            set
            {
                mainlyCloudyIcon = value;
                OnPropertyChanged(nameof(MainlyCloudyIcon));
            }
        }
        private string dullIcon;
        public string DullIcon
        {
            get => dullIcon;
            set
            {
                dullIcon = value;
                OnPropertyChanged(nameof(DullIcon));
            }
        }
        private string littleSnowIcon;
        public string LittleSnowIcon
        {
            get => littleSnowIcon;
            set
            {
                littleSnowIcon = value;
                OnPropertyChanged(nameof(LittleSnowIcon));
            }
        }
        private string sunnyIcon;
        public string SunnyIcon
        {
            get => sunnyIcon;
            set
            {
                sunnyIcon = value;
                OnPropertyChanged(nameof(SunnyIcon));
            }
        }
        private string snowIcon;
        public string SnowIcon
        {
            get => snowIcon;
            set
            {
                snowIcon = value;
                OnPropertyChanged(nameof(SnowIcon));
            }
        }
        private string thunderstormIcon;
        public string ThunderstormIcon
        {
            get => thunderstormIcon;
            set
            {
                thunderstormIcon = value;
                OnPropertyChanged(nameof(ThunderstormIcon));
            }
        }
        #endregion

        #region Videos

        private string littleRainVideo;
        public string LittleRainVideo
        {
            get => littleRainVideo;
            set
            {
                littleRainVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);
                OnPropertyChanged(nameof(LittleRainVideo));
            }
        }

        private string rainVideo;
        public string RainVideo
        {
            get => rainVideo;
            set
            {
                rainVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(RainVideo));
            }
        }
        private string partiallyCloudyVideo;
        public string PartiallyCloudyVideo
        {
            get => partiallyCloudyVideo;
            set
            {
                partiallyCloudyVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(PartiallyCloudyVideo));
            }
        }
        private string cloudVideo;
        public string CloudVideo
        {
            get => cloudVideo;
            set
            {
                cloudVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(CloudVideo));
            }
        }
        private string mainlyCloudyVideo;
        public string MainlyCloudyVideo
        {
            get => mainlyCloudyVideo;
            set
            {
                mainlyCloudyVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(MainlyCloudyVideo));
            }
        }
        private string dullVideo;
        public string DullVideo
        {
            get => dullVideo;
            set
            {
                dullVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(DullVideo));
            }
        }
        private string littleSnowVideo;
        public string LittleSnowVideo
        {
            get => littleSnowVideo;
            set
            {
                littleSnowVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(LittleSnowVideo));
            }
        }
        private string sunnyVideo;
        public string SunnyVideo
        {
            get => sunnyVideo;
            set
            {
                sunnyVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(SunnyVideo));
            }
        }
        private string snowVideo;
        public string SnowVideo
        {
            get => snowVideo;
            set
            {
                snowVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(SnowVideo));
            }
        }
        private string thunderstormVideo;
        public string ThunderstormVideo
        {
            get => thunderstormVideo;
            set
            {
                thunderstormVideo = (string)new VideoSourceConverter().Convert(value,typeof(string),null, CultureInfo.CurrentCulture);;
                OnPropertyChanged(nameof(ThunderstormVideo));
            }
        }

        #endregion

        #region Images

        private string littleRainImage;
        public string LittleRainImage
        {
            get => littleRainImage;
            set
            {
                littleRainImage = value;
                OnPropertyChanged(nameof(LittleRainImage));
            }
        }

        private string rainImage;
        public string RainImage
        {
            get => rainImage;
            set
            {
                rainImage = value;
                OnPropertyChanged(nameof(RainImage));
            }
        }
        private string partiallyCloudyImage;
        public string PartiallyCloudyImage
        {
            get => partiallyCloudyImage;
            set
            {
                partiallyCloudyImage = value;
                OnPropertyChanged(nameof(PartiallyCloudyImage));
            }
        }
        private string cloudImage;
        public string CloudImage
        {
            get => cloudImage;
            set
            {
                cloudImage = value;
                OnPropertyChanged(nameof(CloudImage));
            }
        }
        private string mainlyCloudyImage;
        public string MainlyCloudyImage
        {
            get => mainlyCloudyImage;
            set
            {
                mainlyCloudyImage = value;
                OnPropertyChanged(nameof(MainlyCloudyImage));
            }
        }
        private string dullImage;
        public string DullImage
        {
            get => dullImage;
            set
            {
                dullImage = value;
                OnPropertyChanged(nameof(DullImage));
            }
        }
        private string littleSnowImage;
        public string LittleSnowImage
        {
            get => littleSnowImage;
            set
            {
                littleSnowImage = value;
                OnPropertyChanged(nameof(LittleSnowImage));
            }
        }
        private string sunnyImage;
        public string SunnyImage
        {
            get => sunnyImage;
            set
            {
                sunnyImage = value;
                OnPropertyChanged(nameof(SunnyImage));
            }
        }
        private string snowImage;
        public string SnowImage
        {
            get => snowImage;
            set
            {
                snowImage = value;
                OnPropertyChanged(nameof(SnowImage));
            }
        }
        private string thunderstormImage;
        public string ThunderstormImage
        {
            get => thunderstormImage;
            set
            {
                thunderstormImage = value;
                OnPropertyChanged(nameof(ThunderstormImage));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));
        }
        public Theme()
        {
            //Colors
            {
                LittleRainColor = Color.FromRgb(156, 174, 176);
                LittleSnowColor = Color.FromRgb(224, 227, 236);

                RainColor = Color.FromRgb(10, 25, 66);
                SunnyColor = Color.FromRgb(151, 78, 46);
                SnowColor = Color.FromRgb(139, 162, 206);

                PartiallyCloudyColor = Color.FromRgb(84, 104, 128);
                CloudyColor = Color.FromRgb(188, 203, 210);
                MainlyCloudyColor = Color.FromRgb(74, 91, 111);
                DullColor = Color.FromRgb(45, 48, 55);

                ThunderstormColor = Color.FromRgb(40, 7, 76);
            }

            //Icons
            {
                LittleRainIcon = "../Resources/drawable/Little_rain.png";
                LittleSnowIcon = "../Resources/drawable/Little_Snow.png";

                RainIcon = "../Resources/drawable/Rain.png";
                SunnyIcon = "../Resources/drawable/Sunny.png";
                SnowIcon = "../Resources/drawable/Snow.png";

                PartiallyCloudyIcon = "../Resources/drawable/Partially_cloudy.png";
                CloudIcon = "../Resources/drawable/Cloud.png";
                MainlyCloudyIcon = "../Resources/drawable/Mainly_cloudy.png";
                DullIcon = "../Resources/drawable/dull.png";

                ThunderstormIcon = "../Resources/drawable/Thunderstorm.png";
            }

            //Videos
            {
                LittleRainVideo = "LittleRain.mp4";
                LittleSnowVideo = "LittleSnow.mp4";

                RainVideo = "Rain.mp4";
                SunnyVideo = "Sunny.mp4";
                SnowVideo = "Snow.mp4";

                PartiallyCloudyVideo = "PartiallyCloudy.mp4";
                CloudVideo = "Cloud.mp4";
                MainlyCloudyVideo = "MainlyCloudy.mp4";
                DullVideo = "Dull.mp4";

                ThunderstormVideo = "Thunderstorm.mp4";
            }

            //Images
            {
                LittleRainImage = "../Resources/drawable/Background.Little_Rain.jpg";
                LittleSnowImage = "../Resources/drawable/Background.Little_Snow.jpg";

                RainImage = "../Resources/drawable/Background.Rain.jpg";
                SunnyImage = "../Resources/drawable/Background.Sunny.jpg";
                SnowImage = "../Resources/drawable/Background.Snow.jpg";

                PartiallyCloudyImage = "../Resources/drawable/Background.Partially_cloudy.jpg";
                CloudImage = "../Resources/drawable/Background.Cloudy.jpg";
                MainlyCloudyImage = "../Resources/drawable/Background.Mainly_cloudy.jpg";
                DullImage = "../Resources/drawable/Background.dull.jpg";

                ThunderstormImage = "../Resources/drawable/Background.Thunderstorm.jpg";
            }
        }
    }
}
