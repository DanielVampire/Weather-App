using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Globalization;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using System.Linq;
using System.IO;
using System.Windows.Input;
using Weather_App.Objects;
using Weather_App.Converters;

namespace Weather_App.Model
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private Theme theme;
        public Theme Theme
        {
            get => theme;
            set
            {
                theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }
        public string VideoFile { get; set; } = "Rain.mp4";

        private string AppID = "be3909c2bcd42c281bbfc3d95cfa368b";

        private bool isLoading;
        public bool IsLoading 
        { 
            get=>isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private bool isLocation;
        public bool IsLocation
        {
            get => isLocation;
            set
            {
                isLocation = value;
                OnPropertyChanged(nameof(IsLocation));
            }
        }

        private Weather currentWeather;
        public Weather CurrentWeather
        {
            get => currentWeather;
            set
            {
                currentWeather = value;
                OnPropertyChanged(nameof(CurrentWeather));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));
        }

        private ObservableCollection<Weather> cityList;
        public ObservableCollection<Weather> CitysList
        {
            get => cityList;
            set
            {
                cityList = value;
                OnPropertyChanged(nameof(CitysList));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await GetWeather(CurrentWeather.City);
                });
            }
        }
        public ICommand RefreshCommandCitys
        {
            get
            {
                return new Command(async () =>
                {
                    IsLoading = true;

                    await GetCitysWeather();

                    IsLoading = false;
                });
            }
        }
        public ICommand RefreshCurrentUWP
        {
            get
            {
                return new Command(() =>
                {
                    IsLoading = true;

                    GetWeatherUWP(CurrentWeather.City);

                    IsLoading = false;
                });
            }
        }
        public ICommand RefreshCitysUWP
        {
            get
            {
                return new Command(() =>
                {
                    IsLoading = true;

                    GetCitysWeatherUWP();

                    IsLoading = false;
                });
            }
        }



        public MainViewModel()
        {
            Theme = new Theme();
            CurrentWeather = new Weather();
            if (Application.Current.Properties.ContainsKey("CurrentCity"))
                CurrentWeatherFromProperties();
            else
                GetLocation().ConfigureAwait(false);
            if (Application.Current.Properties.ContainsKey("CitysList"))
                CitysWeatherFromProperties();

        }

        public async Task<bool> GetLocation()
        {
            try
            {
                IsLocation = true;
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                CancellationTokenSource cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    if(Device.RuntimePlatform == Device.UWP)
                        GetWeatherUWP(placemark.Locality);
                    else
                        await GetWeather(placemark.Locality);
                    GetForecast(placemark.Locality);

                    return true;
                }
                IsLocation = false;
                return false;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            return false;
        }

        private async Task<bool> GetCitysWeather()
        {
            await Task.Run(() =>
            {
                foreach (var i in CitysList)
                {
                    Weather update = GetCurrentWeather(i.City).Item1;
                    {
                        i.Clouds = update.Clouds;
                        i.Date = update.Date;
                        i.DescriptionWeather = update.DescriptionWeather;
                        i.Humidity = update.Humidity;
                        i.Icon = update.Icon;
                        i.MainWeather = update.MainWeather;
                        i.Pressure = update.Pressure;
                        i.Temperature = update.Temperature;
                        i.TemperatureFeels = update.TemperatureFeels;
                        i.TemperatureMax = update.TemperatureMax;
                        i.TemperatureMin = update.TemperatureMin;
                        i.WeatherColor = update.WeatherColor;
                        i.WindDegress = update.WindDegress;
                        i.WindGust = update.WindGust;
                        i.WindSpeed = update.WindSpeed;
                    }
                }
                CityListToProperties();
                return true;
            });
            return true;
        }
        private bool GetCitysWeatherUWP()
        {
            foreach (var i in CitysList)
            {
                Weather update = GetCurrentWeather(i.City).Item1;
                {
                    i.Clouds = update.Clouds;
                    i.Date = update.Date;
                    i.DescriptionWeather = update.DescriptionWeather;
                    i.Humidity = update.Humidity;
                    i.Icon = update.Icon;
                    i.MainWeather = update.MainWeather;
                    i.Pressure = update.Pressure;
                    i.Temperature = update.Temperature;
                    i.TemperatureFeels = update.TemperatureFeels;
                    i.TemperatureMax = update.TemperatureMax;
                    i.TemperatureMin = update.TemperatureMin;
                    i.WeatherColor = update.WeatherColor;
                    i.WindDegress = update.WindDegress;
                    i.WindGust = update.WindGust;
                    i.WindSpeed = update.WindSpeed;
                }
            }
            CityListToProperties();
            return true;
        }
        public async Task<string> GetWeather(string city)
        {
            await Task.Run(() =>
            {
                var answer = GetCurrentWeather(city);
                CurrentWeather = answer.Item1;
                string res = answer.Item2;
                if (res == "The remote server returned an error: (404) Not Found.")
                    return "Город не найден.";
                if (res != "true")
                    return res;

                CityListToProperties();

                GetForecast(city);

                CurrentWeatherToProperties();

                return "true";
            });
            return "true";
        }

        public string GetWeatherUWP(string city)
        {
            var answer = GetCurrentWeather(city);
            CurrentWeather = answer.Item1;
            string res = answer.Item2;
            if (res == "The remote server returned an error: (404) Not Found.")
                return "Город не найден.";
            if (res != "true")
                return res;

            CityListToProperties();

            GetForecast(city);

            CurrentWeatherToProperties();

            return "true";
        }
        private void CityListToProperties()
        {
            if (CitysList != null)
            {
                try
                {
                    Weather finding = CitysList.First(x => x.City == CurrentWeather.City);
                    {
                        finding.Clouds = CurrentWeather.Clouds;
                        finding.Date = CurrentWeather.Date;
                        finding.DescriptionWeather = CurrentWeather.DescriptionWeather;
                        finding.Humidity = CurrentWeather.Humidity;
                        finding.Icon = CurrentWeather.Icon;
                        finding.MainWeather = CurrentWeather.MainWeather;
                        finding.Pressure = CurrentWeather.Pressure;
                        finding.Temperature = CurrentWeather.Temperature;
                        finding.TemperatureFeels = CurrentWeather.TemperatureFeels;
                        finding.TemperatureMax = CurrentWeather.TemperatureMax;
                        finding.TemperatureMin = CurrentWeather.TemperatureMin;
                        finding.WeatherColor = CurrentWeather.WeatherColor;
                        finding.WindDegress = CurrentWeather.WindDegress;
                        finding.WindGust = CurrentWeather.WindGust;
                        finding.WindSpeed = CurrentWeather.WindSpeed;
                    }
                    string citys = JsonConvert.SerializeObject(CitysList);
                    Application.Current.Properties["CitysList"] = citys;

                }
                catch (Exception exp)
                {
                    CitysList.Add(GetWeatherCitys(CurrentWeather.City));
                    string citys = JsonConvert.SerializeObject(CitysList);

                    if (Application.Current.Properties.ContainsKey("CitysList"))
                        Application.Current.Properties["CitysList"] = citys;
                    else
                        Application.Current.Properties.Add("CitysList", citys);
                }
            }
            else
            {
                if (Application.Current.Properties.ContainsKey("CitysList"))
                    CitysWeatherFromProperties();
                else
                {
                    Application.Current.Properties.Add("CitysList", "");
                    CitysList = new ObservableCollection<Weather>();
                }
                CitysList.Add(GetWeatherCitys(CurrentWeather.City));
                string citys = JsonConvert.SerializeObject(CitysList);
                Application.Current.Properties["CitysList"] = citys;

            }
        }

        private void CitysWeatherFromProperties()
        {
            var res = (List<Weather>)JsonConvert.DeserializeObject(Application.Current.Properties["CitysList"].ToString(), typeof(List<Weather>));
            foreach (Weather i in res)
                GetIconForWeather(i);

            CitysList = new ObservableCollection<Weather>(res);

        }

        private void CurrentWeatherFromProperties()
        {
            Weather result = (Weather)JsonConvert.DeserializeObject(Application.Current.Properties["CurrentCity"].ToString(),typeof(Weather));
            CurrentWeather = GetIconForWeather(result);
        }
        private void CurrentWeatherToProperties()
        {
            var current = JsonConvert.SerializeObject(CurrentWeather);

            if (Application.Current.Properties.ContainsKey("CurrentCity"))
                Application.Current.Properties["CurrentCity"] = current;
            else
                Application.Current.Properties.Add("CurrentCity", current);
        }
        private Tuple<Weather,string> GetCurrentWeather( string city)
        {
            try
            {
                WebClient client = new WebClient();

                JObject weather = JObject.Parse(client.DownloadString(String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units={1}&lang=ru&appid={2}", city, "metric", AppID)));

                Weather weatherItem = ParseWeather(weather);
                weatherItem.City = city;
                weatherItem.Date = DateTime.Now.ToString("dd.MM.yyyy - H:mm");
                return new Tuple<Weather, string>(weatherItem,"true");
            }
            catch(WebException exp)
            {
                return new Tuple<Weather,string>(new Weather(), exp.Message);
            }
            catch(Exception exp)
            {
                return new Tuple<Weather, string>(new Weather(), exp.Message);
            }
        }
        private Weather GetWeatherCitys(string city)
        {
            WebClient client = new WebClient();

            JObject weather = JObject.Parse(client.DownloadString(String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units={1}&lang=ru&appid={2}", city, "metric", AppID)));

            Weather obj = ParseWeather(weather);
            obj.City = city;
            obj.Date = DateTime.Now.ToString("dd.MM.yyyy - H:mm");
            return obj;
        }
        private Weather ParseWeather(JObject weather, bool isForecast = false)
        {
            Weather element = new Weather();
            JToken value;
            foreach (var i in weather)
            {
                if (i.Key == "weather")
                {
                    value = i.Value.First["main"];
                    if (value != null)
                        element.MainWeather = value.Value<string>();

                    value = i.Value.First["description"];
                    if (value != null)
                    {
                        element.DescriptionWeather = value.Value<string>();
                        element = GetIconForWeather(element, isForecast);
                    }
                }
                else if (i.Key == "main")
                {
                    value = i.Value["temp"];
                    if (value != null)
                        element.Temperature = value.Value<string>().Split('.')[0];

                    value = i.Value["feels_like"];
                    if (value != null)
                        element.TemperatureFeels = value.Value<string>().Split('.')[0];

                    value = i.Value["temp_min"];
                    if (value != null)
                        element.TemperatureMin = value.Value<string>().Split('.')[0];

                    value = i.Value["temp_max"];
                    if (value != null)
                        element.TemperatureMax = value.Value<string>().Split('.')[0];

                    value = i.Value["pressure"];
                    if (value != null)
                    {
                        double pressure = Math.Round(value.Value<double>() * 0.7500637, 1);
                        element.Pressure = pressure.ToString();
                    }

                    value = i.Value["humidity"];
                    if (value != null)
                        element.Humidity = value.Value<string>();
                }
                else if (i.Key == "visibility")
                {
                    value = i.Value;
                    if (value != null)
                        element.Visibility = value.Value<string>();
                }
                else if (i.Key == "wind")
                {
                    value = i.Value["speed"];
                    if (value != null)
                        element.WindSpeed = value.Value<string>();

                    value = i.Value["deg"];
                    if (value != null)
                        element.WindDegress = value.Value<string>();

                    value = i.Value["gust"];
                    if (value != null)
                        element.WindGust = value.Value<string>();
                }
                else if (i.Key == "clouds")
                {
                    value = i.Value["all"];
                    if(value != null)
                        element.Clouds = value.Value<string>();
                }
                else if (i.Key == "dt_txt")
                {
                    value = i.Value;
                    if (value != null)
                    {
                        DateTime d = DateTime.Parse(value.Value<string>());
                        element.Date = d.ToString("dd.MM.yyyy - H:mm");
                    }
                }
            }

            return element;
        }

        private Weather GetIconForWeather(Weather weather, bool isForecast = false)
        {
            if (!isForecast)
            {
                var data = (Tuple<string, Color, string, string>)new ThemeConvertor().Convert
                    (
                    weather.DescriptionWeather, 
                    typeof(Tuple<string, Color, string, string>), 
                    Theme, 
                    CultureInfo.CurrentCulture
                    );

                weather.WeatherVideo = data.Item1; 
                weather.WeatherColor = data.Item2;
                weather.Icon         = data.Item3;
                weather.WeatherImage = data.Item4;
            }
            else
                weather.Icon = (string)new IconConverter().Convert(weather.DescriptionWeather, weather.Icon.GetType(), Theme, CultureInfo.CurrentCulture);

            return weather;
        }

        private void GetForecast(string city)
        {
            CurrentWeather.Forecast = new ObservableCollection<Weather>();
            WebClient client = new WebClient();
            JObject weather = JObject.Parse( client.DownloadString(String.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&units={1}&lang=ru&appid={2}", city, "metric", AppID)));

            foreach (var i in weather)
                if(i.Key == "list")
                    foreach(var data in i.Value.Children())
                        CurrentWeather.Forecast.Add(ParseWeather(data as JObject,true));
        }
    }
}
