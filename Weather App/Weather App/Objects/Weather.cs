using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Weather_App.Objects
{
    public class Weather : INotifyPropertyChanged
    {
        private string temperature;
        public string Temperature 
        { 
            get => temperature; 
            set 
            {
                temperature = value; 
                OnPropertyChanged(nameof(Temperature)); 
            } 
        }

        private string temperatureMin;
        public string TemperatureMin
        {
            get => temperatureMin;
            set
            {
                temperatureMin = value;
                OnPropertyChanged(nameof(TemperatureMin));
            }
        }

        private string temperatureMax;
        public string TemperatureMax
        {
            get => temperatureMax;
            set
            {
                temperatureMax = value;
                OnPropertyChanged(nameof(TemperatureMax));
            }
        }

        private string pressure;
        public string Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                OnPropertyChanged(nameof(Pressure));
            }
        }

        private string humidity;
        public string Humidity
        {
            get => humidity;
            set
            {
                humidity = value;
                OnPropertyChanged(nameof(Humidity));
            }
        }

        private string visibility;
        public string Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                OnPropertyChanged(nameof(Visibility));
            }
        }

        private string windSpeed;
        public string WindSpeed
        {
            get => windSpeed;
            set
            {
                windSpeed = value;
                OnPropertyChanged(nameof(WindSpeed));
            }
        }

        private string windDegress;
        public string WindDegress
        {
            get => windDegress;
            set
            {
                windDegress = value;
                OnPropertyChanged(nameof(WindDegress));
            }
        }

        private string windGust;
        public string WindGust
        {
            get => windGust;
            set
            {
                windGust = value;
                OnPropertyChanged(nameof(WindGust));
            }
        }

        private string clouds;
        public string Clouds
        {
            get => clouds;
            set
            {
                clouds = value;
                OnPropertyChanged(nameof(Clouds));
            }
        }

        private string temperatureFeels;
        public string TemperatureFeels
        {
            get => temperatureFeels;
            set
            {
                temperatureFeels = value;
                OnPropertyChanged(nameof(TemperatureFeels));
            }
        }

        private string date;
        public string Date 
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            } 
        }

        private string icon;
        public string Icon
        {
            get => icon;
            set
            {
                icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        private string city;
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string mainWeather;
        public string MainWeather
        {
            get => mainWeather;
            set
            {
                mainWeather = value;
                OnPropertyChanged(nameof(MainWeather));
            }
        }

        private string descriptionWeather;
        public string DescriptionWeather
        {
            get => descriptionWeather;
            set
            {
                descriptionWeather = value;
                OnPropertyChanged(nameof(DescriptionWeather));
            }
        }

        private ObservableCollection<Weather> forecast;
        public ObservableCollection<Weather> Forecast
        {
            get => forecast;
            set
            {
                forecast = value;
                OnPropertyChanged(nameof(Forecast));
            }
        }
        private string weatherVideo;
        public string WeatherVideo
        {
            get => weatherVideo;
            set
            {
                weatherVideo = value;
                OnPropertyChanged(nameof(WeatherVideo));
            }
        }
        private string weatherImage;
        public string WeatherImage
        {
            get => weatherImage;
            set
            {
                weatherImage = value;
                OnPropertyChanged(nameof(WeatherImage));
            }
        }
        private Color weatherColor;
        public Color WeatherColor
        {
            get => weatherColor;
            set
            {
                weatherColor = value;
                OnPropertyChanged(nameof(WeatherColor));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(prop));
        }

        public Weather()
        {
            WeatherVideo = "";
            WeatherImage = "";
            Icon = "";
            Forecast = new ObservableCollection<Weather>();
        }
    }
}
